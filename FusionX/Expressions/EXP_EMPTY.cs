//----------------------------------------------------------------------------------
//
// EMPTY STRING
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
    class EXP_EMPTY:CExp
    {
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceString("");
		}
    }
}
