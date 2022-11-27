//----------------------------------------------------------------------------------
//
// CACTIVE : Objets actifs
//
//----------------------------------------------------------------------------------

using System;

namespace FusionX.Objects
{
    class CActive : CObject
    {
        public override void handle()
        {
            ros.handle();
            if (roc.rcChanged)
            {
                roc.rcChanged = false;
                modif();
            }
        }
        public override void modif()
        {

            ros.modifRoutine();
        }
    }
}
