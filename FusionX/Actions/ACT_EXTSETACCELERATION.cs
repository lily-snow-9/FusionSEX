// -----------------------------------------------------------------------------
//
// SET ACCELERATION
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETACCELERATION:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int acc = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			pHo.rom.rmMovement.setAcc(acc);
		}
	}
}