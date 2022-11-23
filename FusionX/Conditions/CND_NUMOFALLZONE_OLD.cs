// ------------------------------------------------------------------------------
// 
// CND_NUMOFALLZONE_OLD
// 
// ------------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Objects;
using FusionX.OI;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NUMOFALLZONE_OLD:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			// Le nombre d'objets
			rhPtr.rhEvtProg.count_ZoneTypeObjects((PARAM_ZONE) evtParams[0], - 1, COI.OBJ_SPR);
			
			// Le parametre
			CValue value2 = rhPtr.get_EventExpressionAny((CParamExpression) evtParams[1]);
			short comp = ((CParamExpression) evtParams[1]).comparaison;
			CValue value_Renamed = new CValue(rhPtr.rhEvtProg.evtNSelectedObjects);
			return CRun.compareTo(value_Renamed, value2, comp);
		}
	}
}