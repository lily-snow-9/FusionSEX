// -----------------------------------------------------------------------------
//
// PAUSE ALL CHANNELS
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_PAUSEALLCHANNELS:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhApp.soundPlayer.pause();
		}
	}
}