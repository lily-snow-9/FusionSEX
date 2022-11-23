//----------------------------------------------------------------------------------
//
// CDEFCCA : definitions objet CCA
//
//----------------------------------------------------------------------------------

using FusionX.Services;

namespace FusionX.OI
{
    class CDefCCA : CDefObject
    {
        public int odCx;						// Size (ignored)
        public int odCy;
        public short odVersion;					// 0
        public short odNStartFrame;
        public int odOptions;					// Options
        public string odName;

        public override void load(CFile file)
        {
            file.skipBytes(4);
            odCx=file.readAInt();
            odCy=file.readAInt();
            odVersion=file.readAShort();
            odNStartFrame=file.readAShort();
            odOptions=file.readAInt();
            file.skipBytes(4+4);                  // odFree+pad bytes
            odName=file.readAString();
        }
    }
}
