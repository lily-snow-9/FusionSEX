//----------------------------------------------------------------------------------
//
// PARAM_INT : un parametre sur un int
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_INT:CParam
	{
		public int value_Renamed;
        public int value2;
		
		public override void  load(CRunApp app,CFile file)
		{
			value_Renamed = file.readAInt();
            value2 = 0;
		}
	}
}