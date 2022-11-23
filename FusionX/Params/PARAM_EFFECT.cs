//----------------------------------------------------------------------------------
//
// PARAM_STRING : une chaine
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{
    public class PARAM_EFFECT : CParam
    {
        public System.String pEffect;

        public override void load(CRunApp app,CFile file)
        {
            pEffect = file.readAString();
        }
    }
}