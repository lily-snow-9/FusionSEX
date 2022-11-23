//----------------------------------------------------------------------------------
//
// OPERATEUR PLUS
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_PLUS:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().add(rhPtr.getNextResult());
		}
	}
}