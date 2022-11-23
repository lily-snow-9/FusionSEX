// -----------------------------------------------------------------------------
//
// SET FRAMERATE
//
// -----------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETFRAMERATE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int value = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			if (value >= 1 && value <= 1000)
			{
				// Get top-level application
				CRunApp app = rhPtr.rhApp;
				while (app.parentApp != null)
				{
					app = app.parentApp;
				}
				
				// Set new frame rate
				app.gaFrameRate = value;
                app.setFrameRate(value);
			}
		}
	}
}