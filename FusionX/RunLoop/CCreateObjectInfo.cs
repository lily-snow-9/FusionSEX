//----------------------------------------------------------------------------------
//
// CCREATEOBJECTINFO: informations pour la creation des objets
//
//----------------------------------------------------------------------------------

using FusionX.Frame;

namespace FusionX.RunLoop
{
    public class CCreateObjectInfo
    {
        public const int COF_HIDDEN=0x0002;
        
        public CLO cobLevObj=null;				// Leave first!
        public short cobLevObjSeg=0;
        public short cobFlags=0;
        public int cobX=0;
        public int cobY=0;
        public int cobDir=0;
        public int cobLayer=0;
        public int cobZOrder=0;
    }
}
