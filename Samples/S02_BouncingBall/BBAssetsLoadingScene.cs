using Amethyst.Engine;
using Amethyst.Engine.Scenes;
using Amethyst.Graphics;

namespace S02_BouncingBall
{
    class BBAssetsLoadingScene : AssetsLoadingScene
    {
        public override void OnUpdate(float elapsedTime)
        {
            AssetManager.CustomTextures[Textures.TOYBALL_TEX_NAME] = new Texture(Textures.TOYBALL, TextureFiltering.Bilinear);
            AssetManager.CustomFonts[Fonts.COMIC72_FONT_NAME] = Font.FromXMLSrc(Fonts.ComicSansMS_Outline_72, new Texture(Fonts.ComicSansMS_Outline_72_TEX));

            LoadingFinished = true;
        }
    }
}
