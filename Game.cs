using Core;
using Framework.Yggdrasil;
using Framework.Yggdrasil.Services;
using JetBrains.Annotations;

namespace Game.Named
{
    public class GamePack : IGamePack
    {
        public string Name => "Named";
        public string Path => "Game/Named/";
        public string Version => "0.1.0";
        public string Icon => "";

        public IGameService CreateGameService()
        {
            return Injector.Instance.Register<IGameService, GameService>();
        }
    }

    [UsedImplicitly]
    public class GameService : IGameService
    {
        private readonly ILoggerService m_logger;

        [ServiceConstructor]
        public GameService(ILoggerService logger)
        {
            m_logger = logger;
        }

        public void OnAdd()
        {
        }

        public void OnRemove()
        {
        }

        public void Run()
        {
            m_logger.Log("Game started");
        }
    }
}