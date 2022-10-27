namespace _3_Vježbe
{
    partial class MainForm
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
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.LblSelectDatabase = new System.Windows.Forms.Label();
            this.LbDatabaseTables = new System.Windows.Forms.ListBox();
            this.LblDatabaseTables = new System.Windows.Forms.Label();
            this.LblTableColumns = new System.Windows.Forms.Label();
            this.LbTableColumns = new System.Windows.Forms.ListBox();
            this.TbQuery = new System.Windows.Forms.TextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageResults = new System.Windows.Forms.TabPage();
            this.DgvResults = new System.Windows.Forms.DataGridView();
            this.TabPageMessages = new System.Windows.Forms.TabPage();
            this.TbMessages = new System.Windows.Forms.TextBox();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TabPageResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvResults)).BeginInit();
            this.TabPageMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(24, 52);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(257, 24);
            this.CbDatabases.TabIndex = 0;
            this.CbDatabases.SelectedIndexChanged += new System.EventHandler(this.CbDatabases_SelectedIndexChanged);
            // 
            // LblSelectDatabase
            // 
            this.LblSelectDatabase.AutoSize = true;
            this.LblSelectDatabase.Location = new System.Drawing.Point(21, 24);
            this.LblSelectDatabase.Name = "LblSelectDatabase";
            this.LblSelectDatabase.Size = new System.Drawing.Size(106, 16);
            this.LblSelectDatabase.TabIndex = 1;
            this.LblSelectDatabase.Text = "Select database";
            // 
            // LbDatabaseTables
            // 
            this.LbDatabaseTables.FormattingEnabled = true;
            this.LbDatabaseTables.ItemHeight = 16;
            this.LbDatabaseTables.Location = new System.Drawing.Point(24, 124);
            this.LbDatabaseTables.Name = "LbDatabaseTables";
            this.LbDatabaseTables.Size = new System.Drawing.Size(257, 260);
            this.LbDatabaseTables.TabIndex = 2;
            this.LbDatabaseTables.SelectedIndexChanged += new System.EventHandler(this.LbDatabaseTables_SelectedIndexChanged);
            // 
            // LblDatabaseTables
            // 
            this.LblDatabaseTables.AutoSize = true;
            this.LblDatabaseTables.Location = new System.Drawing.Point(21, 94);
            this.LblDatabaseTables.Name = "LblDatabaseTables";
            this.LblDatabaseTables.Size = new System.Drawing.Size(107, 16);
            this.LblDatabaseTables.TabIndex = 3;
            this.LblDatabaseTables.Text = "Database tables";
            // 
            // LblTableColumns
            // 
            this.LblTableColumns.AutoSize = true;
            this.LblTableColumns.Location = new System.Drawing.Point(21, 402);
            this.LblTableColumns.Name = "LblTableColumns";
            this.LblTableColumns.Size = new System.Drawing.Size(96, 16);
            this.LblTableColumns.TabIndex = 5;
            this.LblTableColumns.Text = "Table columns";
            // 
            // LbTableColumns
            // 
            this.LbTableColumns.FormattingEnabled = true;
            this.LbTableColumns.ItemHeight = 16;
            this.LbTableColumns.Location = new System.Drawing.Point(24, 434);
            this.LbTableColumns.Name = "LbTableColumns";
            this.LbTableColumns.Size = new System.Drawing.Size(257, 228);
            this.LbTableColumns.TabIndex = 4;
            // 
            // TbQuery
            // 
            this.TbQuery.Location = new System.Drawing.Point(305, 18);
            this.TbQuery.Multiline = true;
            this.TbQuery.Name = "TbQuery";
            this.TbQuery.Size = new System.Drawing.Size(1043, 375);
            this.TbQuery.TabIndex = 6;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageResults);
            this.TabControl.Controls.Add(this.TabPageMessages);
            this.TabControl.Location = new System.Drawing.Point(305, 402);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1043, 260);
            this.TabControl.TabIndex = 7;
            // 
            // TabPageResults
            // 
            this.TabPageResults.Controls.Add(this.DgvResults);
            this.TabPageResults.Location = new System.Drawing.Point(4, 25);
            this.TabPageResults.Name = "TabPageResults";
            this.TabPageResults.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageResults.Size = new System.Drawing.Size(1035, 231);
            this.TabPageResults.TabIndex = 0;
            this.TabPageResults.Text = "Results";
            this.TabPageResults.UseVisualStyleBackColor = true;
            // 
            // DgvResults
            // 
            this.DgvResults.AllowUserToAddRows = false;
            this.DgvResults.AllowUserToDeleteRows = false;
            this.DgvResults.BackgroundColor = System.Drawing.Color.White;
            this.DgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvResults.Location = new System.Drawing.Point(3, 3);
            this.DgvResults.Name = "DgvResults";
            this.DgvResults.ReadOnly = true;
            this.DgvResults.RowHeadersWidth = 51;
            this.DgvResults.RowTemplate.Height = 24;
            this.DgvResults.Size = new System.Drawing.Size(1029, 225);
            this.DgvResults.TabIndex = 0;
            // 
            // TabPageMessages
            // 
            this.TabPageMessages.Controls.Add(this.TbMessages);
            this.TabPageMessages.Location = new System.Drawing.Point(4, 25);
            this.TabPageMessages.Name = "TabPageMessages";
            this.TabPageMessages.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMessages.Size = new System.Drawing.Size(1035, 231);
            this.TabPageMessages.TabIndex = 1;
            this.TabPageMessages.Text = "Messages";
            this.TabPageMessages.UseVisualStyleBackColor = true;
            // 
            // TbMessages
            // 
            this.TbMessages.Location = new System.Drawing.Point(-4, 0);
            this.TbMessages.Multiline = true;
            this.TbMessages.Name = "TbMessages";
            this.TbMessages.Size = new System.Drawing.Size(1043, 235);
            this.TbMessages.TabIndex = 0;
            // 
            // BtnExecute
            // 
            this.BtnExecute.BackColor = System.Drawing.Color.LightBlue;
            this.BtnExecute.Location = new System.Drawing.Point(205, 17);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(77, 28);
            this.BtnExecute.TabIndex = 8;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = false;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1369, 683);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.TbQuery);
            this.Controls.Add(this.LblTableColumns);
            this.Controls.Add(this.LbTableColumns);
            this.Controls.Add(this.LblDatabaseTables);
            this.Controls.Add(this.LbDatabaseTables);
            this.Controls.Add(this.LblSelectDatabase);
            this.Controls.Add(this.CbDatabases);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.TabControl.ResumeLayout(false);
            this.TabPageResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvResults)).EndInit();
            this.TabPageMessages.ResumeLayout(false);
            this.TabPageMessages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.Label LblSelectDatabase;
        private System.Windows.Forms.ListBox LbDatabaseTables;
        private System.Windows.Forms.Label LblDatabaseTables;
        private System.Windows.Forms.Label LblTableColumns;
        private System.Windows.Forms.ListBox LbTableColumns;
        private System.Windows.Forms.TextBox TbQuery;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageResults;
        private System.Windows.Forms.DataGridView DgvResults;
        private System.Windows.Forms.TabPage TabPageMessages;
        private System.Windows.Forms.TextBox TbMessages;
        private System.Windows.Forms.Button BtnExecute;
    }
}

