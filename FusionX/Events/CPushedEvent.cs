//----------------------------------------------------------------------------------
//
// CPUSHEDEVENT : un evenement pousse
//
//----------------------------------------------------------------------------------

using FusionX.Objects;

namespace FusionX.Events
{	
	public class CPushedEvent
	{
		public int routine;
		public int code;
		public int param;
		public CObject pHo;
		public short oi;
		
		public CPushedEvent()
		{
		}
		public CPushedEvent(int r, int c, int p, CObject hoPtr, short o)
		{
			routine = r;
			code = c;
			param = p;
			pHo = hoPtr;
			oi = o;
		}
	}
}