// ------------------------------------------------------------------------------
// 
// LIVES
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_LIVE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			return compareCondition(rhPtr, 0, rhPtr.rhApp.lives[evtOi]);
		}
	}
}