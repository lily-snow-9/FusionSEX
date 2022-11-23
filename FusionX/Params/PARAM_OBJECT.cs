//----------------------------------------------------------------------------------
//
// CPARAMOBJECT: un parametre objet
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_OBJECT:CParam
	{
		public short oiList;
		public short oi;
		public short type;
		
		public override void  load(CRunApp app,CFile file)
		{
			oiList = file.readAShort();
			oi = file.readAShort();
			type = file.readAShort();
		}
	}
}