﻿//----------------------------------------------------------------------------------
//
// CMOVEGENERIC : Mouvement joystick
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuntimeXNA.RunLoop;
using RuntimeXNA.Objects;
using RuntimeXNA.Services;
using RuntimeXNA.Sprites;
using RuntimeXNA.Application;
using RuntimeXNA.Animations;

namespace RuntimeXNA.Movements
{
    class CMoveGeneric : CMove
    {
        public int MG_Bounce;
        public int MG_OkDirs;
        public int MG_BounceMu;
        public int MG_Speed;
        public int MG_LastBounce;
        public int MG_DirMask=0;

        public override void init(CObject ho, CMoveDef mvPtr)
        {
            hoPtr = ho;

            CMoveDefGeneric mgPtr = (CMoveDefGeneric)mvPtr;

            hoPtr.hoCalculX = 0;
            hoPtr.hoCalculY = 0;
            MG_Speed = 0;
            hoPtr.roc.rcSpeed = 0;
            MG_Bounce = 0;
            MG_LastBounce = -1;
            hoPtr.roc.rcPlayer = mvPtr.mvControl;
            rmAcc = mgPtr.mgAcc;
            rmAccValue = getAccelerator(rmAcc);
            rmDec = mgPtr.mgDec;
            rmDecValue = getAccelerator(rmDec);
            hoPtr.roc.rcMaxSpeed = mgPtr.mgSpeed;
            hoPtr.roc.rcMinSpeed = 0;
            MG_BounceMu = mgPtr.mgBounceMult;
            MG_OkDirs = mgPtr.mgDir;
            rmOpt = mgPtr.mvOpt;

            hoPtr.roc.rcChanged = true;
        }

        public override void move()
        {
            int direction;
            int autorise;
            int speed, speed8, dir;

            hoPtr.hoAdRunHeader.rhVBLObjet = 1;

            direction = hoPtr.roc.rcDir;							// Sauve la direction precedente
            hoPtr.roc.rcOldDir = direction;

            if (MG_Bounce == 0)
            {
                hoPtr.rom.rmBouncing = false;							//; Flag rebond a zero...

                // Lecture du baton de joie
                autorise = 0;
                {
                    int j = hoPtr.hoAdRunHeader.rhPlayer[hoPtr.roc.rcPlayer - 1] & 15;
                    if (j != 0)
                    {
                        dir = Joy2Dir[j];
                        if (dir != -1)
                        {
                            int flag = 1 << dir;
                            if ((flag & MG_OkDirs) != 0)
                            {
                                autorise = 1;
                                direction = dir;
                            }
                        }
                    }
                }

                // Gestion de l'acceleration / ralentissement
                int dSpeed;
                speed = MG_Speed;
                if (autorise == 0)
                {
                    if (speed != 0)
                    {
                        dSpeed = rmDecValue;
                        if ((hoPtr.hoAdRunHeader.rhFrame.leFlags & CRunFrame.LEF_TIMEDMVTS) != 0)
                        {
                            dSpeed = (int)(((double)dSpeed) * hoPtr.hoAdRunHeader.rh4MvtTimerCoef);
                        }
                        speed -= dSpeed;
                        if (speed <= 0)
                        {
                            speed = 0;
                        }
                    }
                }
                else
                {
                    speed8 = speed >> 8;							//; Partie utile de la vitesse
                    if (speed8 < hoPtr.roc.rcMaxSpeed)
                    {
                        dSpeed = rmAccValue;
                        if ((hoPtr.hoAdRunHeader.rhFrame.leFlags & CRunFrame.LEF_TIMEDMVTS) != 0)
                        {
                            dSpeed = (int)(((double)dSpeed) * hoPtr.hoAdRunHeader.rh4MvtTimerCoef);
                        }
                        speed += dSpeed;
                        speed8 = speed >> 8;
                        if (speed8 > hoPtr.roc.rcMaxSpeed)
                        {
                            speed = hoPtr.roc.rcMaxSpeed << 8;
                        }
                    }
                }
                MG_Speed = speed;						//; Retrouve la vitesse virgule
                hoPtr.roc.rcSpeed = speed >> 8;					//; Vitesse normale

                // Gestion de la direction
                hoPtr.roc.rcDir = direction;						//; C'est bon, change la direction

                // Calcul de la nouvelle image
                hoPtr.roc.rcAnim = CAnim.ANIMID_WALK;					//; Nouvelle image avec nouvelle animation
                if (hoPtr.roa != null)
                {
                    hoPtr.roa.animate();
                    if (CRun.bMoveChanged)
                        return;
                }

                // Calcul de la nouvelle position
                if (newMake_Move(hoPtr.roc.rcSpeed, hoPtr.roc.rcDir) == false)
                {
                    return;
                }
                if (CRun.bMoveChanged)
                    return;

                if (hoPtr.roc.rcSpeed == 0)						//; Bloque?
                {
                    speed = MG_Speed;					//; Pas vraiment?
                    if (speed == 0)
                    {
                        return;
                    }
                    if (hoPtr.roc.rcOldDir == hoPtr.roc.rcDir)
                    {
                        return;
                    }
                    hoPtr.roc.rcSpeed = speed >> 8;				//; Remet la vitesse
                    hoPtr.roc.rcDir = hoPtr.roc.rcOldDir;		//; Remet la direction
                    if (newMake_Move(hoPtr.roc.rcSpeed, hoPtr.roc.rcDir) == false)
                    {
                        return;			//; Essaye de nouveau!!!
                    }
                    if (CRun.bMoveChanged)
                        return;
                }
            }

            // Gestion du rebond
            while (true)
            {
                if (MG_Bounce == 0)
                {
                    return;			//; Passe en mode rebond?
                }
                if (hoPtr.hoAdRunHeader.rhVBLObjet == 0)
                {
                    return;					//; Encore des VBL?
                }
                speed = MG_Speed;
                speed -= rmDecValue;
                if (speed > 0)
                {
                    MG_Speed = speed;					//; Et stocke
                    speed >>= 8;
                    hoPtr.roc.rcSpeed = speed;
                    dir = hoPtr.roc.rcDir;						//; Direction du rebond
                    if (MG_Bounce != 0)
                    {
                        dir += 16;
                        dir &= 31;
                    }
                    if (newMake_Move(speed, dir) == false)
                    {
                        return;
                    }
                    if (CRun.bMoveChanged)
                        return;
                    continue;
                }
                else
                {
                    MG_Speed = 0;
                    hoPtr.roc.rcSpeed = 0;
                    MG_Bounce = 0;
                }
                break;
            }
            ;
        }

        public override void bounce()
        {
            if (rmCollisionCount == hoPtr.hoAdRunHeader.rh3CollisionCount)		//; C'est le sprite courant?
            {
                mv_Approach((rmOpt & MVTOPT_8DIR_STICK) != 0);
            }
            if (hoPtr.hoAdRunHeader.rhLoopCount == MG_LastBounce)
            {
                return;				//; Un seul bounce a chaque cycle
            }
            MG_LastBounce = hoPtr.hoAdRunHeader.rhLoopCount;
            MG_Bounce++;
            if (MG_Bounce >= 12)								//; Securite si bloque
            {
                stop();
                return;
            }
            hoPtr.rom.rmBouncing = true;
            hoPtr.rom.rmMoveFlag = true;							//; Le flag!
        }

        // Arret brusque
        // -------------
        public override void stop()
        {
            hoPtr.roc.rcSpeed = 0;
            MG_Bounce = 0;
            MG_Speed = 0;
            hoPtr.rom.rmMoveFlag = true;
            if (rmCollisionCount == hoPtr.hoAdRunHeader.rh3CollisionCount)		//; C'est le sprite courant?
            {
                // Le sprite entre dans quelque chose...
                mv_Approach((rmOpt & MVTOPT_8DIR_STICK) != 0);						//; On approche au maximum, sans toucher a la vitesse
                MG_Bounce = 0;
            }
        }

        // Redemarrage brusque
        // ~~~~~~~~~~~~~~~~~~~
        public override void start()
        {
            hoPtr.rom.rmMoveFlag = true;
            rmStopSpeed = 0;
        }

        // Force la vitesse maximum (AX= nouvelle vitesse)
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override void setMaxSpeed(int speed)
        {
            if (speed < 0)
            {
                speed = 0;
            }
            if (speed > 250)
            {
                speed = 250;
            }
            hoPtr.roc.rcMaxSpeed = speed;
            if (hoPtr.roc.rcSpeed > speed)
            {
                hoPtr.roc.rcSpeed = speed;
                MG_Speed = speed << 8;
            }
            hoPtr.rom.rmMoveFlag = true;
        }

        // Force la vitesse courante (AX= nouvelle vitesse)
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override void setSpeed(int speed)
        {
            if (speed < 0)
            {
                speed = 0;
            }
            if (speed > 250)
            {
                speed = 250;
            }
            if (speed > hoPtr.roc.rcMaxSpeed)
            {
                speed = hoPtr.roc.rcMaxSpeed;
            }
            hoPtr.roc.rcSpeed = speed;
            MG_Speed = speed << 8;
            hoPtr.rom.rmMoveFlag = true;
        }

        public override void setXPosition(int x)
        {
            if (hoPtr.hoX != x)
            {
                hoPtr.hoX = x;
                hoPtr.rom.rmMoveFlag = true;
                hoPtr.roc.rcChanged = true;
                hoPtr.roc.rcCheckCollides = true;					//; Force la detection de collision
            }
        }

        public override void setYPosition(int y)
        {
            if (hoPtr.hoY != y)
            {
                hoPtr.hoY = y;
                hoPtr.rom.rmMoveFlag = true;
                hoPtr.roc.rcChanged = true;
                hoPtr.roc.rcCheckCollides = true;					//; Force la detection de collision
            }
        }

        public void set8Dir(int dirs)
        {
            MG_OkDirs = dirs;
        }


    }
}
