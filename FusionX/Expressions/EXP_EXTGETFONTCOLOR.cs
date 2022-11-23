//----------------------------------------------------------------------------------
//
// GET FONT COLOR
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Expressions
{
	
	public class EXP_EXTGETFONTCOLOR:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			int rgb = CRun.getObjectTextColor(pHo);
			rgb = CServices.swapRGB(rgb);
            rhPtr.getCurrentResult().forceInt(rgb);
		}
	}
}