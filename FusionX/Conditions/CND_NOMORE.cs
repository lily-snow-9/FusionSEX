//----------------------------------------------------------------------------------
//
// NO MORE
//
//----------------------------------------------------------------------------------

using FusionX.Events;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOMORE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		
		public override bool eva2(CRun rhPtr)
		{
			CEventGroup pEvg = rhPtr.rhEvtProg.rhEventGroup;
			if ((pEvg.evgFlags & CEventGroup.EVGFLAGS_NOMORE) != 0)
			{
				return true; //; Deja evalu
			}
			if ((pEvg.evgFlags & (CEventGroup.EVGFLAGS_REPEAT | CEventGroup.EVGFLAGS_NOTALWAYS)) != 0)
			{
				return false; //; Verification, valide?
			}
			// Va evaluer l'expression
			if (evtParams[0].code == CParam.PARAM_EXPRESSION)
			{
				pEvg.evgInhibit = (ushort) (rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]) / 10);
			}
			else
			{
				pEvg.evgInhibit = (ushort) (((PARAM_TIME) evtParams[0]).timer / 10); //; Valeur du timer /10
			}
			pEvg.evgInhibitCpt = 0; // Init du compteur
			pEvg.evgFlags |= CEventGroup.EVGFLAGS_NOMORE; // NOMORE valide!
			return true;
		}
	}
}