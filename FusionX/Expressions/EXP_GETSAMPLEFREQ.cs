//----------------------------------------------------------------------------------
//
// SAMPLE FREQUENCY
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{

    public class EXP_GETSAMPLEFREQ : CExp
    {
        public override void evaluate(CRun rhPtr)
        {
            rhPtr.rh4CurToken++;
            string sample = rhPtr.get_ExpressionString();
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.soundPlayer.getFrequencySample(sample));
        }
    }
}