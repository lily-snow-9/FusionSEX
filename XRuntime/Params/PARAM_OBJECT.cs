//----------------------------------------------------------------------------------
//
// CPARAMOBJECT: un parametre objet
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuntimeXNA.Application;
using RuntimeXNA.Services;

namespace RuntimeXNA.Params
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