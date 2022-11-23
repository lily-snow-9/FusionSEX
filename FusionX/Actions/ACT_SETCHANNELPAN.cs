// -----------------------------------------------------------------------------
//
// SET CHANNEL PAN
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETCHANNELPAN:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            int channel = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[0]);
            int pan = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[1]);
            rhPtr.rhApp.soundPlayer.setPanChannel(channel - 1, pan);
        }
	}
}