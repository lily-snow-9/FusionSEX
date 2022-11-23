//----------------------------------------------------------------------------------
//
// VIRTUAL WIDTH
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETVIRTUALWIDTH:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhFrame.leVirtualRect.right);
		}
	}
}