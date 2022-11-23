// ------------------------------------------------------------------------------
// 
// MOUSE IN ZONE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_MINZONE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			PARAM_ZONE p = (PARAM_ZONE) evtParams[0];
			if (rhPtr.rh2MouseX >= p.x1 && rhPtr.rh2MouseX < p.x2 && rhPtr.rh2MouseY >= p.y1 && rhPtr.rh2MouseY < p.y2)
				return negaTRUE();
			return negaFALSE();
		}
	}
}