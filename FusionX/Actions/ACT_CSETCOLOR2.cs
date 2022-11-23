// -----------------------------------------------------------------------------
//
// SET COLOR 2
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Actions
{
	
	public class ACT_CSETCOLOR2:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int color;
			if (evtParams[0].code == CParam.PARAM_EXPRESSION)
			{
				color = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
				color = CServices.swapRGB(color);
			}
			else
				color = ((PARAM_COLOUR) evtParams[0]).color;
			
			((CCounter) pHo).cpt_SetColor2(color);
		}
	}
}