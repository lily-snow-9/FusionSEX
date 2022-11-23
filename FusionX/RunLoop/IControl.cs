//----------------------------------------------------------------------------------
//
// ICONTROL : Interface pour les controles
//
//----------------------------------------------------------------------------------

using FusionX.Sprites;

namespace FusionX.RunLoop
{
    public interface IControl
    {
        void drawControl(SpriteBatchEffect batch);
        int getX();
        int getY();
        void setFocus(bool bFlag);
        void click(int nClicks);
        void setMouseControlled(bool bFlag);
    }
}
