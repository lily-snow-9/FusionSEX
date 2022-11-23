//----------------------------------------------------------------------------------
//
// TIMER 1/100
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_TIMCENT:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			int c = (int) (rhPtr.rhTimer / 10);
            rhPtr.getCurrentResult().forceInt(c % 100);
		}
	}
}