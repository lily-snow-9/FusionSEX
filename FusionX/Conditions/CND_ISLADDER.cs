// ------------------------------------------------------------------------------
// 
// IS LADDER AT X/Y
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_ISLADDER:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			int x = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			int y = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[1]);
			
			if (rhPtr.y_GetLadderAt_Absolute(- 1, x, y) != null)
				return negaTRUE();
			return negaFALSE();
		}
	}
}