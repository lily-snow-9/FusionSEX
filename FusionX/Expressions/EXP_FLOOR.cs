//----------------------------------------------------------------------------------
//
// FLOOR
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_FLOOR:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(System.Math.Floor(value));
		}
	}
}