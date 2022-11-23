//----------------------------------------------------------------------------------
//
// RACINE CARREE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_SQR:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value_Renamed = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(System.Math.Sqrt(value_Renamed));
		}
	}
}