// -----------------------------------------------------------------------------
//
// SET BOLD
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETBOLD:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int bFlag = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			
			CFontInfo info = CRun.getObjectFont(pHo);
			if (bFlag != 0)
				info.lfWeight = 700;
			else
				info.lfWeight = 400;
			
			CRun.setObjectFont(pHo, info, null);
		}
	}
}