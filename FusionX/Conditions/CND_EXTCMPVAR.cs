// ------------------------------------------------------------------------------
// 
// COMPARE TO ALTERABLE VALUE
// 
// ------------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Values;

namespace FusionX.Conditions
{
	
	public class CND_EXTCMPVAR:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			// Boucle d'exploration
			CObject pHo = rhPtr.rhEvtProg.evt_FirstObject(evtOiList);
			if (pHo == null)
				return false;
			
			int cpt = rhPtr.rhEvtProg.evtNSelectedObjects;
			CValue value1 = new CValue();
			CValue value2;
			CParamExpression p = (CParamExpression) evtParams[1];
			do 
			{
				int num;
				if (evtParams[0].code == 53)
				// PARAM_ALTVALUE_EXP)
					num = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
				else
					num = ((PARAM_SHORT) evtParams[0]).value;
				
				if (num >= 0 && num < CRVal.VALUES_NUMBEROF_ALTERABLE && pHo.rov != null)
				{
					value1.forceValue(pHo.rov.getValue(num));
					value2 = rhPtr.get_EventExpressionAny(p);
					
					if (CRun.compareTo(value1, value2, p.comparaison) == false)
					{
						cpt--;
						rhPtr.rhEvtProg.evt_DeleteCurrentObject();
					}
				}
				else
				{
					cpt--;
					rhPtr.rhEvtProg.evt_DeleteCurrentObject();
				}
				pHo = rhPtr.rhEvtProg.evt_NextObject();
			}
			while (pHo != null);
			return (cpt != 0);
		}
	}
}