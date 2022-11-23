// -----------------------------------------------------------------------------
//
// SET Y POSITION
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETY:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int y = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			CRun.setYPosition(pHo, y);
		}
	}
}