// -----------------------------------------------------------------------------
//
// RESTORE ANIMATION
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTRESTANIM:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			pHo.roa.animation_Restore();
			pHo.roc.rcChanged = true;
		}
	}
}