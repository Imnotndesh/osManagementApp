using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace winOsManagement
{
    public partial class SocketIPCForm : Form
    {
        private Socket _serverSocket;
        private bool _isRunning = false;
        private Thread _serverThread;

        //launches a new socket server, binds it to port 80 and assigns to thread ndo form dialog isihang
        private void StartSocketServer()
        {
            _serverThread = new Thread(() =>
            {
                try
                {
                    _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 9080));
                    _serverSocket.Listen(10);

                    LogMessage("[server] Server started. Waiting for connections...");

                    _isRunning = true;

                    while (_isRunning)
                    {
                        try
                        {
                            // Accept incoming client connection
                            if (!_isRunning) break;
                            Socket clientSocket = _serverSocket.Accept();
                            string clientIp = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
                            LogMessage($"[server] Client connected: {clientIp}");
                            // Receive message from the client
                            byte[] buffer = new byte[1024];
                            int bytesReceived = clientSocket.Receive(buffer);
                            string clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                            LogMessage($"[server] Message received: {clientMessage}");

                            // Send confirmation back to the client
                            string response = $"Message received ^_^ ";
                            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                            clientSocket.Send(responseBytes);
                            LogMessage("[server] Response sent to client.");

                            clientSocket.Close();
                            LogMessage("[server] Client connection closed.");
                            LogMessage("Closing SOCK server");
                            break;
                        }
                        catch (SocketException ex)
                        {
                            LogMessage($"[server] Socket error: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"[server] General error: {ex.Message}");
                        }
                    }
                }
                catch (SocketException ex)
                {
                    LogMessage($"[server] Critical socket error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    LogMessage($"[server] Critical error: {ex.Message}");
                }
                finally
                {
                    _serverSocket?.Close();
                    _serverSocket = null;
                    _isRunning = false;
                }
            });

            _serverThread.IsBackground = true;
            _serverThread.Start();
        }



        public SocketIPCForm()
        {
            InitializeComponent();
            richTextBox1.Text = ($"{DateTime.Now:HH:mm:ss} Server not running. Press start SOCK to initialize a server");
        }
        private void LogMessage(string message)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            }));
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (!_isRunning)
            {
                LogMessage("[client] Server is not running. Start the server first.");
                return;
            }

            string text = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                LogMessage("[client] Input is empty. Please enter valid text.");
                return;
            }

            try
            {
                // Create a client socket and connect to the server
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect("127.0.0.1", 9080);
                LogMessage("[client] Connected to the server.");

                // Send the input text to the server
                byte[] messageBytes = Encoding.UTF8.GetBytes(text);
                clientSocket.Send(messageBytes);
                LogMessage($"[client] Sending message.....");

                // Receive confirmation from the server
                byte[] buffer = new byte[1024];
                int bytesReceived = clientSocket.Receive(buffer);
                string serverResponse = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                LogMessage($"[client] Response from server: {serverResponse}");

                clientSocket.Close();
                LogMessage("[client] Connection closed.");
            }
            catch (SocketException ex)
            {
                LogMessage($"[client] Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                LogMessage($"[client] General error: {ex.Message}");
            }
        }
        //start server
        private void button2_Click(object sender, EventArgs e)
        {
            StartSocketServer();
        }
    }
}
