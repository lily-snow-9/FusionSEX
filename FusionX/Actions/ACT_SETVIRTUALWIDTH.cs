// -----------------------------------------------------------------------------
//
// SET VIRTUAL WIDTH
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETVIRTUALWIDTH:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int newWidth = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			
			if (newWidth < rhPtr.rhFrame.leWidth)
				newWidth = rhPtr.rhFrame.leWidth;
			if (newWidth > 0x7FFFF000)
				newWidth = 0x7FFFF000;
			
			if (rhPtr.rhFrame.leVirtualRect.right != newWidth)
				rhPtr.rhFrame.leVirtualRect.right = rhPtr.rhLevelSx = newWidth;
		}
	}
}