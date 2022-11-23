// ------------------------------------------------------------------------------
// 
// NO MORE LIVE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOMORELIVE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			if (rhPtr.rhApp.lives[evtOi] != 0)
				return false;
			return true;
		}
	}
}