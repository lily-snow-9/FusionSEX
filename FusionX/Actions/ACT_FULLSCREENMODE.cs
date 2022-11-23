// -----------------------------------------------------------------------------
//
// GOTO FULL SCREEN
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_FULLSCREENMODE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            rhPtr.rhApp.setFullScreen(true);
		}
	}
}