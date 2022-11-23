//----------------------------------------------------------------------------------
//
// CParamExpression, classe de base d'une expression
//
//----------------------------------------------------------------------------------

using FusionX.Expressions;
using FusionX.Services;

namespace FusionX.Params
{	
	public abstract class CParamExpression:CParam
	{
		public CExp[] tokens = null;
		public short comparaison;
		
		public virtual void  load(CFile file)
		{
			long debut = file.getFilePointer();
			
			// Compte le nombre de tokens
			int count = 0;
			short size;
			int code;
			while (true)
			{
				count++;
				code = file.readAInt();
				if (code == 0)
				{
					break;
				}
				size = file.readAShort();
				if (size > 6)
				{
					file.skipBytes(size - 6);
				}
			}
			;
			
			// Charge les tokens
			file.seek((int)debut);
			tokens = new CExp[count];
			int n;
			for (n = 0; n < count; n++)
			{
				tokens[n] = CExp.create(file);
			}
		}
		
	}
}