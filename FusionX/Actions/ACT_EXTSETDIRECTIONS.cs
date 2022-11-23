// -----------------------------------------------------------------------------
//
// SET DIRECTIONS
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETDIRECTIONS:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			int dirs = ((PARAM_INT) evtParams[0]).value_Renamed;
			pHo.rom.rmMovement.set8Dirs(dirs);
		}
	}
}