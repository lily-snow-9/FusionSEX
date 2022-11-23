//----------------------------------------------------------------------------------
//
// CPATHSTEP : un pas de mouvement path
//
//----------------------------------------------------------------------------------

using FusionX.Services;

namespace FusionX.Movements
{
    class CPathStep
    {
        //  public byte mdPrevious;
        //  public byte mdNext;
        public byte mdSpeed;
        public byte mdDir;
        public short mdDx;
        public short mdDy;
        public short mdCosinus;
        public short mdSinus;
        public short mdLength;
        public short mdPause;
        public string mdName = null;

        public void load(CFile file)
        {
            mdSpeed=file.readByte();
            mdDir=file.readByte();
            mdDx=file.readAShort();
            mdDy=file.readAShort();
            mdCosinus=file.readAShort();
            mdSinus=file.readAShort();
            mdLength=file.readAShort();
            mdPause=file.readAShort();
            file.bUnicode = false;
            string name=file.readAString();
            file.bUnicode = true;
            if (name.Length > 0)
            {
                mdName = name;
            }
        }       

    }
}
