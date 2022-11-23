// ------------------------------------------------------------------------------
// 
// END OF PAUSE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_ENDOFPAUSE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			if (rhPtr.rh4EndOfPause != rhPtr.rhLoopCount - 1)
				return false;
			return true;
		}
	}
}