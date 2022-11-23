//----------------------------------------------------------------------------------
//
// GET RED
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETRED:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			int rgb = rhPtr.get_ExpressionInt();
            rhPtr.getCurrentResult().forceInt(rgb & 255);
		}
	}
}