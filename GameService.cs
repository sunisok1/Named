using Core;
using Framework.Yggdrasil;
using Framework.Yggdrasil.Services;

namespace Game.Named
{
    public class GameService : IGameService
    {
        private ILoggerService m_logger = Injector.Instance.GetService<ILoggerService>();


        public void Run()
        {
            m_logger.Log("Game started");
        }

        public void Dispose()
        {
        }
    }

    public class GamePack : IGamePack
    {
        public string Name => "Named";
        public string Path => "Game/Named/";
        public string Version => "0.1.0";
        public string Icon => "";
    }
}