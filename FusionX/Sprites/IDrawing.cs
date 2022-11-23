//----------------------------------------------------------------------------------
//
// IDRAWING : Interface pour les sprites owner draw
//
//----------------------------------------------------------------------------------

using FusionX.Banks;

namespace FusionX.Sprites
{
    public interface IDrawing
    {
        void drawableDraw(SpriteBatchEffect batch, CSprite sprite, CImageBank bank, int x, int y);
        void drawableKill();
        CMask drawableGetMask(int flags);
    }
}
