using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace winOsManagement
{
    public partial class PipeDemoForm : Form
    {
        private string clientFrom = "client";
        private string serverFrom = "server";
        private string clientMessage = null;
        private Thread _serverThread;
        public PipeDemoForm()
        {
            InitializeComponent();
            richTextBox1.Text = "Please start PIPE before sending a message";
        }
        private void StartPipeServer()
        {
            _serverThread = new Thread(() =>
            {
                try
                {
                    // Create the named pipe for communication
                    using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("TestPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.None))
                    {
                        updateLogs(serverFrom, "Server started. Waiting for client to connect...");

                        // Wait for the client to connect
                        pipeServer.WaitForConnection();
                        updateLogs(serverFrom, "Client connected.");

                        // Read the message from the client
                        using (StreamReader sr = new StreamReader(pipeServer))
                        {
                            string clientMessage = sr.ReadLine();  // Reading one line of text
                            updateLogs(serverFrom,$"Message received: {clientMessage}");
                        }

                        // Send a response to the client
                        using (StreamWriter sw = new StreamWriter(pipeServer))
                        {
                            string response = "Message received: " + clientMessage;
                            sw.WriteLine(response);
                            sw.Flush(); // Ensure the message is sent immediately
                            updateLogs(serverFrom,"Response sent to client.");
                        }

                        // Close the pipe connection after communication
                        updateLogs(serverFrom,"Communication completed. Closing pipe.");
                    }
                }
                catch (IOException ex)
                {
                    updateLogs(serverFrom, $"Pipe error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    updateLogs(serverFrom, $"General error: {ex.Message}");
                }
            });

            _serverThread.IsBackground = true;
            _serverThread.Start();
        }
        private void updateLogs(string from ,string message)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"{DateTime.Now:HH:mm:ss} {from}:{message}");
            }));
        }
        private void clearLogs()
        {
            richTextBox1.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string usertext = textBox1.Text.Trim();
            if (String.IsNullOrEmpty(usertext)){
                updateLogs(clientFrom, "Missing message. Please type something before sending");
                return;
            }
            try
            {
                using (NamedPipeClientStream pipeclient = new NamedPipeClientStream(".", "TestPipe", PipeDirection.InOut))
                {
                    pipeclient.Connect();
                    updateLogs(clientFrom, "Connected to server");

                    using (StreamWriter sw = new StreamWriter(pipeclient))
                    {
                        sw.Write(usertext);
                        sw.Flush();
                        updateLogs(clientFrom, "Sent to server");
                    }
                    using (StreamReader sr = new StreamReader(pipeclient))
                    {
                        string serverResponse = sr.ReadLine();
                        updateLogs(clientFrom, "serverResponse");
                    }
                    updateLogs(clientFrom, "Connection closed");
                }
            }
            catch (IOException ex)
            {
                updateLogs(clientFrom, $"Pipe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                updateLogs(clientFrom, $"General error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearLogs();
            StartPipeServer();
        }
    }
}
