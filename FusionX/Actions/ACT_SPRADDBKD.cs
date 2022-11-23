// -----------------------------------------------------------------------------
//
// SPRITE ADD BACKGROUND
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SPRADDBKD:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			// Un cran d'animation sans effet
			if (pHo.roa != null)
				pHo.roa.animIn(0);
			
			// Layer 0 ? Stocke dans une table
			rhPtr.activeToBackdrop(pHo, ((PARAM_SHORT) evtParams[0]).value, true);
		}
	}
}