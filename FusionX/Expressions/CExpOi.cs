//----------------------------------------------------------------------------------
//
// TOKEN EXPRESSION RELIE A UN OBJECT
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{	
	public abstract class CExpOi:CExp
	{
		public short oi;
		public short oiList;
		
		public CExpOi()
		{
		}
		public abstract override void  evaluate(CRun rhPtr);
	}
}