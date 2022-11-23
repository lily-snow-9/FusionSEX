// -----------------------------------------------------------------------------
//
// SUB FROM GLOBAL VARIABLE
//
// -----------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SUBVARG:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int num;
			if (evtParams[0].code == 52)
			// PARAM_VARGLOBAL_EXP 
				num = (rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]) - 1);
			// &15; YVES: enlev
			else
				num = ((PARAM_SHORT) evtParams[0]).value;
			
			CValue value = rhPtr.get_EventExpressionAny((CParamExpression) evtParams[1]);
			rhPtr.rhApp.getGlobalValueAt(num).sub(value);
		}
	}
}