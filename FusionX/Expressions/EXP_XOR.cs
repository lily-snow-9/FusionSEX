//----------------------------------------------------------------------------------
//
// OPERATEUR XOR
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_XOR:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().xorLog(rhPtr.getNextResult());
		}
	}
}