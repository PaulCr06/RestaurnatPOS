namespace TcpProiect2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtOrderItems;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtOrderItems = new System.Windows.Forms.TextBox();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // txtOrderItems
            this.txtOrderItems.Location = new System.Drawing.Point(30, 50);
            this.txtOrderItems.Name = "txtOrderItems";
            this.txtOrderItems.Size = new System.Drawing.Size(250, 23);
            
            // btnSendOrder
            this.btnSendOrder.Location = new System.Drawing.Point(30, 90);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(250, 40);
            this.btnSendOrder.Text = "Send to Kitchen";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            
            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 15);
            this.lblStatus.Text = "Status: Ready";
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.Text = "Enter order items here:";
            
            // Form1
            this.ClientSize = new System.Drawing.Size(320, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSendOrder);
            this.Controls.Add(this.txtOrderItems);
            this.Name = "Form1";
            this.Text = "Cashier POS";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
