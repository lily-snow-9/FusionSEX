//----------------------------------------------------------------------------------
//
// CEILING
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_CEIL:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(System.Math.Ceiling(value));
		}
	}
}