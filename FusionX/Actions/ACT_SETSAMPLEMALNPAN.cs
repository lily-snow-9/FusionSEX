// -----------------------------------------------------------------------------
//
// SET SAMPLE MAIN PAN
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETSAMPLEMALNPAN:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            int pan = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[0]);
            rhPtr.rhApp.soundPlayer.setMainPan(pan);
        }
	}
}