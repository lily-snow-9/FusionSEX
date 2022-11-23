// ------------------------------------------------------------------------------
// 
// ANY KEY PRESSED
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_ANYKEY:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			return false;
		}
	}
}