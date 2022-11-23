//----------------------------------------------------------------------------------
//
// VITESSE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_EXTSPEED:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
            rhPtr.getCurrentResult().forceInt(pHo.rom.rmMovement.getSpeed());
		}
	}
}