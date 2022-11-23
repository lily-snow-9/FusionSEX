// -----------------------------------------------------------------------------
//
// COUNTER SUBTRACT VALUE
//
// -----------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_CSUBVALUE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			CValue pValue = rhPtr.get_EventExpressionAny((CParamExpression) evtParams[0]);
			((CCounter) pHo).cpt_Sub(pValue);
		}
	}
}