//----------------------------------------------------------------------------------
//
// GROUP
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_GROUP:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return false;
		}
		public override bool eva2(CRun rhPtr)
		{
			return false;
		}
	}
}