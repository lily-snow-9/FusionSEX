// ------------------------------------------------------------------------------
// 
// NO MORE OBJECT IN ZONE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTNOMOREZONE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			int count = rhPtr.rhEvtProg.count_ZoneOneObject(evtOiList, (PARAM_ZONE) evtParams[0]);
			return count == 0;
		}
	}
}