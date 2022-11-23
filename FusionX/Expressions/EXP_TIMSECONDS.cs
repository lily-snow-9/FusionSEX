//----------------------------------------------------------------------------------
//
// TIMER SECONDS
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_TIMSECONDS:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			int s = (int) (rhPtr.rhTimer / 1000);
            rhPtr.getCurrentResult().forceInt(s % 60);
		}
	}
}