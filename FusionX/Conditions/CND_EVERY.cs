// ------------------------------------------------------------------------------
// 
// EVERY
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EVERY:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			PARAM_EVERY p = (PARAM_EVERY) evtParams[0];
			
			p.compteur -= rhPtr.rhTimerDelta;
			if (p.compteur > 0)
				return false;
			p.compteur += p.delay;
			return true;
		}
	}
}