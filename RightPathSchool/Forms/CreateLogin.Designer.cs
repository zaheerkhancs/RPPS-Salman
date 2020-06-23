namespace RightPathSchool.Forms
{
    partial class CreateLogin
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
            this.label28 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSecPassword = new System.Windows.Forms.TextBox();
            this.txtHints = new System.Windows.Forms.TextBox();
            this.gvGridview = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(45, 153);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 65;
            this.label28.Text = "Hints:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 63;
            this.label19.Text = "Password:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Sec Password:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "Designation:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Role:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Full Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Login Name:";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(77, 9);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(151, 20);
            this.txtLoginName.TabIndex = 66;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(77, 32);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(151, 20);
            this.txtFullName.TabIndex = 67;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Super User",
            "Administrator",
            "User",
            "Limited User",
            "Report User"});
            this.cmbRole.Location = new System.Drawing.Point(77, 56);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(151, 21);
            this.cmbRole.TabIndex = 68;
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Items.AddRange(new object[] {
            "Principal",
            "Administrator",
            "MD",
            "Staff Member",
            "Accountant",
            "User"});
            this.cmbDesignation.Location = new System.Drawing.Point(77, 80);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(151, 21);
            this.cmbDesignation.TabIndex = 69;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(77, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 70;
            // 
            // txtSecPassword
            // 
            this.txtSecPassword.Location = new System.Drawing.Point(77, 128);
            this.txtSecPassword.Name = "txtSecPassword";
            this.txtSecPassword.PasswordChar = '*';
            this.txtSecPassword.Size = new System.Drawing.Size(151, 20);
            this.txtSecPassword.TabIndex = 71;
            // 
            // txtHints
            // 
            this.txtHints.Location = new System.Drawing.Point(77, 152);
            this.txtHints.Name = "txtHints";
            this.txtHints.Size = new System.Drawing.Size(151, 20);
            this.txtHints.TabIndex = 72;
            // 
            // gvGridview
            // 
            this.gvGridview.AllowUserToAddRows = false;
            this.gvGridview.AllowUserToDeleteRows = false;
            this.gvGridview.AllowUserToResizeColumns = false;
            this.gvGridview.AllowUserToResizeRows = false;
            this.gvGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGridview.Location = new System.Drawing.Point(283, 0);
            this.gvGridview.Name = "gvGridview";
            this.gvGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGridview.Size = new System.Drawing.Size(605, 312);
            this.gvGridview.TabIndex = 73;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(77, 193);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 74;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(153, 193);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 75;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(77, 222);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 76;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(153, 222);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 77;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            // 
            // CreateLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 337);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.gvGridview);
            this.Controls.Add(this.txtHints);
            this.Controls.Add(this.txtSecPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmbDesignation);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Name = "CreateLogin";
            this.Text = "CreateLogin";
            this.Load += new System.EventHandler(this.CreateLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSecPassword;
        private System.Windows.Forms.TextBox txtHints;
        private System.Windows.Forms.DataGridView gvGridview;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Close;
    }
}