//Author: Jake Aquilina
//Creation Date: 07/07/20 10:15 PM
//Company: RealSoft Games
//Website: https://www.realsoftgames.com/

using UnityEngine;

namespace RealSoftGames.Network
{
    public class NetworkManager : NetworkBehaviour
    {
        public enum NetworkType
        {
            CLIENT,
            SERVER
        }

        [SerializeField] private bool ConnectOnStart;
        [SerializeField] private NetworkType networkType = NetworkType.SERVER;
        [SerializeField] private string ipAddress = "127.0.0.1";
        [SerializeField] private int serverPort = 8095;

        private void Start()
        {
            RSGNetwork.IPAddress = ipAddress;
            RSGNetwork.PortNumber = serverPort;

            if (!ConnectOnStart)
                return;

            switch (networkType)
            {
                case NetworkType.SERVER:
                    RSGNetwork.StartServer();
                    break;

                case NetworkType.CLIENT:
                    RSGNetwork.ConnectToServer();
                    break;
            }
        }

        private void OnApplicationQuit()
        {
            switch (networkType)
            {
                case NetworkType.SERVER:
                    RSGNetwork.StopServer();
                    break;

                case NetworkType.CLIENT:
                    RSGNetwork.DisconnectFromServer();
                    break;
            }
        }
    }
}