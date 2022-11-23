//----------------------------------------------------------------------------------
//
// OPERATEUR MODULO
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_MOD:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().mod(rhPtr.getNextResult());
		}
	}
}