//----------------------------------------------------------------------------------
//
// LEVEL
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GAMLEVELNEW:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.currentFrame + 1);
		}
	}
}