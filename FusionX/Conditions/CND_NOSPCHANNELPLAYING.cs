// ------------------------------------------------------------------------------
// 
// NO CHANNEL PLAYING
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOSPCHANNELPLAYING:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			int channel = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			return !rhPtr.rhApp.soundPlayer.isChannelPlaying(channel-1);
		}
	}
}