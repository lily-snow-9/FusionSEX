// ------------------------------------------------------------------------------
// 
// IS OBSTACLE AT XY
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Sprites;

namespace FusionX.Conditions
{
	
	public class CND_ISOBSTACLE:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			int x = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
			int y = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[1]);
			
			if (rhPtr.rhFrame.bkdCol_TestPoint(x - rhPtr.rhWindowX, y - rhPtr.rhWindowY, CSpriteGen.LAYER_ALL, CColMask.CM_TEST_OBSTACLE))
				return negaTRUE();
			return negaFALSE();
		}
	}
}