//----------------------------------------------------------------------------------
//
// VIRTUAL HEIGHT
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETVIRTUALHEIGHT:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhFrame.leVirtualRect.bottom);
		}
	}
}