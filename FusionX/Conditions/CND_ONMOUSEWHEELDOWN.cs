// ------------------------------------------------------------------------------
// 
// ON MOUSE WHEEL DOWN
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_ONMOUSEWHEELDOWN:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			if (rhPtr.rh4OnMouseWheel + 1 != rhPtr.rhLoopCount)
				return false;
			if (rhPtr.rh4MouseWheelDelta <= 0)
				return false;
			return true;
		}
	}
}