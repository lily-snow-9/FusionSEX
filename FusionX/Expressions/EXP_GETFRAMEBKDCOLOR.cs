//----------------------------------------------------------------------------------
//
// FRAME BACK COLOR
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Expressions
{
	
	public class EXP_GETFRAMEBKDCOLOR:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(CServices.swapRGB(rhPtr.rhFrame.leBackground));
		}
	}
}