// -----------------------------------------------------------------------------
//
// GOTO NODE
//
// -----------------------------------------------------------------------------

using FusionX.Movements;
using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTGOTONODE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			System.String pName = rhPtr.get_EventExpressionString((CParamExpression) evtParams[0]);
			
			if (pHo.roc.rcMovementType == CMoveDef.MVTYPE_TAPED)
			{
				CMovePath pPath = (CMovePath) pHo.rom.rmMovement;
				pPath.mtGotoNode(pName);
			}
		}
	}
}