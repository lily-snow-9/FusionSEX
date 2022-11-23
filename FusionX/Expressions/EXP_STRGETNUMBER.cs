//----------------------------------------------------------------------------------
//
// CHAINE NUMERO N
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.OI;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_STRGETNUMBER:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			rhPtr.rh4CurToken++;
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceString("");
				return ;
			}
			int num = rhPtr.get_ExpressionInt(); // Demande le numero du texte
			
			CText pText = (CText) pHo;
			
			// Le texte courant
			if (num < 0)
			{
				if (pText.rsTextBuffer != null)
                    rhPtr.getCurrentResult().forceString(pText.rsTextBuffer);
				else
                    rhPtr.getCurrentResult().forceString("");
				return ;
			}
			
			// Un texte stocke
			if (num >= pText.rsMaxi)
				num = pText.rsMaxi - 1;
			CDefTexts txt = (CDefTexts) pHo.hoCommon.ocObject;
            rhPtr.getCurrentResult().forceString(txt.otTexts[num].tsText);
		}
	}
}