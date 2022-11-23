//----------------------------------------------------------------------------------
//
// COULEUR 1 COMPTEUR
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_CGETCOLOR1:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject hoPtr = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (hoPtr == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
            rhPtr.getCurrentResult().forceInt(((CCounter)hoPtr).cpt_GetColor1());
		}
	}
}