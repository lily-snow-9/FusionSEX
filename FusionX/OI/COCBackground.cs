//----------------------------------------------------------------------------------
//
// COCBACKGROUND : un objet décor normal
//
//----------------------------------------------------------------------------------

using FusionX.Banks;
using FusionX.Services;

namespace FusionX.OI
{
    class COCBackground : COC
    {
        public short ocImage;			// Image

        public override void load(CFile file, short type)
        {
	        file.skipBytes(4);		// ocDWSize
	        ocObstacleType=file.readAShort();
	        ocColMode=file.readAShort();
	        ocCx=file.readAInt();
	        ocCy=file.readAInt();
	        ocImage=file.readAShort();
        }

        public override void enumElements(IEnum enumImages, IEnum enumFonts)
        {
            if (enumImages != null)
            {
                short num = enumImages.enumerate(ocImage);
                if (num != -1)
                {
                    ocImage = num;
                }
            }
        }

    }
}
