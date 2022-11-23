// -----------------------------------------------------------------------------
//
// RESTART LEVEL
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RESTARTLEVEL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhQuit = CRun.LOOPEXIT_RESTART;
		}
	}
}