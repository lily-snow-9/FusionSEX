//----------------------------------------------------------------------------------
//
// CEXTLOADER: Chargement des extensions
//
//----------------------------------------------------------------------------------

using System;
using FusionX.Services;

namespace FusionX.Extensions
{
    class CExtLoad
    {
        public string name;
        public string subType;
        public short handle;

        public void loadInfo(CFile file)
        {
            int debut = file.getFilePointer();

            short size = Math.Abs(file.readAShort());
            handle = file.readAShort();
            file.skipBytes(12);
            name = file.readAString();
            int pos = name.LastIndexOf('.');
            name = name.Substring(0, pos);
            subType = file.readAString();
            file.seek(debut + size);
        }

        public CRunExtension loadRunObject()
        {
	        CRunExtension pObject=null;
        	
//F01 			
	            //F01END	        	
	        return pObject;
        }

    }
}
