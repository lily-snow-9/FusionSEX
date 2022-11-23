// -----------------------------------------------------------------------------
//
// PLAY AND LOOP SAMPLE
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_PLAYLOOPSAMPLE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			PARAM_SAMPLE p = (PARAM_SAMPLE) evtParams[0];
			int nLoops = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[1]);
			bool bPrio = p.sndFlags != 0;
			rhPtr.rhApp.soundPlayer.play(p.sndHandle, nLoops, - 1, bPrio);
		}
	}
}