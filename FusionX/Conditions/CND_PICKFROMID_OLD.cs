// ------------------------------------------------------------------------------
// 
// CND_PICKFROMID_OLD
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_PICKFROMID_OLD:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			int value_Renamed = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			return rhPtr.rhEvtProg.pickFromId(value_Renamed);
		}
	}
}