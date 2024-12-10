using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Framework.Yggdrasil;

namespace Game.Named.TurnSys
{
    public class TurnSystem : IService
    {
        private readonly List<ITurnPlayer> m_players = new();
        private UniTaskCompletionSource m_tcs = new();

        public void Start()
        {
            if (m_players.Count == 0)
            {
                CreateDefaultPlayers();
            }

            m_tcs = new UniTaskCompletionSource();
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
            while (m_tcs.UnsafeGetStatus() != UniTaskStatus.Canceled)
            {
            }
        }

        private async UniTask RunRound()
        {
        }
    }
}