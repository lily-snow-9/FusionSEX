// -----------------------------------------------------------------------------
//
// FORCE ANIMATION FRAME
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTFORCEFRAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int frame = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			pHo.roa.animFrame_Force(frame);
			pHo.roc.rcChanged = true;
		}
	}
}