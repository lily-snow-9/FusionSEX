// -----------------------------------------------------------------------------
//
// SET STRING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STRSET:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo != null)
			{
				int text;
				if (evtParams[0].code == 31)
				// PARAM_TEXTNUMBER
					text = ((PARAM_SHORT) evtParams[0]).value;
				else
					text = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]) - 1;
				CText pText = (CText) pHo;
				if (pText.txtChange(text))
				{
					pHo.roc.rcChanged = true;
					pHo.display();
				}
			}
		}
	}
}