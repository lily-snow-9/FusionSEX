// -----------------------------------------------------------------------------
//
// RANDOMIZE
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RANDOMIZE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int seed = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			rhPtr.rh3Graine = (short) seed;
		}
	}
}