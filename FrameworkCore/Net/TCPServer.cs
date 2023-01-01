using System.Diagnostics.Metrics;
using System.Net.Sockets;

namespace FrameworkCore.Net
{
    public enum TCPEndpointType
    {
        Server, Client
    }

    public class ITCPEndpointData
    {
        int port;
        string ipaddress;
    }

    public class TCPEndpoint : ITCPEndpointData
    {
        public readonly TCPEndpointType TCPEndpointType;

        public TCPEndpoint(TCPEndpointType tCPEndpointType)
        {
            this.TCPEndpointType = tCPEndpointType;
        }
    }

    public class RemoteModule : TCPEndpoint
    {
        public RemoteModule() : base(TCPEndpointType.Client)
        {

        }
    }

    public class LocalModule : TCPEndpoint
    {
        public LocalModule() : base(TCPEndpointType.Server)
        {

        }
    }



    public class TCPServer
    {
        private readonly TcpListener serverSocket;
        private bool run = true;

        public void Stop()
        {
            this.run = false;
        }

        public TCPServer(int port)
        {
            this.serverSocket = new TcpListener(port);


            var connection = (TcpClient clientSocket) =>
            {

            };


            var loop = () => { };
            
            loop = () =>
            {

                TcpClient clientSocket = serverSocket.AcceptTcpClient();


                Thread connectionThread = new Thread(
                new ThreadStart(() => connection(clientSocket)));
                connectionThread.Start();

                if (run)
                {
                    loop();
                } else
                {

                    clientSocket.Close();
                    serverSocket.Stop();
                    Console.WriteLine("exit");
                    Console.ReadLine();
                }
            };

            Thread loopThread = new Thread(
            new ThreadStart(loop));
            loopThread.Start();
            /*    Console.WriteLine("Chat Server Started ....");
            Thread InstanceCaller = new Thread(
            new ThreadStart(() =>
            {
            }));
            while ((/*truerun))
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();

                    var loop = () =>
                    {
                        if (run)
                            loop();
                    };

                    var connection = (TcpClient clientSocket) =>
                    {

                    };

                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

            }
            
                clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
            }));*/

            
        }

        public TcpClient ClientSocket
        {
            get
            {
                return default(TcpClient);
            }
        }

        public static TCPRxTxTunnel GetRxTxTunnel(LocalModule server, RemoteModule client)
        {
            return new TCPRxTxTunnel(server, client);
        }
    }

    public class TCPRxTxTunnel
    {
        private readonly LocalModule localModule;
        private readonly RemoteModule remoteModule;

        public TCPRxTxTunnel(LocalModule localModule, RemoteModule remoteModule)
        {
            this.localModule = localModule;
            this.remoteModule = remoteModule;
        }
    }
}
