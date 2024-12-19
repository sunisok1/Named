using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using Framework.Yggdrasil;
using Framework.Yggdrasil.Services;
using Game.Named.Control;
using Game.Named.Display;
using JetBrains.Annotations;

namespace Game.Named
{
    public class GameRunner : GameRunnerBase<GameService>
    {
        protected override void Start()
        {
            base.Start();
            GameService.CancellationToken = destroyCancellationToken;
        }
    }

    public class GamePack : IGamePack
    {
        public string Name => "Named";
        public string Path => "Game/Named/";
        public string Version => "0.1.0";
        public string Icon => "";
    }

    [UsedImplicitly]
    public class GameService : IGameService
    {
        private ILoggerService m_logger;

        [ServiceConstructor]
        public GameService(ILoggerService logger)
        {
            m_logger = logger;
        }

        public CancellationToken CancellationToken { get; set; }

        public void OnAdd()
        {
            m_logger = Injector.Instance.GetService<ILoggerService>();

            Injector.Instance.Register<IControlService, ControlServiceConsole>();
            Injector.Instance.Register<IDisplayService, DisplayServiceConsole>();
        }

        public void OnRemove()
        {
            Injector.Instance.Deregister<IControlService>();
            Injector.Instance.Deregister<IDisplayService>();
        }

        public void Run()
        {
            m_logger.Log("Game started");
        }
    }
}