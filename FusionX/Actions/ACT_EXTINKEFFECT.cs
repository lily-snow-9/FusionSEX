// -----------------------------------------------------------------------------
//
// SET INK EFFECT
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Sprites;

namespace FusionX.Actions
{
	
	public class ACT_EXTINKEFFECT:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.ros != null)
			{
				PARAM_2SHORTS p = (PARAM_2SHORTS) evtParams[0];
                int param1 = p.value1;
                int param2 = p.value2;
                if (param1 != CSpriteGen.BOP_BLEND)
                    param2 = 0;
                pHo.ros.modifSpriteEffect(param1, param2);
			}
		}
	}
}