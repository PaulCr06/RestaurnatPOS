using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TcpProiect2
{
    public partial class Form1 : Form
    {
        private int currentOrderId = 0; // incremented before each send, so the first order is #1

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            string items = txtOrderItems.Text;
            if (string.IsNullOrWhiteSpace(items)) return;

            currentOrderId++;
            string payload = $"NEW_ORDER|{currentOrderId}|{items}\n";

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 8080))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(payload);
                    stream.Write(data, 0, data.Length);
                    
                    lblStatus.Text = $"Status: Order #{currentOrderId} sent!";
                    txtOrderItems.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to Kitchen Server: " + ex.Message);
                currentOrderId--;
            }
        }
    }
}
