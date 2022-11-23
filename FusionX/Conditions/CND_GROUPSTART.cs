//----------------------------------------------------------------------------------
//
// Start of group
//
//----------------------------------------------------------------------------------

using FusionX.Events;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_GROUPSTART:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			CEventGroup pEvg = rhPtr.rhEvtProg.rhEventGroup;
			if ((pEvg.evgFlags & CEventGroup.EVGFLAGS_ONCE) != 0)
				return false; // Deja evalue?
			pEvg.evgFlags |= CEventGroup.EVGFLAGS_ONCE; //; Marque pour le prochain!
			return true;
		}
	}
}