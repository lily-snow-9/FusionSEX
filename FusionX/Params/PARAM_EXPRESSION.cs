//----------------------------------------------------------------------------------
//
// PARAM_EXPRESSION : une expression
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_EXPRESSION:CParamExpression
	{
		public override void  load(CRunApp app,CFile file)
		{
			comparaison = file.readAShort();
			load(file);
		}

		
	}
}