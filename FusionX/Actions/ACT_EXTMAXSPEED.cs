// -----------------------------------------------------------------------------
//
// SET MAX SPEED
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTMAXSPEED:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int s = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			if (pHo.rom != null)
			{
				pHo.rom.rmMovement.setMaxSpeed(s);
			}
		}
	}
}