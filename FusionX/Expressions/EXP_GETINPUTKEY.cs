//----------------------------------------------------------------------------------
//
// INPUT KEY
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETINPUTKEY:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			int joueur = oi;
			
			rhPtr.rh4CurToken++;
			int key = rhPtr.get_ExpressionInt(); // Numero de la touche
			System.String s = CKeyConvert.getKeyText(rhPtr.rhApp.pcCtrlKeys[joueur*4+key]);
            rhPtr.getCurrentResult().forceString(s);
		}
	}
}