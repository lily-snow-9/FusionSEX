//----------------------------------------------------------------------------------
//
// NUMERO DE FRAME
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_CCAGETFRAMENUMBER:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			//rhPtr.CurrentResult.forceInt(((CCCA) pHo).FrameNumber);
		}
	}
}