// ------------------------------------------------------------------------------
// 
// TIMER EQUALS
// 
// ------------------------------------------------------------------------------

using FusionX.Events;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_TIMER:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			if ((evtFlags & CEvent.EVFLAGS_DONE) != 0)
				return false;
			
			PARAM_TIME p = (PARAM_TIME) evtParams[0];
			long time = p.timer;
			if (rhPtr.rhTimer < time)
				return false; // Compare au timer
			evtFlags |= CEvent.EVFLAGS_DONE; // Marque l'evenement
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			return false;
		}
	}
}