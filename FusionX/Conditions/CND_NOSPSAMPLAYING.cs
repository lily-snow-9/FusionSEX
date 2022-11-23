// ------------------------------------------------------------------------------
// 
// NO SPECIFIC SAMPLE PLAYING?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOSPSAMPLAYING:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			PARAM_SAMPLE p = (PARAM_SAMPLE) evtParams[0];
			return !rhPtr.rhApp.soundPlayer.isSamplePlaying(p.sndHandle);
		}
	}
}