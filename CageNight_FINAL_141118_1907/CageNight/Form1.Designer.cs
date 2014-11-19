namespace CageNight
{
    partial class Form1
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
            this.lblCurrentNrOfTabUpdates = new System.Windows.Forms.Label();
            this.Maintenance = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMainTabCustomerLName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMainTabCustomerFName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboMainTabCustomer = new System.Windows.Forms.ComboBox();
            this.btnMainTabCustomerUpdate = new System.Windows.Forms.Button();
            this.btnMainTabCustomerAdd = new System.Windows.Forms.Button();
            this.btnMainTabCustomerUDelete = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.updMainTabVideo = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMainTabVideo = new System.Windows.Forms.TextBox();
            this.btnMainTabVideosUpdate = new System.Windows.Forms.Button();
            this.btnMainTabVideosAdd = new System.Windows.Forms.Button();
            this.btnMainTabVideosDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboMainTabVideoGenre = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboMainTabVideo = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMainTabGenreUpdate = new System.Windows.Forms.Button();
            this.btnMainTabGenreAdd = new System.Windows.Forms.Button();
            this.btnMainTabGenreDelete = new System.Windows.Forms.Button();
            this.txtMainTabGenre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMainTabGenre = new System.Windows.Forms.ComboBox();
            this.Bookings = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBookingTabReturn = new System.Windows.Forms.Button();
            this.dtpBookingTab = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwBookingTab = new System.Windows.Forms.ListView();
            this.VideoBookingID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BookingName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VideoTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RentFilm = new System.Windows.Forms.TabPage();
            this.lblRentUsingDB = new System.Windows.Forms.Label();
            this.lstRentTab = new System.Windows.Forms.ListView();
            this.VideoID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Film = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bIsRented = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AllowedDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRentTabRent = new System.Windows.Forms.Button();
            this.cboRentTab = new System.Windows.Forms.ComboBox();
            this.tabIndexController = new System.Windows.Forms.TabControl();
            this.rdbDataBase = new System.Windows.Forms.RadioButton();
            this.rdbTestDataBase = new System.Windows.Forms.RadioButton();
            this.Maintenance.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updMainTabVideo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.Bookings.SuspendLayout();
            this.RentFilm.SuspendLayout();
            this.tabIndexController.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentNrOfTabUpdates
            // 
            this.lblCurrentNrOfTabUpdates.AutoSize = true;
            this.lblCurrentNrOfTabUpdates.Location = new System.Drawing.Point(413, 9);
            this.lblCurrentNrOfTabUpdates.Name = "lblCurrentNrOfTabUpdates";
            this.lblCurrentNrOfTabUpdates.Size = new System.Drawing.Size(98, 17);
            this.lblCurrentNrOfTabUpdates.TabIndex = 1;
            this.lblCurrentNrOfTabUpdates.Text = "Tab Updates: ";
            // 
            // Maintenance
            // 
            this.Maintenance.Controls.Add(this.groupBox6);
            this.Maintenance.Controls.Add(this.groupBox5);
            this.Maintenance.Controls.Add(this.groupBox4);
            this.Maintenance.Location = new System.Drawing.Point(4, 25);
            this.Maintenance.Margin = new System.Windows.Forms.Padding(4);
            this.Maintenance.Name = "Maintenance";
            this.Maintenance.Size = new System.Drawing.Size(988, 530);
            this.Maintenance.TabIndex = 2;
            this.Maintenance.Text = "Maintenance";
            this.Maintenance.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtMainTabCustomerLName);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txtMainTabCustomerFName);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.cboMainTabCustomer);
            this.groupBox6.Controls.Add(this.btnMainTabCustomerUpdate);
            this.groupBox6.Controls.Add(this.btnMainTabCustomerAdd);
            this.groupBox6.Controls.Add(this.btnMainTabCustomerUDelete);
            this.groupBox6.Location = new System.Drawing.Point(17, 267);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(315, 241);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Customer";
            // 
            // txtMainTabCustomerLName
            // 
            this.txtMainTabCustomerLName.Location = new System.Drawing.Point(11, 151);
            this.txtMainTabCustomerLName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMainTabCustomerLName.Name = "txtMainTabCustomerLName";
            this.txtMainTabCustomerLName.Size = new System.Drawing.Size(255, 22);
            this.txtMainTabCustomerLName.TabIndex = 21;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 130);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 17);
            this.label23.TabIndex = 20;
            this.label23.Text = "Last Name:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "Customer";
            // 
            // txtMainTabCustomerFName
            // 
            this.txtMainTabCustomerFName.Location = new System.Drawing.Point(12, 98);
            this.txtMainTabCustomerFName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMainTabCustomerFName.Name = "txtMainTabCustomerFName";
            this.txtMainTabCustomerFName.Size = new System.Drawing.Size(253, 22);
            this.txtMainTabCustomerFName.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 78);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 17;
            this.label16.Text = "First Name:";
            // 
            // cboMainTabCustomer
            // 
            this.cboMainTabCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainTabCustomer.FormattingEnabled = true;
            this.cboMainTabCustomer.Location = new System.Drawing.Point(11, 43);
            this.cboMainTabCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainTabCustomer.Name = "cboMainTabCustomer";
            this.cboMainTabCustomer.Size = new System.Drawing.Size(255, 24);
            this.cboMainTabCustomer.TabIndex = 16;
            this.cboMainTabCustomer.SelectedIndexChanged += new System.EventHandler(this.cboMainTabCustomer_SelectedIndexChanged);
            // 
            // btnMainTabCustomerUpdate
            // 
            this.btnMainTabCustomerUpdate.Location = new System.Drawing.Point(9, 180);
            this.btnMainTabCustomerUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabCustomerUpdate.Name = "btnMainTabCustomerUpdate";
            this.btnMainTabCustomerUpdate.Size = new System.Drawing.Size(77, 28);
            this.btnMainTabCustomerUpdate.TabIndex = 15;
            this.btnMainTabCustomerUpdate.Text = "Update";
            this.btnMainTabCustomerUpdate.UseVisualStyleBackColor = true;
            this.btnMainTabCustomerUpdate.Click += new System.EventHandler(this.btnMainTabCustomerUpdate_Click);
            // 
            // btnMainTabCustomerAdd
            // 
            this.btnMainTabCustomerAdd.Location = new System.Drawing.Point(97, 180);
            this.btnMainTabCustomerAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabCustomerAdd.Name = "btnMainTabCustomerAdd";
            this.btnMainTabCustomerAdd.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabCustomerAdd.TabIndex = 14;
            this.btnMainTabCustomerAdd.Text = "Add";
            this.btnMainTabCustomerAdd.UseVisualStyleBackColor = true;
            this.btnMainTabCustomerAdd.Click += new System.EventHandler(this.btnMainTabCustomerAdd_Click);
            // 
            // btnMainTabCustomerUDelete
            // 
            this.btnMainTabCustomerUDelete.Location = new System.Drawing.Point(185, 180);
            this.btnMainTabCustomerUDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabCustomerUDelete.Name = "btnMainTabCustomerUDelete";
            this.btnMainTabCustomerUDelete.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabCustomerUDelete.TabIndex = 13;
            this.btnMainTabCustomerUDelete.Text = "Delete";
            this.btnMainTabCustomerUDelete.UseVisualStyleBackColor = true;
            this.btnMainTabCustomerUDelete.Click += new System.EventHandler(this.btnMainTabCustomerUDelete_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.updMainTabVideo);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtMainTabVideo);
            this.groupBox5.Controls.Add(this.btnMainTabVideosUpdate);
            this.groupBox5.Controls.Add(this.btnMainTabVideosAdd);
            this.groupBox5.Controls.Add(this.btnMainTabVideosDelete);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.cboMainTabVideoGenre);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.cboMainTabVideo);
            this.groupBox5.Location = new System.Drawing.Point(360, 18);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(347, 316);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Videos";
            // 
            // updMainTabVideo
            // 
            this.updMainTabVideo.Location = new System.Drawing.Point(209, 178);
            this.updMainTabVideo.Margin = new System.Windows.Forms.Padding(4);
            this.updMainTabVideo.Name = "updMainTabVideo";
            this.updMainTabVideo.Size = new System.Drawing.Size(79, 22);
            this.updMainTabVideo.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 158);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Days";
            // 
            // txtMainTabVideo
            // 
            this.txtMainTabVideo.Location = new System.Drawing.Point(33, 180);
            this.txtMainTabVideo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMainTabVideo.Name = "txtMainTabVideo";
            this.txtMainTabVideo.Size = new System.Drawing.Size(165, 22);
            this.txtMainTabVideo.TabIndex = 22;
            // 
            // btnMainTabVideosUpdate
            // 
            this.btnMainTabVideosUpdate.Location = new System.Drawing.Point(32, 238);
            this.btnMainTabVideosUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabVideosUpdate.Name = "btnMainTabVideosUpdate";
            this.btnMainTabVideosUpdate.Size = new System.Drawing.Size(77, 28);
            this.btnMainTabVideosUpdate.TabIndex = 21;
            this.btnMainTabVideosUpdate.Text = "Update";
            this.btnMainTabVideosUpdate.UseVisualStyleBackColor = true;
            this.btnMainTabVideosUpdate.Click += new System.EventHandler(this.btnMainTabVideosUpdate_Click);
            // 
            // btnMainTabVideosAdd
            // 
            this.btnMainTabVideosAdd.Location = new System.Drawing.Point(120, 238);
            this.btnMainTabVideosAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabVideosAdd.Name = "btnMainTabVideosAdd";
            this.btnMainTabVideosAdd.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabVideosAdd.TabIndex = 20;
            this.btnMainTabVideosAdd.Text = "Add";
            this.btnMainTabVideosAdd.UseVisualStyleBackColor = true;
            this.btnMainTabVideosAdd.Click += new System.EventHandler(this.btnMainTabVideosAdd_Click);
            // 
            // btnMainTabVideosDelete
            // 
            this.btnMainTabVideosDelete.Location = new System.Drawing.Point(208, 238);
            this.btnMainTabVideosDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabVideosDelete.Name = "btnMainTabVideosDelete";
            this.btnMainTabVideosDelete.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabVideosDelete.TabIndex = 19;
            this.btnMainTabVideosDelete.Text = "Delete";
            this.btnMainTabVideosDelete.UseVisualStyleBackColor = true;
            this.btnMainTabVideosDelete.Click += new System.EventHandler(this.btnMainTabVideosDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 158);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 95);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Genre";
            // 
            // cboMainTabVideoGenre
            // 
            this.cboMainTabVideoGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainTabVideoGenre.FormattingEnabled = true;
            this.cboMainTabVideoGenre.Location = new System.Drawing.Point(32, 114);
            this.cboMainTabVideoGenre.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainTabVideoGenre.Name = "cboMainTabVideoGenre";
            this.cboMainTabVideoGenre.Size = new System.Drawing.Size(253, 24);
            this.cboMainTabVideoGenre.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 20);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "Video";
            // 
            // cboMainTabVideo
            // 
            this.cboMainTabVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainTabVideo.FormattingEnabled = true;
            this.cboMainTabVideo.Location = new System.Drawing.Point(32, 50);
            this.cboMainTabVideo.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainTabVideo.Name = "cboMainTabVideo";
            this.cboMainTabVideo.Size = new System.Drawing.Size(253, 24);
            this.cboMainTabVideo.TabIndex = 14;
            this.cboMainTabVideo.SelectionChangeCommitted += new System.EventHandler(this.cboMainTabVideo_SelectionChangeCommitted);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btnMainTabGenreUpdate);
            this.groupBox4.Controls.Add(this.btnMainTabGenreAdd);
            this.groupBox4.Controls.Add(this.btnMainTabGenreDelete);
            this.groupBox4.Controls.Add(this.txtMainTabGenre);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cboMainTabGenre);
            this.groupBox4.Location = new System.Drawing.Point(17, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(315, 241);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Genre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 31);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Genre";
            // 
            // btnMainTabGenreUpdate
            // 
            this.btnMainTabGenreUpdate.Location = new System.Drawing.Point(13, 158);
            this.btnMainTabGenreUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabGenreUpdate.Name = "btnMainTabGenreUpdate";
            this.btnMainTabGenreUpdate.Size = new System.Drawing.Size(77, 28);
            this.btnMainTabGenreUpdate.TabIndex = 12;
            this.btnMainTabGenreUpdate.Text = "Update";
            this.btnMainTabGenreUpdate.UseVisualStyleBackColor = true;
            this.btnMainTabGenreUpdate.Click += new System.EventHandler(this.btnMainTabGenreUpdate_Click_1);
            // 
            // btnMainTabGenreAdd
            // 
            this.btnMainTabGenreAdd.Location = new System.Drawing.Point(101, 158);
            this.btnMainTabGenreAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabGenreAdd.Name = "btnMainTabGenreAdd";
            this.btnMainTabGenreAdd.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabGenreAdd.TabIndex = 11;
            this.btnMainTabGenreAdd.Text = "Add";
            this.btnMainTabGenreAdd.UseVisualStyleBackColor = true;
            this.btnMainTabGenreAdd.Click += new System.EventHandler(this.btnMainTabGenreAdd_Click_1);
            // 
            // btnMainTabGenreDelete
            // 
            this.btnMainTabGenreDelete.Location = new System.Drawing.Point(189, 158);
            this.btnMainTabGenreDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnMainTabGenreDelete.Name = "btnMainTabGenreDelete";
            this.btnMainTabGenreDelete.Size = new System.Drawing.Size(80, 28);
            this.btnMainTabGenreDelete.TabIndex = 10;
            this.btnMainTabGenreDelete.Text = "Delete";
            this.btnMainTabGenreDelete.UseVisualStyleBackColor = true;
            this.btnMainTabGenreDelete.Click += new System.EventHandler(this.btnMainTabGenreDelete_Click_1);
            // 
            // txtMainTabGenre
            // 
            this.txtMainTabGenre.Location = new System.Drawing.Point(12, 113);
            this.txtMainTabGenre.Margin = new System.Windows.Forms.Padding(4);
            this.txtMainTabGenre.Name = "txtMainTabGenre";
            this.txtMainTabGenre.Size = new System.Drawing.Size(253, 22);
            this.txtMainTabGenre.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Name";
            // 
            // cboMainTabGenre
            // 
            this.cboMainTabGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainTabGenre.FormattingEnabled = true;
            this.cboMainTabGenre.Location = new System.Drawing.Point(12, 50);
            this.cboMainTabGenre.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainTabGenre.Name = "cboMainTabGenre";
            this.cboMainTabGenre.Size = new System.Drawing.Size(253, 24);
            this.cboMainTabGenre.TabIndex = 7;
            this.cboMainTabGenre.SelectedIndexChanged += new System.EventHandler(this.cboMainTabGenre_SelectedIndexChanged);
            // 
            // Bookings
            // 
            this.Bookings.Controls.Add(this.label3);
            this.Bookings.Controls.Add(this.btnBookingTabReturn);
            this.Bookings.Controls.Add(this.dtpBookingTab);
            this.Bookings.Controls.Add(this.label2);
            this.Bookings.Controls.Add(this.lvwBookingTab);
            this.Bookings.Location = new System.Drawing.Point(4, 25);
            this.Bookings.Margin = new System.Windows.Forms.Padding(4);
            this.Bookings.Name = "Bookings";
            this.Bookings.Padding = new System.Windows.Forms.Padding(4);
            this.Bookings.Size = new System.Drawing.Size(988, 530);
            this.Bookings.TabIndex = 1;
            this.Bookings.Text = "Bookings";
            this.Bookings.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 414);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Return Date";
            // 
            // btnBookingTabReturn
            // 
            this.btnBookingTabReturn.Location = new System.Drawing.Point(288, 433);
            this.btnBookingTabReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnBookingTabReturn.Name = "btnBookingTabReturn";
            this.btnBookingTabReturn.Size = new System.Drawing.Size(100, 28);
            this.btnBookingTabReturn.TabIndex = 3;
            this.btnBookingTabReturn.Text = "Return";
            this.btnBookingTabReturn.UseVisualStyleBackColor = true;
            this.btnBookingTabReturn.Click += new System.EventHandler(this.btnBookingTabReturn_Click);
            // 
            // dtpBookingTab
            // 
            this.dtpBookingTab.Location = new System.Drawing.Point(9, 437);
            this.dtpBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBookingTab.Name = "dtpBookingTab";
            this.dtpBookingTab.Size = new System.Drawing.Size(265, 22);
            this.dtpBookingTab.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bookings";
            // 
            // lvwBookingTab
            // 
            this.lvwBookingTab.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VideoBookingID,
            this.BookingName,
            this.CustomerName,
            this.VideoTitle,
            this.RentDate,
            this.ReturnedDate,
            this.Cost});
            this.lvwBookingTab.Location = new System.Drawing.Point(9, 57);
            this.lvwBookingTab.Margin = new System.Windows.Forms.Padding(4);
            this.lvwBookingTab.Name = "lvwBookingTab";
            this.lvwBookingTab.Size = new System.Drawing.Size(952, 338);
            this.lvwBookingTab.TabIndex = 0;
            this.lvwBookingTab.UseCompatibleStateImageBehavior = false;
            this.lvwBookingTab.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwBookingTab_ColumnClick);
            this.lvwBookingTab.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwBookingTab_ItemSelectionChanged);
            // 
            // VideoBookingID
            // 
            this.VideoBookingID.Text = global::CageNight.Properties.Settings.Default.VideoBookingID;
            // 
            // BookingName
            // 
            this.BookingName.Text = global::CageNight.Properties.Settings.Default.BookingName;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = global::CageNight.Properties.Settings.Default.CustomerName;
            // 
            // VideoTitle
            // 
            this.VideoTitle.Text = global::CageNight.Properties.Settings.Default.VideoTitle;
            // 
            // RentDate
            // 
            this.RentDate.Text = global::CageNight.Properties.Settings.Default.RentDate;
            // 
            // ReturnedDate
            // 
            this.ReturnedDate.Text = global::CageNight.Properties.Settings.Default.ReturnedDate;
            // 
            // Cost
            // 
            this.Cost.Text = global::CageNight.Properties.Settings.Default.Cost;
            // 
            // RentFilm
            // 
            this.RentFilm.Controls.Add(this.lstRentTab);
            this.RentFilm.Controls.Add(this.label1);
            this.RentFilm.Controls.Add(this.btnRentTabRent);
            this.RentFilm.Controls.Add(this.cboRentTab);
            this.RentFilm.Location = new System.Drawing.Point(4, 25);
            this.RentFilm.Margin = new System.Windows.Forms.Padding(4);
            this.RentFilm.Name = "RentFilm";
            this.RentFilm.Padding = new System.Windows.Forms.Padding(4);
            this.RentFilm.Size = new System.Drawing.Size(988, 530);
            this.RentFilm.TabIndex = 0;
            this.RentFilm.Text = "Rent Film";
            this.RentFilm.UseVisualStyleBackColor = true;
            // 
            // lblRentUsingDB
            // 
            this.lblRentUsingDB.AutoSize = true;
            this.lblRentUsingDB.Location = new System.Drawing.Point(332, 593);
            this.lblRentUsingDB.Name = "lblRentUsingDB";
            this.lblRentUsingDB.Size = new System.Drawing.Size(0, 17);
            this.lblRentUsingDB.TabIndex = 5;
            // 
            // lstRentTab
            // 
            this.lstRentTab.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VideoID,
            this.Film,
            this.Genre,
            this.bIsRented,
            this.AllowedDays});
            this.lstRentTab.FullRowSelect = true;
            this.lstRentTab.Location = new System.Drawing.Point(36, 43);
            this.lstRentTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstRentTab.MultiSelect = false;
            this.lstRentTab.Name = "lstRentTab";
            this.lstRentTab.Size = new System.Drawing.Size(453, 250);
            this.lstRentTab.TabIndex = 4;
            this.lstRentTab.UseCompatibleStateImageBehavior = false;
            this.lstRentTab.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstRentTab_ColumnClick);
            this.lstRentTab.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstRentTab_ItemSelectionChanged);
            this.lstRentTab.SelectedIndexChanged += new System.EventHandler(this.lstRentTab_SelectedIndexChanged);
            // 
            // VideoID
            // 
            this.VideoID.Text = global::CageNight.Properties.Settings.Default.VideoID;
            // 
            // Film
            // 
            this.Film.Text = global::CageNight.Properties.Settings.Default.Film;
            // 
            // Genre
            // 
            this.Genre.Tag = "Genre";
            this.Genre.Text = global::CageNight.Properties.Settings.Default.Genre;
            // 
            // bIsRented
            // 
            this.bIsRented.Text = global::CageNight.Properties.Settings.Default.bIsRented;
            // 
            // AllowedDays
            // 
            this.AllowedDays.Tag = "AllowedDays";
            this.AllowedDays.Text = global::CageNight.Properties.Settings.Default.AllowedDays;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Films";
            // 
            // btnRentTabRent
            // 
            this.btnRentTabRent.Location = new System.Drawing.Point(211, 334);
            this.btnRentTabRent.Margin = new System.Windows.Forms.Padding(4);
            this.btnRentTabRent.Name = "btnRentTabRent";
            this.btnRentTabRent.Size = new System.Drawing.Size(100, 28);
            this.btnRentTabRent.TabIndex = 2;
            this.btnRentTabRent.Text = "Rent";
            this.btnRentTabRent.UseVisualStyleBackColor = true;
            this.btnRentTabRent.Click += new System.EventHandler(this.btnRentTabRent_Click);
            // 
            // cboRentTab
            // 
            this.cboRentTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRentTab.FormattingEnabled = true;
            this.cboRentTab.Location = new System.Drawing.Point(36, 300);
            this.cboRentTab.Margin = new System.Windows.Forms.Padding(4);
            this.cboRentTab.Name = "cboRentTab";
            this.cboRentTab.Size = new System.Drawing.Size(276, 24);
            this.cboRentTab.Sorted = true;
            this.cboRentTab.TabIndex = 1;
            this.cboRentTab.SelectedIndexChanged += new System.EventHandler(this.cboRentTab_SelectedIndexChanged);
            // 
            // tabIndexController
            // 
            this.tabIndexController.Controls.Add(this.RentFilm);
            this.tabIndexController.Controls.Add(this.Bookings);
            this.tabIndexController.Controls.Add(this.Maintenance);
            this.tabIndexController.Location = new System.Drawing.Point(17, 15);
            this.tabIndexController.Margin = new System.Windows.Forms.Padding(4);
            this.tabIndexController.Name = "tabIndexController";
            this.tabIndexController.SelectedIndex = 0;
            this.tabIndexController.Size = new System.Drawing.Size(996, 559);
            this.tabIndexController.TabIndex = 0;
            // 
            // rdbDataBase
            // 
            this.rdbDataBase.AutoSize = true;
            this.rdbDataBase.Location = new System.Drawing.Point(21, 589);
            this.rdbDataBase.Name = "rdbDataBase";
            this.rdbDataBase.Size = new System.Drawing.Size(91, 21);
            this.rdbDataBase.TabIndex = 6;
            this.rdbDataBase.TabStop = true;
            this.rdbDataBase.Text = "DataBase";
            this.rdbDataBase.UseVisualStyleBackColor = true;
            this.rdbDataBase.CheckedChanged += new System.EventHandler(this.rdbDataBase_CheckedChanged);
            // 
            // rdbTestDataBase
            // 
            this.rdbTestDataBase.AutoSize = true;
            this.rdbTestDataBase.Location = new System.Drawing.Point(148, 589);
            this.rdbTestDataBase.Name = "rdbTestDataBase";
            this.rdbTestDataBase.Size = new System.Drawing.Size(119, 21);
            this.rdbTestDataBase.TabIndex = 7;
            this.rdbTestDataBase.TabStop = true;
            this.rdbTestDataBase.Text = "TestDataBase";
            this.rdbTestDataBase.UseVisualStyleBackColor = true;
            this.rdbTestDataBase.CheckedChanged += new System.EventHandler(this.rdbTestDataBase_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 622);
            this.Controls.Add(this.lblRentUsingDB);
            this.Controls.Add(this.rdbTestDataBase);
            this.Controls.Add(this.rdbDataBase);
            this.Controls.Add(this.lblCurrentNrOfTabUpdates);
            this.Controls.Add(this.tabIndexController);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Maintenance.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updMainTabVideo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Bookings.ResumeLayout(false);
            this.Bookings.PerformLayout();
            this.RentFilm.ResumeLayout(false);
            this.RentFilm.PerformLayout();
            this.tabIndexController.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentNrOfTabUpdates;
        private System.Windows.Forms.TabPage Maintenance;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtMainTabCustomerLName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMainTabCustomerFName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboMainTabCustomer;
        private System.Windows.Forms.Button btnMainTabCustomerUpdate;
        private System.Windows.Forms.Button btnMainTabCustomerAdd;
        private System.Windows.Forms.Button btnMainTabCustomerUDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown updMainTabVideo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMainTabVideo;
        private System.Windows.Forms.Button btnMainTabVideosUpdate;
        private System.Windows.Forms.Button btnMainTabVideosAdd;
        private System.Windows.Forms.Button btnMainTabVideosDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMainTabVideoGenre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboMainTabVideo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMainTabGenreUpdate;
        private System.Windows.Forms.Button btnMainTabGenreAdd;
        private System.Windows.Forms.Button btnMainTabGenreDelete;
        private System.Windows.Forms.TextBox txtMainTabGenre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMainTabGenre;
        private System.Windows.Forms.TabPage Bookings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBookingTabReturn;
        private System.Windows.Forms.DateTimePicker dtpBookingTab;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lvwBookingTab;
        private System.Windows.Forms.ColumnHeader VideoBookingID;
        private System.Windows.Forms.ColumnHeader BookingName;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader VideoTitle;
        private System.Windows.Forms.ColumnHeader RentDate;
        private System.Windows.Forms.ColumnHeader ReturnedDate;
        private System.Windows.Forms.ColumnHeader Cost;
        private System.Windows.Forms.TabPage RentFilm;
        private System.Windows.Forms.Label lblRentUsingDB;
        private System.Windows.Forms.ListView lstRentTab;
        private System.Windows.Forms.ColumnHeader VideoID;
        private System.Windows.Forms.ColumnHeader Film;
        private System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader bIsRented;
        private System.Windows.Forms.ColumnHeader AllowedDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRentTabRent;
        private System.Windows.Forms.ComboBox cboRentTab;
        private System.Windows.Forms.TabControl tabIndexController;
        private System.Windows.Forms.RadioButton rdbDataBase;
        private System.Windows.Forms.RadioButton rdbTestDataBase;

    }
}

