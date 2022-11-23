// -----------------------------------------------------------------------------
//
// CENTER DISPLAY
//
// -----------------------------------------------------------------------------

using System;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_CDISPLAY:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CPosition position = (CPosition) evtParams[0];
			CPositionInfo pInfo = new CPositionInfo();
			position.read_Position(rhPtr, 0, pInfo);
			rhPtr.setDisplay(pInfo.x, pInfo.y, pInfo.layer, 3);
		}
	}
}