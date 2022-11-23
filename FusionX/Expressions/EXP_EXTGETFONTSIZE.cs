//----------------------------------------------------------------------------------
//
// GET FONT SIZE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Expressions
{
	
	public class EXP_EXTGETFONTSIZE:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			CFontInfo info = CRun.getObjectFont(pHo);
            rhPtr.getCurrentResult().forceInt(info.lfHeight);
		}
	}
}