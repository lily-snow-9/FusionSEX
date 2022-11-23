// -----------------------------------------------------------------------------
//
// SET CHANNEL VOLUME
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETCHANNELVOL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            int channel = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[0]);
            int volume = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[1]);
            rhPtr.rhApp.soundPlayer.setVolumeChannel(channel - 1, volume);
        }
	}
}