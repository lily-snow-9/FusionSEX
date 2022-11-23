//----------------------------------------------------------------------------------
//
// STRING
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_STRING:CExp
	{
		public System.String pString;
		
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceString(pString);
		}
	}
}