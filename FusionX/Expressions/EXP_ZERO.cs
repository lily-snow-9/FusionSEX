//----------------------------------------------------------------------------------
//
// ZERO
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
    class EXP_ZERO:CExp
    {
        public override void evaluate(CRun rhPtr)
        {
            rhPtr.getCurrentResult().forceInt(0);
        }
    }
}
