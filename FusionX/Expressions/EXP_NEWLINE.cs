//----------------------------------------------------------------------------------
//
// NEW LINE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_NEWLINE:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			System.String s = System.Environment.NewLine;
            rhPtr.getCurrentResult().forceString(s);
		}
	}
}