//----------------------------------------------------------------------------------
//
// CMOVEDEFMOUSE : données du mouvement mouse
//
//----------------------------------------------------------------------------------

using FusionX.Services;

namespace FusionX.Movements
{
    class CMoveDefMouse : CMoveDef
    {
        public short mmDx;
        public short mmFx;
        public short mmDy;
        public short mmFy;
        public short mmFlags;

        public override void load(CFile file, int length)
        {
            mmDx=file.readAShort();
            mmFx=file.readAShort();
            mmDy=file.readAShort();
            mmFy=file.readAShort();
            mmFlags=file.readAShort();
        }
    }
}
