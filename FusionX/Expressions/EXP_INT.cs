//----------------------------------------------------------------------------------
//
// PARTIE ENTIERE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_INT:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceInt((int)value);
		}
	}
}