using Amethyst.Engine;
using Amethyst.Engine.Scenes;
using Amethyst.Graphics;

namespace S02_BouncingBall
{
    class BBAssetsLoadingScene : AssetsLoadingScene
    {
        public override void OnUpdate(float elapsedTime)
        {
            AssetManager.Instance.AddTexture(BouncingBallGame.TEXTURE_TOYBALL, new Texture(Textures.TOYBALL, TextureFiltering.Bilinear));

            LoadingFinished = true;
        }
    }
}
