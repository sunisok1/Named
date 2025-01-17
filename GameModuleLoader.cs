using Cysharp.Threading.Tasks;
using Framework.Yggdrasil;
using Framework.Yggdrasil.Services;
using Game.Named.Control;
using Game.Named.Display;
using Game.Named.TurnSys;

namespace Game.Named
{
    public sealed class GameModuleLoader : ImplModuleLoader
    {
        protected override async UniTask RegisterService()
        {
            await base.RegisterService();
            await Injector.Instance.Register<IControlService, ControlServiceConsole>();
            await Injector.Instance.Register<IDisplayService, DisplayServiceConsole>();
            await Injector.Instance.Register<ITurnSystem, TurnSystem>();
            await Injector.Instance.Register<IGameService, GameService>();

            var game = Injector.Instance.GetService<IGameService>();
            game.Run();
        }

        protected override void DeregisterService()
        {
            base.DeregisterService();
            Injector.Instance.Deregister<IControlService, ControlServiceConsole>();
            Injector.Instance.Deregister<IDisplayService, DisplayServiceConsole>();
            Injector.Instance.Deregister<ITurnSystem, TurnSystem>();
        }
    }
}