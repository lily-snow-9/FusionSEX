// -----------------------------------------------------------------------------
//
// NEXT LEVEL
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_NEXTLEVEL:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhQuit = CRun.LOOPEXIT_NEXTLEVEL;
		}
	}
}