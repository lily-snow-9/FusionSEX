//----------------------------------------------------------------------------------
//
// VALEUR ABSOLUE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_ABS:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(System.Math.Abs(value));
		}
	}
}