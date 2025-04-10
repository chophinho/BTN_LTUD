namespace QL_KHACH_SAN
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDANGNHAP = new System.Windows.Forms.Button();
            this.txtMATKHAU = new System.Windows.Forms.TextBox();
            this.txtTAIKHOAN = new System.Windows.Forms.TextBox();
            this.lbMATKHAU = new System.Windows.Forms.Label();
            this.lbTAIKHOAN = new System.Windows.Forms.Label();
            this.lbDANGNHAP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDANGNHAP
            // 
            this.btnDANGNHAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDANGNHAP.Location = new System.Drawing.Point(175, 284);
            this.btnDANGNHAP.Name = "btnDANGNHAP";
            this.btnDANGNHAP.Size = new System.Drawing.Size(164, 50);
            this.btnDANGNHAP.TabIndex = 30;
            this.btnDANGNHAP.Text = "ĐĂNG NHẬP";
            this.btnDANGNHAP.UseVisualStyleBackColor = true;
            this.btnDANGNHAP.Click += new System.EventHandler(this.btnDANGNHAP_Click);
            // 
            // txtMATKHAU
            // 
            this.txtMATKHAU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMATKHAU.Location = new System.Drawing.Point(152, 190);
            this.txtMATKHAU.Name = "txtMATKHAU";
            this.txtMATKHAU.Size = new System.Drawing.Size(233, 30);
            this.txtMATKHAU.TabIndex = 29;
            // 
            // txtTAIKHOAN
            // 
            this.txtTAIKHOAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTAIKHOAN.Location = new System.Drawing.Point(152, 139);
            this.txtTAIKHOAN.Name = "txtTAIKHOAN";
            this.txtTAIKHOAN.Size = new System.Drawing.Size(233, 30);
            this.txtTAIKHOAN.TabIndex = 28;
            // 
            // lbMATKHAU
            // 
            this.lbMATKHAU.AutoSize = true;
            this.lbMATKHAU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMATKHAU.Location = new System.Drawing.Point(31, 195);
            this.lbMATKHAU.Name = "lbMATKHAU";
            this.lbMATKHAU.Size = new System.Drawing.Size(93, 25);
            this.lbMATKHAU.TabIndex = 27;
            this.lbMATKHAU.Text = "Mật khẩu";
            // 
            // lbTAIKHOAN
            // 
            this.lbTAIKHOAN.AutoSize = true;
            this.lbTAIKHOAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTAIKHOAN.Location = new System.Drawing.Point(31, 139);
            this.lbTAIKHOAN.Name = "lbTAIKHOAN";
            this.lbTAIKHOAN.Size = new System.Drawing.Size(99, 25);
            this.lbTAIKHOAN.TabIndex = 26;
            this.lbTAIKHOAN.Text = "Tài khoản";
            // 
            // lbDANGNHAP
            // 
            this.lbDANGNHAP.AutoSize = true;
            this.lbDANGNHAP.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDANGNHAP.Location = new System.Drawing.Point(156, 44);
            this.lbDANGNHAP.Name = "lbDANGNHAP";
            this.lbDANGNHAP.Size = new System.Drawing.Size(150, 31);
            this.lbDANGNHAP.TabIndex = 25;
            this.lbDANGNHAP.Text = "Đăng nhập";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 436);
            this.Controls.Add(this.btnDANGNHAP);
            this.Controls.Add(this.txtMATKHAU);
            this.Controls.Add(this.txtTAIKHOAN);
            this.Controls.Add(this.lbMATKHAU);
            this.Controls.Add(this.lbTAIKHOAN);
            this.Controls.Add(this.lbDANGNHAP);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDANGNHAP;
        private System.Windows.Forms.TextBox txtMATKHAU;
        private System.Windows.Forms.TextBox txtTAIKHOAN;
        private System.Windows.Forms.Label lbMATKHAU;
        private System.Windows.Forms.Label lbTAIKHOAN;
        private System.Windows.Forms.Label lbDANGNHAP;
    }
}