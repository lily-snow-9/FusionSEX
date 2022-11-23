// -----------------------------------------------------------------------------
//
// SET SAMPLE VOLUME
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETSAMPLEVOL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            PARAM_SAMPLE p = (PARAM_SAMPLE)evtParams[0];
            int volume = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[1]);
            rhPtr.rhApp.soundPlayer.setVolumeSample(p.sndHandle, volume);
        }
	}
}