//----------------------------------------------------------------------------------
//
// GET FONT NAME
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Expressions
{
	
	public class EXP_EXTGETFONTNAME:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceString("");
				return ;
			}
			CFontInfo info = CRun.getObjectFont(pHo);
            rhPtr.getCurrentResult().forceString(info.lfFaceName);
		}
	}
}