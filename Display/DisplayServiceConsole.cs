using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.Yggdrasil;
using Framework.Yggdrasil.Services;
using JetBrains.Annotations;

namespace Game.Named.Display
{
    [UsedImplicitly]
    public class DisplayServiceConsole : IDisplayService
    {
        private ILoggerService m_loggers = Injector.Instance.GetService<ILoggerService>();

        public async UniTask Start(CancellationToken cancellationToken)
        {
            int cnt = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                await UniTask.DelayFrame(10, cancellationToken: cancellationToken);
                m_loggers.Log(cnt++);
            }
        }
    }
}