//----------------------------------------------------------------------------------
//
// ZERO
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
    class EXP_FRAMERGBCOEF:CExp
    {
        public override void evaluate(CRun rhPtr)
        {
            rhPtr.getCurrentResult().forceInt(0xFFFFFF);
        }
    }
}
