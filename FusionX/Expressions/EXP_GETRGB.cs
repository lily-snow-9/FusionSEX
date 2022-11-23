//----------------------------------------------------------------------------------
//
// GET RGB
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETRGB:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			int r = rhPtr.get_ExpressionInt();
			rhPtr.rh4CurToken++;
			int g = rhPtr.get_ExpressionInt();
			rhPtr.rh4CurToken++;
			int b = rhPtr.get_ExpressionInt();
			
			int rgb = ((b & 255) << 16) + ((g & 255) << 8) + (r & 255);
            rhPtr.getCurrentResult().forceInt(rgb);
		}
	}
}