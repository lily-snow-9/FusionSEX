// -----------------------------------------------------------------------------
//
// SET ITALIC
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETITALIC:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int bFlag = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			
			CFontInfo info = CRun.getObjectFont(pHo);
			info.lfItalic = (byte) bFlag;
			CRun.setObjectFont(pHo, info, null);
		}
	}
}