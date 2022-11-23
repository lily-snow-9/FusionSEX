// -----------------------------------------------------------------------------
//
// MOVE AFTER
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Sprites;

namespace FusionX.Actions
{
	
	public class ACT_EXTMOVEAFTER:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.ros != null)
			{
				CObject pHo2 = rhPtr.rhEvtProg.get_ParamActionObjects(((PARAM_OBJECT) evtParams[0]).oiList, this);
				if (pHo2 == null)
					return ;
				
				CSprite pSpr = pHo.roc.rcSprite;
				CSprite pSpr2 = pHo2.roc.rcSprite;
				if (pSpr != null && pSpr2 != null)
				{
					rhPtr.rhApp.spriteGen.moveSpriteAfter(pSpr, pSpr2);
				}
			}
		}
	}
}