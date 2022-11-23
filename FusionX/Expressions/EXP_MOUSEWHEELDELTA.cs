//----------------------------------------------------------------------------------
//
// MOUSEWHEELDELTA
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_MOUSEWHEELDELTA:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			int value = 0;
			if (rhPtr.rh4MouseWheelDelta < 0)
				value = 120;
			else if (rhPtr.rh4MouseWheelDelta > 0)
				value = - 120;
            rhPtr.getCurrentResult().forceInt(value);
		}
	}
}