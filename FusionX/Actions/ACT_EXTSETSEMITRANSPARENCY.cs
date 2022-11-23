// -----------------------------------------------------------------------------
//
// SET SEMI TRANSPARENCY
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;
using FusionX.Sprites;

namespace FusionX.Actions
{
	
	public class ACT_EXTSETSEMITRANSPARENCY:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.ros != null)
			{
				int val = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]);
				if (val < 0)
					val = 0;
				if (val > 128)
					val = 128;
				
				pHo.ros.rsEffect &= ~ CSpriteGen.BOP_MASK;
				pHo.ros.rsEffect |= CSprite.EFFECT_SEMITRANSP;
				pHo.ros.rsEffectParam = val;
				
				pHo.roc.rcChanged = true;
				if (pHo.roc.rcSprite != null)
				{
					pHo.hoAdRunHeader.rhApp.spriteGen.modifSpriteEffect(pHo.roc.rcSprite, pHo.ros.rsEffect, pHo.ros.rsEffectParam);
				}
			}
		}
	}
}