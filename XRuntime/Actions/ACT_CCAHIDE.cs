// -----------------------------------------------------------------------------
//
// HIDE
//
// -----------------------------------------------------------------------------
using System;
using RuntimeXNA.RunLoop;
using RuntimeXNA.Objects;
namespace RuntimeXNA.Actions
{
	
	public class ACT_CCAHIDE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			((CCCA) pHo).hide();
		}
	}
}