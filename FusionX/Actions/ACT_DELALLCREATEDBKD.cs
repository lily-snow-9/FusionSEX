// -----------------------------------------------------------------------------
//
// DELETE ALL CREATED BACKGROUND
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_DELALLCREATEDBKD:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int layer = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]) - 1;
			rhPtr.deleteAllBackdrop2(layer);
		}
	}
}