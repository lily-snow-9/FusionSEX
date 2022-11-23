//----------------------------------------------------------------------------------
//
// GLOBAL STRING
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_STRINGGLO:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++; // Saute le token
			int num = (rhPtr.get_ExpressionInt() - 1);
            rhPtr.getCurrentResult().forceString(rhPtr.rhApp.getGlobalStringAt(num));
		}
	}
}