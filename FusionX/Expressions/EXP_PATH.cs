//----------------------------------------------------------------------------------
//
// STR$
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{

    public class EXP_PATH : CExp
    {
        public override void evaluate(CRun rhPtr)
        {
            rhPtr.getCurrentResult().forceString("");
        }
    }
}