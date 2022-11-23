// -----------------------------------------------------------------------------
//
// SET ALTERABLE STRING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Values;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETVARSTRING:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int num;
			if (evtParams[0].code == 62)
			// PARAM_ALTSTRING_EXP
				num = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			else
				num = ((PARAM_SHORT) evtParams[0]).value;
			
			if (num >= 0 && num < CRVal.STRINGS_NUMBEROF_ALTERABLE)
			{
				System.String s = rhPtr.get_EventExpressionString((CParamExpression) evtParams[1]);
				pHo.rov.setString(num, s);
			}
		}
	}
}