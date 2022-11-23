// -----------------------------------------------------------------------------
//
// DISPATCH VAR
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTDISPATCHVAR:CAct
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
			
			PARAM_INT pBuffer = (PARAM_INT) evtParams[2];
			if (rhPtr.rhEvtProg.rh2ActionLoopCount == 0)
			{
				pBuffer.value_Renamed = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[1]);
			}
			else
			{
				pBuffer.value_Renamed++;
			}
			if (pHo.rov != null)
			{
				pHo.rov.getValue(num).forceInt(pBuffer.value_Renamed);
			}
		}
	}
}