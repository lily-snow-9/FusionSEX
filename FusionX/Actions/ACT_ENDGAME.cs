// -----------------------------------------------------------------------------
//
// END APPLICATION
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_ENDGAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhQuit = CRun.LOOPEXIT_ENDGAME;
		}
	}
}