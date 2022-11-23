// ------------------------------------------------------------------------------
// 
// INTERFACE CNDEVAL pour l'exploration des objets d'une condition
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
    public interface ICndEval
    {
        bool eval(CRun rhPtr, CObject hoPtr);
    }
}
