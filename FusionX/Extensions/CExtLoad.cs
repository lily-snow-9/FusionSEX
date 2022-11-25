//----------------------------------------------------------------------------------
//
// CEXTLOADER: Chargement des extensions
//
//----------------------------------------------------------------------------------

using System;
using FusionX.Services;
using RuntimeXNA.Extensions;

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
            CRunExtension pObject = null;
            switch (name)
            {
                case "kcini":
                    return new CRunkcini();
                case "kcclock":
                    return new CRunkcclock();
                default:
                    Console.WriteLine("Unimplemented extension: "+name);
                    return null;
            }
        }
    }
}
