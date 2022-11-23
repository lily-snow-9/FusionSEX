// -----------------------------------------------------------------------------
//
// SET GLOBAL STRING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_CCASETGLOBALSTRING:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int number = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			System.String s = rhPtr.get_EventExpressionString((CParamExpression) evtParams[1]);
			
			((CCCA) pHo).setGlobalString(number, s);
		}
	}
}