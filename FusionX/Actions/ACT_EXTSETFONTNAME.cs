// -----------------------------------------------------------------------------
//
// SET FONT NAME
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETFONTNAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			System.String name = rhPtr.get_EventExpressionString((CParamExpression) evtParams[0]);
			
			CFontInfo info = CRun.getObjectFont(pHo);
			
			info.lfFaceName = name;
			
			CRun.setObjectFont(pHo, info, null);
		}
	}
}