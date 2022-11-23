// -----------------------------------------------------------------------------
//
// RESUME ALL CHANNELS
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RESUMEALLCHANNELS:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhApp.soundPlayer.resume();
		}
	}
}