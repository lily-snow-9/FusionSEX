//----------------------------------------------------------------------------------
//
// TOTAL NUMBER OF OBJECTS
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_CRENUMBERALL:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhNObjects);
		}
	}
}