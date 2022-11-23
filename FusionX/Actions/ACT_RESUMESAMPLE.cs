// -----------------------------------------------------------------------------
//
// RESUME SAMPLE
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RESUMESAMPLE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			PARAM_SAMPLE p = (PARAM_SAMPLE) evtParams[0];
			rhPtr.rhApp.soundPlayer.resumeSample(p.sndHandle);
		}
	}
}