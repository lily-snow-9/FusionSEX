// -----------------------------------------------------------------------------
//
// END APPLICATION
//
// -----------------------------------------------------------------------------
using System;
using RuntimeXNA.RunLoop;
namespace RuntimeXNA.Actions
{
	
	public class ACT_ENDGAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			rhPtr.rhQuit = CRun.LOOPEXIT_ENDGAME;
		}
	}
}