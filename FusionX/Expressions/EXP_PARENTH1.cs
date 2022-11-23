//----------------------------------------------------------------------------------
//
// OUVERTURE PARENTHESE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_PARENTH1:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			CValue value = rhPtr.getExpression();
            rhPtr.getCurrentResult().forceValue(value);
		}
	}
}