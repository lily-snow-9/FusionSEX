// -----------------------------------------------------------------------------
//
// PAUSE ANY TOUCHE
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_PAUSEANYKEY:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rh4PauseKey = 0;
            rhPtr.bAnyKeyDown = true;
            rhPtr.bCheckResume = true;
            rhPtr.pause();
		}
	}
}