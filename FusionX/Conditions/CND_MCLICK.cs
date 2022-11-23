// ------------------------------------------------------------------------------
// 
// MOUSE CLICK
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_MCLICK:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			short key = (short) rhPtr.rhEvtProg.rhCurParam0;
			if (((PARAM_SHORT) evtParams[0]).value != key)
				return false;
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			if (((PARAM_SHORT) evtParams[0]).value == rhPtr.rhEvtProg.rh2CurrentClick)
				return true;
			return false;
		}
	}
}