//----------------------------------------------------------------------------------
//
// OPERATEUR DIVIDE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_DIV:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().div(rhPtr.getNextResult());
		}
	}
}