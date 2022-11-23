//----------------------------------------------------------------------------------
//
// CMOVEDISAPPEAR : Mouvement disparition
//
//----------------------------------------------------------------------------------

using FusionX.Animations;
using FusionX.Objects;

namespace FusionX.Movements
{
    class CMoveDisappear : CMove
    {
        public override void init(CObject ho, CMoveDef mvPtr)
        {
            hoPtr = ho;
        }
        public override void move()
        {
            if ((hoPtr.hoFlags & CObject.HOF_FADEOUT) == 0)
            {
                if (hoPtr.roa != null)
                {
                    hoPtr.roa.animate();
                    if (hoPtr.roa.raAnimForced != CAnim.ANIMID_DISAPPEAR + 1)
                    {
                        hoPtr.hoAdRunHeader.destroy_Add(hoPtr.hoNumber);
                    }
                }
            }
        }
        public override void setXPosition(int x)
        {
            if (hoPtr.hoX != x)
            {
                hoPtr.hoX = x;
                hoPtr.rom.rmMoveFlag = true;
                hoPtr.roc.rcChanged = true;
            }
        }
        public override void setYPosition(int y)
        {
            if (hoPtr.hoY != y)
            {
                hoPtr.hoY = y;
                hoPtr.rom.rmMoveFlag = true;
                hoPtr.roc.rcChanged = true;
            }
        }
    }
}
