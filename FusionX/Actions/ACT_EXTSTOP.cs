// -----------------------------------------------------------------------------
//
// STOP
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSTOP:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.rom != null)
			{
				pHo.rom.rmMovement.stop();
			}
		}
	}
}