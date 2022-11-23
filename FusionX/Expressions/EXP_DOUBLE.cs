//----------------------------------------------------------------------------------
//
// VALEUR A VIRGULE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_DOUBLE:CExp
	{
		internal double value;
		
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceDouble(value);
		}
	}
}