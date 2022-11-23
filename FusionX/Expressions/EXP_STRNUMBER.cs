//----------------------------------------------------------------------------------
//
// NUMERO DU PARAGRAPHE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_STRNUMBER:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			CText pText = (CText) pHo;
            rhPtr.getCurrentResult().forceInt(pText.rsMini + 1);
		}
	}
}