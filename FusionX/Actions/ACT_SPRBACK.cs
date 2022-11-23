// -----------------------------------------------------------------------------
//
// SPRITE TO BACk
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SPRBACK:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.roc.rcSprite != null)
			{
				rhPtr.rhApp.spriteGen.moveSpriteToBack(pHo.roc.rcSprite);
			}
		}
	}
}