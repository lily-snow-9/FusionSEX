// -----------------------------------------------------------------------------
//
// SET SAMPLE MAIN VOLUME
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETSAMPLEMAINVOL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            int volume = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[0]);
            rhPtr.rhApp.soundPlayer.setMainVolume(volume);
        }
	}
}