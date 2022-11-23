//----------------------------------------------------------------------------------
//
// OPERATEUR MODULO
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_POW:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().pow(rhPtr.getNextResult());
		}
	}
}