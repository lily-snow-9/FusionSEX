// -----------------------------------------------------------------------------
//
// DISPLAY STRING DURING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STRDISPLAYDURING:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			PARAM_SHORT p = (PARAM_SHORT) evtParams[1];
			int num = rhPtr.txtDoDisplay(this, p.value); // trouve le numero du texte        
			if (num >= 0)
			{
				PARAM_TIME p2 = (PARAM_TIME) evtParams[2];
				CObject hoPtr = rhPtr.rhObjectList[num];
				hoPtr.ros.rsFlash = p2.timer;
				hoPtr.ros.rsFlashCpt = p2.timer;
			}
		}
	}
}