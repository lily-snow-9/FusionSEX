//----------------------------------------------------------------------------------
//
// CPARAMKEY: une touche
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;
using Microsoft.Xna.Framework.Input;

namespace FusionX.Params
{	
	public class PARAM_KEY:CParam
	{
		public Keys key;
        public short mouseKey;
		
		public override void  load(CRunApp app,CFile file)
		{
			short k = file.readAShort();
			key = CKeyConvert.getXnaKey(k);
            mouseKey = k;
		}
	}
}