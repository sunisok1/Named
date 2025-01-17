using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.Yggdrasil;

namespace Game.Named.TurnSys
{
    public class TurnSystem : ITurnSystem
    {
        private readonly List<ITurnPlayer> m_players = new();

        public void Start()
        {
            if (m_players.Count == 0)
            {
                CreateDefaultPlayers();
            }

            RunGame().Forget();
        }

        public void AddPlayer(ITurnPlayer player)
        {
            m_players.Add(player);
        }

        private void CreateDefaultPlayers()
        {
            for (var i = 0; i < 8; i++)
            {
                m_players.Add(new FakePlayer());
            }
        }

        private async UniTask RunGame()
        {
        }

        private async UniTask RunRound()
        {
        }

        public async UniTaskVoid StartAsync()
        {
            var completionSource = AutoResetUniTaskCompletionSource.Create();

            await completionSource.Task;
        }

        private async UniTask SomeAsyncOperation(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // 模拟长时间运行的任务
                    Console.WriteLine("操作进行中...");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("异步操作被取消");
            }
        }
    }
}