//----------------------------------------------------------------------------------
//
// PARAM_CMPTIME
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
	public class PARAM_CMPTIME:CParam
	{
		public int timer;
		public int loops;
		public short comparaison;
		
		public override void  load(CRunApp app,CFile file)
		{
			timer = file.readAInt();
			loops = file.readAInt();
			comparaison = file.readAShort();
		}
	}
}