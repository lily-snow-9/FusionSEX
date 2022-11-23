// ------------------------------------------------------------------------------
// 
// NO MORE OBJECTS IN A ZONE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOMOREALLZONE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			PARAM_ZONE p = (PARAM_ZONE) evtParams[0];
			rhPtr.rhEvtProg.count_ZoneTypeObjects(p, - 1, (short) 0);
			if (rhPtr.rhEvtProg.evtNSelectedObjects != 0)
				return false;
			return true;
		}
	}
}