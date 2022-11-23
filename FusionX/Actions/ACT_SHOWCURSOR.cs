// -----------------------------------------------------------------------------
//
// SHOW CURSOR
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SHOWCURSOR:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			if (rhPtr.rhMouseUsed == 0)
			{
				rhPtr.showMouse();
			}
		}
	}
}