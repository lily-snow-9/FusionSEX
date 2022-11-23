//----------------------------------------------------------------------------------
//
// CDEFvalues 
//
//----------------------------------------------------------------------------------

using FusionX.Services;

namespace FusionX.Values
{
    public class CDefValues
    {
        public short nValues;
        public int[] values;

        public void load(CFile file)
        {
            nValues=file.readAShort();
            values=new int[nValues];
            int n;
            for (n=0; n<nValues; n++)
            {
                values[n]=file.readAInt();
            }
        }
    }
}
