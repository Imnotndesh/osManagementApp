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
            new Thread(() =>
            {
                try
                {
                    // Create the named pipe server
                    using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("TestPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.None))
                    {
                        updateLogs(serverFrom,"Waiting for client to connect...");

                        // Wait for a client to connect
                        pipeServer.WaitForConnection();
                        updateLogs(serverFrom," Client connected.");

                        // Read the client's message
                        using (StreamReader sr = new StreamReader(pipeServer))
                        using (StreamWriter sw = new StreamWriter(pipeServer))
                        {
                            string clientMessage = sr.ReadLine();
                            updateLogs(serverFrom,$"Received message: {clientMessage}");
                        }
                        pipeServer.Close();
                        updateLogs(serverFrom,"Server connection closed.");
                    }
                }
                catch (IOException ex)
                {
                    updateLogs(serverFrom,$"Pipe error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    updateLogs(serverFrom,$"General error: {ex.Message}");
                }
            }).Start();
        }
        private void updateLogs(string from ,string message)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"\n {DateTime.Now:HH:mm:ss} {from}:{message}");
            }));
        }
        private void clearLogs()
        {
            richTextBox1.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                updateLogs(clientFrom,"Please enter a message to send.");
                return;
            }

            try
            {
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "TestPipe", PipeDirection.InOut))
                {
                    updateLogs(clientFrom,"Connecting to server...");
                    pipeClient.Connect();
                    updateLogs(clientFrom,"Connected to server.");

                    // Use a single StreamWriter and StreamReader instance
                    using (StreamWriter sw = new StreamWriter(pipeClient))
                    {
                        // Send the message to the server
                        sw.WriteLine(message);
                        sw.Flush(); // Ensure the message is sent immediately
                        updateLogs(clientFrom, $"Sent message: {message}");
                    }
                    pipeClient.Close();
                }
                updateLogs(clientFrom, "Connection closed.");
            }
            catch (IOException ex)
            {
                updateLogs(clientFrom,$"Pipe error: {ex.Message}");
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
