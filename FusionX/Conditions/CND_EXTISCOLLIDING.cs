// ------------------------------------------------------------------------------
// 
// IS COLLIDING?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTISCOLLIDING:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return isColliding(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			return isColliding(rhPtr);
		}
	}
}