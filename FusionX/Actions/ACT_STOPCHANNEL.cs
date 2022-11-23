// -----------------------------------------------------------------------------
//
// STOP CHANNEL
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STOPCHANNEL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int channel = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			rhPtr.rhApp.soundPlayer.stopChannel(channel - 1);
		}
	}
}