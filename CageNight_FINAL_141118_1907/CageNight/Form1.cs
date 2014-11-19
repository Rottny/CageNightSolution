using CageNight.Classes;
using DataLayer.Classes;
using DataLayer.Exceptions;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CageNight
{
    public partial class Form1 : Form
    {
        #region Variables, Events

        /** _db and _testdb are set in the constructor! */ 
        private DataBase _db;
        private TestDataBase _testdb;

        /** Booking and FormFunctions are set in Form1_Load */
        private IDataLayer booking;
        private FormFunctions ff;

        /** Selection-pointers to Rent and Bookings ListViews  */
        private int selectedFilm;
        private Customer selectedCustomer;
        private int selectedVideoBooking;

        #endregion

        #region Constructor, FormLoad
        public Form1()
        {
            _db = new DataBase();
            _testdb = new TestDataBase();

            /** IMPORTANT!! Needs to create the databases before InitializeComponent !! */
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
            /** Set DataBase as default */
            booking = new Booking(_db);

            /** Create FormFunctions and pass in the nescessary controllers */
            ff = new FormFunctions( booking, cboMainTabVideo, cboMainTabVideoGenre, cboMainTabCustomer, cboMainTabGenre,
                                    cboRentTab, lvwBookingTab, lstRentTab, txtMainTabVideo, 
                                    
                                    /** MaintenanceTab specific controllers! */
                                    updMainTabVideo, txtMainTabCustomerFName, txtMainTabCustomerLName, txtMainTabGenre);
            
            /** Label keeping track of currently selected database! */
            lblRentUsingDB.Text = "Using DataBase";

            /** IMPORTANT: Needs to be set here! */
            cboMainTabVideo.DisplayMember = "Name";
            cboMainTabVideoGenre.DisplayMember = "Name";
            cboMainTabGenre.DisplayMember = "Name";
            cboMainTabCustomer.DisplayMember = "Name";

            /** Event triggered everytime a FormFunctionsBase-method ( i.e Rent/Return ) calls on FillAndUpdateAllTabs()! */
            ff.UpdateAndFillTabs += ff_UpdateAndFillTabs;
            
            /** Check default database */
            rdbDataBase.Checked = true;
        }
        #endregion

        #region Maintenance Tab

        #region ComboBoxes
        private void cboMainTabVideo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                /** IF chosenVideo IS NOT "..empty!" */
                if (ff.MTSelectedVideo.Name != "..empty!")
                {
                    IEnumerable<Genre> chosenGenre = booking.GetGenre(ff.MTSelectedVideo.GenreId, default(String), default(Genre));
                    IEnumerable<Video> chosenValidVideo = booking.GetVideo(ff.MTSelectedVideo.Id, default(String), default(Video)); 

                    /** IF chosenGenre and chosenValidVideo was found! */
                    if (chosenGenre != null && chosenValidVideo != null)
                    {
                        cboMainTabVideoGenre.SelectedItem = chosenGenre.First();
                        updMainTabVideo.Value = chosenValidVideo.First().NrOfDaysWOPenalty;
                        txtMainTabVideo.Text = chosenValidVideo.First().Name;
                    }
                }

                /** IF chosenVideo IS "..empty!" */
                else if (ff.MTSelectedVideo.Name == "..empty!")
                {
                    cboMainTabVideoGenre.SelectedItem = 0;
                    updMainTabVideo.Value = 0;
                    txtMainTabVideo.Text = "..empty!";
                }
            }
            catch (VideoRentalException vre)
            {
                MessageBox.Show(String.Format("{0}", vre));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex));
            }

        }
        private void cboMainTabCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainTabCustomerFName.Text = ff.MTSelectedCustomer.FName;
            txtMainTabCustomerLName.Text = ff.MTSelectedCustomer.EName;
        }
        private void cboMainTabGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMainTabGenre.Text = ff.MTSelectedGenre.Name;
        }
        #endregion

        #region CustomerButtons
        private void btnMainTabCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedCustomer != null)
                ff.UpdateItem(ff.MTSelectedCustomer);
            else MessageBox.Show("Please select a valid Customer!");
        }
        private void btnMainTabCustomerAdd_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedCustomer != null)
                ff.AddItem(ff.MTSelectedCustomer);
            else MessageBox.Show("Please select a valid Customer!");
        }
        private void btnMainTabCustomerUDelete_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedCustomer != null)
                ff.DeleteItem(ff.MTSelectedCustomer);
            else MessageBox.Show("Please select a valid Customer!");
        }
        #endregion

        #region VideoButtons
        private void btnMainTabVideosUpdate_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedVideo != null)
                ff.UpdateItem(ff.MTSelectedVideo);
            else MessageBox.Show("Please select a valid Video!");
        }
        private void btnMainTabVideosAdd_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedVideo != null)
                ff.AddItem(ff.MTSelectedVideo);
            else MessageBox.Show("Please select a valid Video!");
        }
        private void btnMainTabVideosDelete_Click(object sender, EventArgs e)
        {
            if (ff.MTSelectedVideo != null)
                ff.DeleteItem(ff.MTSelectedVideo);
            else MessageBox.Show("Please select a valid Video!");
        }
        #endregion

        #region GenreButtons
        private void btnMainTabGenreUpdate_Click_1(object sender, EventArgs e)
        {
            if (ff.MTSelectedGenre != null)
                ff.UpdateItem(ff.MTSelectedGenre);
            else MessageBox.Show("Please select a valid Video!");
        }
        private void btnMainTabGenreAdd_Click_1(object sender, EventArgs e)
        {
            if (ff.MTSelectedGenre != null)
                ff.AddItem(ff.MTSelectedGenre);
            else MessageBox.Show("Please select a valid Video!");
        }
        private void btnMainTabGenreDelete_Click_1(object sender, EventArgs e)
        {
            if (ff.MTSelectedGenre != null)
                ff.DeleteItem(ff.MTSelectedGenre);
            else MessageBox.Show("Please select a valid Video!");
        }
        #endregion

        #endregion

        #region RentTab
        private void cboRentTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = (Customer)cboRentTab.SelectedItem;
        }
        private void lstRentTab_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedFilm = e.ItemIndex;
        }
        private void lstRentTab_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                ff.RentTabListSorting(e.Column);
            }
            catch (VideoRentalException vre)
            {
                MessageBox.Show(String.Format("{0}", vre.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex.Message));
            }
        }
        private void btnRentTabRent_Click(object sender, EventArgs e)
        {
            try
            {
                ff.RentTabRent(selectedFilm, selectedCustomer, tabIndexController);
            }
            catch (VideoRentalException vre)
            {
                MessageBox.Show(String.Format("{0}", vre.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex.Message));
            }
        }
        #endregion

        #region BookingTab
        private void lvwBookingTab_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedVideoBooking = e.ItemIndex;
        }
        private void lvwBookingTab_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                ff.BookingTabListSorting(e.Column);
            }
            catch (VideoRentalException vre)
            {
                MessageBox.Show(String.Format("{0}", vre.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex.Message));
            }
        }
        private void btnBookingTabReturn_Click(object sender, EventArgs e)
        {
            try
            {
                ff.BookingTabReturn(selectedVideoBooking, dtpBookingTab, tabIndexController);
            }
            catch (VideoRentalException vre)
            {
                MessageBox.Show(String.Format("{0}", vre.Message));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex.Message));
            }
        }
        #endregion

        #region Events
        private void ff_UpdateAndFillTabs()
        {
            /** Shows the number of updates and last updatetime for all tabs since program-start! */
            lblCurrentNrOfTabUpdates.Text = 
                String.Format("Tab Updates: {0}, Last Update: {1}", ff.NrOfUpdatesToTabs, DateTime.Now.ToString());
        }
        #endregion

        #region RadioButtons
        private void rdbDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDataBase.Checked)
            {
                /** New database assigned to booking! */
                booking = new Booking(_db);

                /** New booking assigned to FormFunctions! */
                ff.Booking = booking;

                try
                {
                    /** Update and Fill All Tabs! ( eventually calls the inherited event-method in FormFunctions, UpdateAndFillTabs() ) */
                    ff.UpdateAndFillAllTabs();
                    lblRentUsingDB.Text = "Using DataBase";
                }
                catch (VideoRentalException vre)
                {
                    MessageBox.Show(String.Format("{0}", vre.Message));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("{0}", ex.Message));
                }
            }
        }
        private void rdbTestDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTestDataBase.Checked)
            {
                /** New database assigned to booking! */
                booking = new Booking(_testdb);

                /** New booking assigned to FormFunctions! */
                ff.Booking = booking;

                try
                {
                    /** Update and Fill All Tabs! ( eventually calls the inherited event-method in FormFunctions, UpdateAndFillTabs() ) */
                    ff.UpdateAndFillAllTabs();
                    lblRentUsingDB.Text = "Using TestDataBase";
                }
                catch (VideoRentalException vre)
                {
                    MessageBox.Show(String.Format("{0}", vre.Message));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("{0}", ex.Message));
                }
            }
        }
        #endregion

        #region Obsolete
        private void lstRentTab_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboBookingVideoTitle_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pictBox_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        #endregion //TODO: Pls remove safely
    }
}
