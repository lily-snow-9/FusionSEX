//----------------------------------------------------------------------------------
//
// TIMER 1/1000
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_TIMVALUE:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt((int)rhPtr.rhTimer);
		}
	}
}