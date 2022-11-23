//----------------------------------------------------------------------------------
//
// ON CLOSE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_ONCLOSE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			rhPtr.rh4MenuEaten = true;
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			if (rhPtr.rh4OnCloseCount != rhPtr.rhLoopCount)
				return false;
			return true;
		}
	}
}