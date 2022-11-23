// -----------------------------------------------------------------------------
//
// HIDE
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Sprites;

namespace FusionX.Actions
{
	
	public class ACT_EXTHIDE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.ros != null)
			{
				pHo.ros.obHide();
				pHo.ros.rsFlags &= ~ CRSpr.RSFLAG_VISIBLE;
				pHo.ros.rsFlash = 0;
			}
		}
	}
}