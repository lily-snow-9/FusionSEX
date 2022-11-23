//----------------------------------------------------------------------------------
//
// OPERATEUR MULTIPLY
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_MULT:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().mul(rhPtr.getNextResult());
		}
	}
}