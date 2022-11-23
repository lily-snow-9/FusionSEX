// ------------------------------------------------------------------------------
// 
// NUMBER OF OBJECTS IN A ZONE
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NUMOFALLZONE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			// Le nombre d'objets
			rhPtr.rhEvtProg.count_ZoneTypeObjects((PARAM_ZONE) evtParams[0], - 1, (short) 0);
			return compareCondition(rhPtr, 1, rhPtr.rhEvtProg.evtNSelectedObjects);
		}
	}
}