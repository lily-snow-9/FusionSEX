// -----------------------------------------------------------------------------
//
// SET CHANNEL FREQUENCY
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{

    public class ACT_SETCHANNELFREQ : CAct
    {
        public override void execute(CRun rhPtr)
        {
            int channel = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[0]);
            int frequency = rhPtr.get_EventExpressionInt((CParamExpression)evtParams[1]);
            rhPtr.rhApp.soundPlayer.setFrequencyChannel(channel - 1, frequency);
        }
    }
}