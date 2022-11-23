//----------------------------------------------------------------------------------
//
// ARC TANGENTE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_ATAN:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
			double temp = System.Math.Atan(value) * 57.295779513082320876798154814105;
            rhPtr.getCurrentResult().forceDouble(temp);
		}
	}
}