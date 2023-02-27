namespace CarRentalApp
{
    partial class frmMainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageVehicleListingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRentalRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRentalRecordSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewArchiveSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsiLoginText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageVehicleListingMenuItem,
            this.manageRentalRecordsMenuItem,
            this.manageUsersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageVehicleListingMenuItem
            // 
            this.manageVehicleListingMenuItem.Name = "manageVehicleListingMenuItem";
            this.manageVehicleListingMenuItem.Size = new System.Drawing.Size(175, 26);
            this.manageVehicleListingMenuItem.Text = "Manage Vehicle Listing";
            this.manageVehicleListingMenuItem.Click += new System.EventHandler(this.manageVehicleListingToolStripMenuItem_Click);
            // 
            // manageRentalRecordsMenuItem
            // 
            this.manageRentalRecordsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRentalRecordSubMenuItem,
            this.viewArchiveSubMenuItem});
            this.manageRentalRecordsMenuItem.Name = "manageRentalRecordsMenuItem";
            this.manageRentalRecordsMenuItem.Size = new System.Drawing.Size(180, 26);
            this.manageRentalRecordsMenuItem.Text = "Manage Rental Records";
            // 
            // addRentalRecordSubMenuItem
            // 
            this.addRentalRecordSubMenuItem.Name = "addRentalRecordSubMenuItem";
            this.addRentalRecordSubMenuItem.Size = new System.Drawing.Size(217, 26);
            this.addRentalRecordSubMenuItem.Text = "Add Rental Record";
            this.addRentalRecordSubMenuItem.Click += new System.EventHandler(this.addRentalRecordToolStripMenuItem_Click);
            // 
            // viewArchiveSubMenuItem
            // 
            this.viewArchiveSubMenuItem.Name = "viewArchiveSubMenuItem";
            this.viewArchiveSubMenuItem.Size = new System.Drawing.Size(217, 26);
            this.viewArchiveSubMenuItem.Text = "View Archive";
            this.viewArchiveSubMenuItem.Click += new System.EventHandler(this.viewArchiveSubMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiLoginText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(877, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsiLoginText
            // 
            this.tsiLoginText.Name = "tsiLoginText";
            this.tsiLoginText.Size = new System.Drawing.Size(0, 18);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 535);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainWindow";
            this.Text = "Car Rental Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.frmMainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageVehicleListingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRentalRecordsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRentalRecordSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewArchiveSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsiLoginText;
    }
}