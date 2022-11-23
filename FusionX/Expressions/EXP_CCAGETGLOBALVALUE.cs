//----------------------------------------------------------------------------------
//
// GLOBAL VALUE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_CCAGETGLOBALVALUE:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			rhPtr.rh4CurToken++; // Saute le token
			int num = rhPtr.get_ExpressionInt(); // Le numero du flag
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			//rhPtr.CurrentResult.forceValue(((CCCA) pHo).getGlobalValue(num));
		}
	}
}