//----------------------------------------------------------------------------------
//
// GET X ACTION POINT
//
//----------------------------------------------------------------------------------

using FusionX.Banks;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_EXTXAP:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			int x = 0;
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo != null)
			{
				x = pHo.hoX;
				if (pHo.roa != null)
				{
                    CImage img = rhPtr.rhApp.imageBank.getImageInfoEx(pHo.roc.rcImage, pHo.roc.rcAngle, pHo.roc.rcScaleX, pHo.roc.rcScaleY);
					if (img != null)
					{
						x += img.xAP - img.xSpot;
					}
				}
			}
            rhPtr.getCurrentResult().forceInt(x);
		}
	}
}