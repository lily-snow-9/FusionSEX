// -----------------------------------------------------------------------------
//
// RESTART APPLICATION
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RESTARTGAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhQuit = CRun.LOOPEXIT_NEWGAME;
		}
	}
}