// -----------------------------------------------------------------------------
//
// GOTO WINDOWED MODE
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_WINDOWEDMODE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
            rhPtr.rhApp.setFullScreen(false);
        }
	}
}