//----------------------------------------------------------------------------------
//
// INPUT
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETINPUT:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			int joueur = oi;
			int r = CRunApp.CTRLTYPE_KEYBOARD;
			if (joueur < CRunApp.MAX_PLAYER)
				r = rhPtr.rhApp.pcCtrlType[joueur];
			if (r == CRunApp.CTRLTYPE_KEYBOARD)
				r = CRunApp.CTRLTYPE_MOUSE;
            rhPtr.getCurrentResult().forceInt(r);
		}
	}
}