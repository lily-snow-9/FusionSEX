// -----------------------------------------------------------------------------
//
// ADD TO ALTERABLE VALUE
//
// -----------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Values;

namespace FusionX.Actions
{
	
	public class ACT_EXTADDVAR:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int num;
			if (evtParams[0].code == 53)
				num = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			else
				num = ((PARAM_SHORT) evtParams[0]).value;
			
			if (num >= 0 && num < CRVal.VALUES_NUMBEROF_ALTERABLE)
			{
				if (pHo.rov != null)
				{
					CValue pValue2 = rhPtr.get_EventExpressionAny((CParamExpression) evtParams[1]);
					pHo.rov.getValue(num).add(pValue2);
				}
			}
		}
	}
}