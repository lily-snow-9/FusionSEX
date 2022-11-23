// -----------------------------------------------------------------------------
//
// DELETE CREATED BACKGROUND AT
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_DELCREATEDBKDAT:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int layer = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]) - 1;
			int x = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[1]) - rhPtr.rhWindowX;
			int y = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[2]) - rhPtr.rhWindowY;
			bool bFineDetection = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[3]) != 0;
			
			rhPtr.deleteBackdrop2At(layer, x, y, bFineDetection);
		}
	}
}