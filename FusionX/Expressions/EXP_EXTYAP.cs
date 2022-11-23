//----------------------------------------------------------------------------------
//
// GET Y ACTION POINT
//
//----------------------------------------------------------------------------------

using FusionX.Banks;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_EXTYAP:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			int y = 0;
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo != null)
			{
				y = pHo.hoY;
				if (pHo.roa != null)
				{
                    CImage img = rhPtr.rhApp.imageBank.getImageInfoEx(pHo.roc.rcImage, pHo.roc.rcAngle, pHo.roc.rcScaleX, pHo.roc.rcScaleY);
                    if (img != null)
					{
						y += img.yAP - img.ySpot;
					}
				}
			}
            rhPtr.getCurrentResult().forceInt(y);
		}
	}
}