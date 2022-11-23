// -----------------------------------------------------------------------------
//
// RESTORE INPUT
//
// -----------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_RESTINPUT:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rh2InputMask[evtOi] = (byte)(0xFF);
		}
	}
}