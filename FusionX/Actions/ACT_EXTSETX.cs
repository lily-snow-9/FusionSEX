// -----------------------------------------------------------------------------
//
// SET X POSITION
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETX:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int x = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			CRun.setXPosition(pHo, x);
		}
	}
}