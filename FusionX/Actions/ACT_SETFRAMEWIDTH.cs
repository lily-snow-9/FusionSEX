// -----------------------------------------------------------------------------
//
// SET FRAME WIDTH
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETFRAMEWIDTH:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int newWidth = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			
			// Set new width
			int nOldWidth = rhPtr.rhFrame.leWidth;
			rhPtr.rhFrame.leWidth = newWidth;
			
			// Set virtual width
			if (nOldWidth == rhPtr.rhFrame.leVirtualRect.right)
				rhPtr.rhFrame.leVirtualRect.right = rhPtr.rhLevelSx = newWidth;
			
			// Redraw frame
			rhPtr.ohRedrawLevel(true);
		}
	}
}