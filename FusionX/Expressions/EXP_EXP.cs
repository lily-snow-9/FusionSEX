//----------------------------------------------------------------------------------
//
// EXPONANTIELLE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_EXP:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value_Renamed = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(System.Math.Exp(value_Renamed));
		}
	}
}