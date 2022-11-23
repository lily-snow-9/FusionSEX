// ------------------------------------------------------------------------------
// 
// KEY DOWN
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_KBKEYDEPRESSED:CCnd
	{
		
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
/*          if (rhPtr.rh4DemoMode == CDemoRecord.DEMOPLAY)
            {
                if (rhPtr.rh4Demo.getKeyState(((PARAM_KEY)evtParams[0]).key) == false)
                    return negaFALSE();
            }
            else
 */ 
            {
                if (rhPtr.isKeyDown(((PARAM_KEY)evtParams[0]).key) == false)
                    return negaFALSE();
            }
            return negaTRUE();
		}
	}
}