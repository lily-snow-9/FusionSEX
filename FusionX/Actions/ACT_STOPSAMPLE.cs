// -----------------------------------------------------------------------------
//
// STOP SAMPLE
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STOPSAMPLE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhApp.soundPlayer.stopAllSounds();
		}
	}
}