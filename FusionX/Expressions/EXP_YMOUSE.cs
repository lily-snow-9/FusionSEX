//----------------------------------------------------------------------------------
//
// YMOUSE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_YMOUSE:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			if (rhPtr.rhMouseUsed != 0)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
            rhPtr.getCurrentResult().forceInt(rhPtr.rh2MouseY);
		}
	}
}