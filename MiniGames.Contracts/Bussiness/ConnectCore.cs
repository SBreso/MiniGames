using MiniGames.Contracts.Properties;
using System;

namespace MiniGames.Contracts.Bussiness
{
    public class ConnectCore : GameCore
    {
        public override int MaxPlayers => 2;

        public override string Name => Resources.CONNECT;

        public override int MaxTimeLimit => 120000;

        public override bool CanUseTimeLimit => true;

        public override int MinPlayers => 2;

        public override byte[] Image => Resources._4Raya;

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
