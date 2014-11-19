using DataLayer.Classes;
using DataLayer.Exceptions;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CageNight.Classes
{
    internal sealed class FormFunctions : FormFunctionsBase
    {
        #region Variables and Properties

        internal int NrOfUpdatesToTabs { get { return NrOfUpdates; } }

        /** UI-controllers used by MaintenanceButtons! */
        private NumericUpDown updMainTabVideo;
        private TextBox txtMainTabCustomerFName;
        private TextBox txtMainTabCustomerLName;
        private TextBox txtMainTabGenre;

        /** Currently selected item in ComboBoxes ( returns null if theres no currently selected item! */
        internal Video MTSelectedVideo { get { return (Video)cboMainTabVideo.SelectedItem != null ? (Video)cboMainTabVideo.SelectedItem : null; } set { MTSelectedVideo = value; } }
        internal Genre MTSelectedVideoGenre { get { return (Genre)cboMainTabVideoGenre.SelectedItem != null ? (Genre)cboMainTabVideoGenre.SelectedItem : null; } set { MTSelectedVideoGenre = value; } }
        internal Customer MTSelectedCustomer { get { return (Customer)cboMainTabCustomer.SelectedItem != null ? (Customer)cboMainTabCustomer.SelectedItem : null; } set { MTSelectedCustomer = value; } }
        internal Genre MTSelectedGenre { get { return (Genre)cboMainTabGenre.SelectedItem != null ? (Genre)cboMainTabGenre.SelectedItem : null; } set { MTSelectedGenre = value; } }
        
        /** Property used for changing the booking-object during runtime by using interface-injection and using another database */
        internal IDataLayer Booking { get { return booking; } set { booking = value;  } }
        #endregion

        #region Constructor

        /** Get the booking-object as an IDataLayer for database-functions, also send in all relevant UI-controlls for update */
        public FormFunctions(IDataLayer booking, ComboBox cboMainTabVideo, ComboBox cboMainTabVideoGenre, ComboBox cboMainTabCustomer,
            ComboBox cboMainTabGenre, ComboBox cboRentTabCustomers, ListView bookingTabListView, ListView rentTabListView, TextBox txtMainTabVideo,
            
            /** MaintenanceTab specific fields, not parts of FormFunctionsBase */
            NumericUpDown updMainTabVideo, TextBox txtMainTabCustomerFName, TextBox txtMainTabCustomerLName, TextBox txtMainTabGenre)

            : base(booking, cboMainTabVideo, cboMainTabVideoGenre, cboMainTabCustomer, cboMainTabGenre, cboRentTabCustomers, bookingTabListView,
                       rentTabListView, txtMainTabVideo)
        {
            /** MaintenanceTab specific fields, not parts of FormFunctionsBase  */
            this.updMainTabVideo = updMainTabVideo;
            this.txtMainTabCustomerFName = txtMainTabCustomerFName;
            this.txtMainTabCustomerLName = txtMainTabCustomerLName;
            this.txtMainTabGenre = txtMainTabGenre;
        }

        #endregion Constructor

        #region FillTabs
        internal sealed override void UpdateAndFillMaintenaceTab()
        {
            try
            {
                base.UpdateAndFillMaintenaceTab();
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal sealed override void UpdateAndFillBookingsTab() 
        {
            try
            {
                base.UpdateAndFillBookingsTab();
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal sealed override void UpdateAndFillRentTab () 
        {
            try
            {
                base.UpdateAndFillRentTab();
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal sealed override void UpdateAndFillAllTabs()
        {
            try
            {
                base.UpdateAndFillAllTabs();
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MaintenanceButtons

        internal void AddItem(IItem item)
        {
            #region AddVideo
            if (item is Video)
            {
                if (txtMainTabVideo.Text != String.Empty)
                {
                    try
                    {
                        // Add a new video with properties from comboboxes and textfields from the UI with a unique VideoID
                        Video newVideo = new Video(MTSelectedVideoGenre.Id, false, txtMainTabVideo.Text, (int)updMainTabVideo.Value);

                        /** AddVideo is a success and datasource has Videos! */
                        if (booking.AddVideo(newVideo) && booking.VideoCount != 0)
                        {
                            // Clear the UI and refill tabs and comboboxes 
                            txtMainTabVideo.Clear();
                            FindAndSetNewlyAddedItemInComboBox(newVideo);

                            /** Need to set txtMainTabVideo to currently selected Video..
                             * ..since the SelectionChangeCommited-event does not apply the new name */
                            txtMainTabVideo.Text = MTSelectedVideo.Name;

                            MessageBox.Show(String.Format("{0} Successfully added to database!", newVideo.Name));
                        }
                    }
                    #region Catch VideoRentalException from AddVideo!
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }
                else MessageBox.Show("Cannot Add: Empty field!");
            }
            #endregion

            #region AddCustomer

            if (item is Customer)
            {
                /** If the TextBox has input! */
                if (txtMainTabCustomerFName.Text != String.Empty && txtMainTabCustomerLName.Text != String.Empty)
                {
                    try
                    {
                        /** Create a new Customer-objekt with unique ID and the passed in customerTitle */
                        Customer newCustomer = new Customer(txtMainTabCustomerFName.Text, txtMainTabCustomerLName.Text);

                        /** If Addcustomer was successfull and If the customerList NOW has items */
                        if (booking.AddCustomer(newCustomer) && booking.CustomerCount != 0)
                        {
                            /** Update all tabs and clear the TextBoxes! */
                            FindAndSetNewlyAddedItemInComboBox(newCustomer);

                            MessageBox.Show(String.Format("Successfully added customer {0}", newCustomer.Name));
                            return;
                        }
                    }
                    /** IF Addcustomer failed or FindAndSetNewlyAddedItem.. */
                    #region Catch
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }

                /** Invalid customer-name to add! */
                else MessageBox.Show(String.Format("Customer Name has empty field!"));
            }
            #endregion

            #region AddGenre

            if (item is Genre)
            {
                String genreToAdd = txtMainTabGenre.Text;

                /** If the TextBox has input! */
                if (genreToAdd != String.Empty)
                {
                    try
                    {
                        /** Create a new Genre-objekt with unique ID and the passed in GenreTitle */
                        Genre newGenre = new Genre(genreToAdd);
                        if (booking.AddGenre(newGenre) && booking.GenreCount != 0)
                        {
                            /** Update all tabs and clear the TextBox! */
                            txtMainTabGenre.Clear();
                            FindAndSetNewlyAddedItemInComboBox(newGenre);

                            MessageBox.Show(String.Format("Successfully added {0}", genreToAdd));
                            return;
                        }
                    }
                    #region IF AddGenre failed, catch the exception From Booking
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }
                else if (genreToAdd == String.Empty) MessageBox.Show(String.Format("GenreName has empty field!"));
            }
            #endregion

        }
        internal void UpdateItem(IItem item)
        {
            #region UpdateVideo

            if (item is Video)
            {
                String newVideoName = txtMainTabVideo.Text;
                try
                {
                    #region Get information from UI

                    /** Get the currently selected VideoGenreName, IF fail: display "Get Failed: GenreName"! */
                    var getOldGenreName = booking.GetGenre(MTSelectedVideo.GenreId, default(String), default(Genre)) != null ?
                                          booking.GetGenre(MTSelectedVideo.GenreId, default(String), default(Genre)).First().Name :
                                          "Get failed: GenreName";

                    /** Get the current NrOfDaysWOPenalty */
                    int getOldNrOfDaysWOPenalty = MTSelectedVideo.NrOfDaysWOPenalty;

                    /** Get the current VideoTitle */
                    String getOldVideoName = MTSelectedVideo.Name;

                    /** Get update-values from UI and create new Video-object! */
                    Video videoToUpdate = new Video( MTSelectedVideo.Id,
                                                     MTSelectedVideoGenre.Id,
                                                     MTSelectedVideo.bIsRented,
                                                     newVideoName,
                                                     Convert.ToInt32(updMainTabVideo.Value));
                    #endregion

                    /** Input-values ok? */
                    if (newVideoName != String.Empty && videoToUpdate.Name != "..empty!")
                    {
                        if (booking.UpdateVideo(videoToUpdate))
                        {
                            /** Clear the UI and set the newly updated Video in ComboBox! */
                            txtMainTabVideo.Clear();
                            FindAndSetNewlyAddedItemInComboBox(videoToUpdate);

                            /** Need to set txtMainTabVideo and cboMainTabVideoGenre to currently selected Video..
                             * ..since the SelectionChangeCommited-event does not trigger on .SelectedItem! */
                            txtMainTabVideo.Text = MTSelectedVideo.Name;
                            cboMainTabVideoGenre.SelectedItem =
                                booking.GetGenre(videoToUpdate.GenreId, default(String), default(Genre)) != null ?
                                booking.GetGenre(videoToUpdate.GenreId, default(String), default(Genre)).First() :
                                //Set item at index 0 to default if no Genre found for current Video!
                                ((Genre)cboMainTabVideoGenre.Items[0]); 

                            /** Display update-information! */
                            MessageBox.Show(
                                String.Format("VideoUpdate successfull!\nOLDVideo: {0}  : {1}, NrOfDaysWOPenalty: {2}\nNEWVideo: {3} : {4}, NrOfDayWOPenalty: {5}",

                                /** Display OLD information! */
                                getOldVideoName,
                                getOldGenreName,
                                getOldNrOfDaysWOPenalty,

                                /** Display NEW information! */
                                videoToUpdate.Name,

                                booking.GetGenre(videoToUpdate.GenreId, default(String), default(Genre)) != null ? 
                                booking.GetGenre(videoToUpdate.GenreId, default(String), default(Genre)).First().Name : 
                                null,

                                videoToUpdate.NrOfDaysWOPenalty
                                ));

                            return;
                        }
                    }
                    else MessageBox.Show("Cannot Update - Empty Field");
                }
                #region Catch
                catch (VideoRentalException vre)
                {
                    MessageBox.Show(String.Format("Could not update video: \n{0} !!", vre.Message));
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(String.Format("Could not update video: \n{0} !!", ex.Message));
                }
                #endregion
            }
            #endregion

            #region UpdateCustomer

            if (item is Customer)
            {
                try
                {
                    #region Get and Set FName & LName

                    String newCustomerFName = txtMainTabCustomerFName.Text;
                    String newCustomerLName = txtMainTabCustomerLName.Text;

                    StringBuilder sBnewCustomerName = new StringBuilder(txtMainTabCustomerFName.Text);
                    sBnewCustomerName.Append(" ");
                    sBnewCustomerName.Append(txtMainTabCustomerLName.Text);

                    string newCustomerName = sBnewCustomerName.ToString();
                    string oldCustomerName = MTSelectedCustomer.Name;
                    Customer customerToUpdate = MTSelectedCustomer;

                    #endregion

                    /** If the TextBox has input and If the ComboBox has a valid Customer selected! */
                    if (newCustomerName.ToString() != String.Empty && customerToUpdate.Name != "..empty!")
                    {
                        Customer newCustomer = new Customer(customerToUpdate.Id, newCustomerFName, newCustomerLName);
                        /** If UpdateCustomer was successfull! */
                        if (booking.UpdateCustomer(newCustomer))
                        {
                            /** Clear the UI and set the newly selected Customer! */
                            txtMainTabCustomerFName.Clear();
                            txtMainTabCustomerLName.Clear();
                            FindAndSetNewlyAddedItemInComboBox(newCustomer);

                            MessageBox.Show(String.Format("Customer {0} \nUpdated to: {1}.", oldCustomerName, customerToUpdate.Name));
                            return;
                        }
                    }
                }
                #region Catch
                catch (VideoRentalException vre)
                {
                    MessageBox.Show(String.Format("Could not update customer: \n{0} !!", vre.Message));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Exception: \n{0} !!", ex.Message));
                }
                #endregion
            }
            #endregion

            #region UpdateGenre

            if (item is Genre)
            {
                try
                {
                    Genre genreToUpdate = MTSelectedGenre;
                    String newGenreName = txtMainTabGenre.Text;
                    String genreToUpdateName = genreToUpdate.Name;

                    /** If the TextBox has input and If the ComboBox has a valid Genre selected! */
                    if (newGenreName != String.Empty && genreToUpdate.Name != "..empty!")
                    {
                        Genre newGenre = new Genre(genreToUpdate.Id, newGenreName);
                        if (booking.UpdateGenre(newGenre))
                        {
                            /** Clear the TextBox and update all tabs! */
                            txtMainTabGenre.Clear();
                            FindAndSetNewlyAddedItemInComboBox(newGenre);

                            MessageBox.Show(String.Format("Successfully updated {0} to {1}!", genreToUpdateName, newGenreName));
                            return;
                        }
                    }
                    MessageBox.Show(String.Format("Invalid input when updating!"));
                }

                #region IF UpdateGenre failed, catch the exception From Booking
                catch (VideoRentalException vre)
                {
                    MessageBox.Show(String.Format("Could not update genre: \n{0} !!", vre.Message));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Exception: \n{0} !!", ex.Message));
                }
                #endregion
            }
            #endregion
        }
        internal void DeleteItem(IItem item)
        {
            #region DeleteVideo

            if (item is Video)
            {
                Video videoToDelete = (Video)item;
                if (videoToDelete.Name != "..empty!")
                {
                    try
                    {
                        //if successfully removed the video
                        if (booking.DeleteVideo(videoToDelete))
                            MessageBox.Show(String.Format("Successfully removed Video: {0}", videoToDelete.Name));

                        //update the tabs and comboboxes
                        UpdateAndFillAllTabs();

                        /** Select the last index in ComboBoxlist! */
                        cboMainTabVideo.SelectedIndex = cboMainTabVideo.Items.Count - 1;

                        txtMainTabVideo.Text = MTSelectedVideo.Name;
                        return;
                    }

                    #region Catch VideoRentalException from DeleteVideo
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }
                else MessageBox.Show(String.Format("Cannot Delete: Empty field!"));
            }
            #endregion

            #region DeleteCustomer
            if (item is Customer)
            {
                Customer customerToDelete = MTSelectedCustomer;
                string customerToDeleteName = customerToDelete.Name;

                /** If the ComboBox has a valid Customer Selected! */
                if (customerToDelete.Name != "..empty!")
                {
                    try
                    {
                        /** IF delete was successfull! */
                        if (booking.DeleteCustomer(customerToDelete))
                        {
                            /** Update all tabs and clear the TextBox! */
                            UpdateAndFillAllTabs();
                            txtMainTabCustomerFName.Clear();
                            txtMainTabCustomerLName.Clear();

                            /** Select the last item in ComboBox to avoid "..empty!" item!*/
                            cboMainTabCustomer.SelectedIndex = cboMainTabCustomer.Items.Count - 1;

                            MessageBox.Show(String.Format("Successfully deleted {0}!", customerToDeleteName));
                            return;
                        }
                    }
                    /** IF delete failed, catch the exception-message from Booking */
                    #region Catch
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }

                /** Invalid Customer-selected! */
                else if (customerToDelete.Name == "..empty!")
                    MessageBox.Show(String.Format("Unable to delete customer: {0}", customerToDelete.Name));
            }
            #endregion

            #region DeleteGenre
            if (item is Genre)
            {
                /** Save the deleted Genrename! */
                String genreToDeleteName = MTSelectedGenre.Name;

                /** If the ComboBox has a valid Genre Selected! */
                if (MTSelectedGenre.Name != "..empty!")
                {
                    try
                    {
                        /** IF delete was successfull! */
                        if (booking.DeleteGenre(MTSelectedGenre))
                        {
                            /** Update all tabs and clear the TextBox! */
                            UpdateAndFillAllTabs();
                            txtMainTabGenre.Clear();

                            /** Select the last item in ComboBox to avoid "..empty!" item!*/
                            cboMainTabGenre.SelectedIndex = cboMainTabVideoGenre.Items.Count - 1;
                            MessageBox.Show(String.Format("Successfully deleted genre: {0}", genreToDeleteName));
                            return;
                        }
                    }
                    #region IF delete failed, catch the exception-message from Booking */
                    catch (VideoRentalException vre)
                    {
                        MessageBox.Show(String.Format("{0}", vre.Message));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("{0}", ex.Message));
                    }
                    #endregion
                }
                else if (MTSelectedGenre.Name == "..empty!") MessageBox.Show(String.Format("Unable to delete genre: {0}", MTSelectedGenre.Name));
            }
            #endregion
        }

        /** Helperfunctions to Add, Update and Delete -item functions. */
        private void FindAndSetNewlyAddedItemInComboBox(IItem item)
        {
            try
            {
                /** Always update and fill all tabs! */
                UpdateAndFillAllTabs();

                #region Video
                if (item is Video)
                {
                    /** Get the newly added Video by it's Name-property in the VideoCollection! */
                    List<Video> videolist = booking.GetVideoCollection().ToList();
                    int index = 0;
                    for (int i = 0; i < videolist.Count; i++)
                    {
                        if (videolist[i].Name == ((Video)item).Name)
                        {
                            index = i;
                            break;
                        }
                    }

                    /** Select the newly added Video */
                    cboMainTabVideo.SelectedIndex = index;
                }
                #endregion

                #region Customer

                if (item is Customer)
                {
                    /** Get the new CustomerList */
                    List<Customer> customerlist = booking.GetCustomerCollection().ToList();
                    int index = 0;
                    for (int i = 0; i < customerlist.Count; i++)
                    {
                        if (customerlist[i].Name.Equals(((Customer)item).Name))
                        {
                            index = i;
                            break;
                        }
                    }

                    /** Select the newly added Customer in ComboBox-list */
                    cboMainTabCustomer.SelectedIndex = index;
                }
                #endregion

                #region Genre

                if (item is Genre)
                {
                    /** Get the new GenreList */
                    List<Genre> genrelist = booking.GetGenreCollection().ToList();
                    int index = 0;
                    for (int i = 0; i < genrelist.Count; i++)
                    {
                        if (genrelist[i].Name.Equals(((Genre)item).Name))
                        {
                            index = i;
                            break;
                        }
                    }

                    /** Select the newly added Genre in ComboBox-list */
                    cboMainTabGenre.SelectedIndex = index;
                }
                #endregion

            }
            catch (IndexOutOfRangeException ex)
            {
                throw new VideoRentalException(item, String.Format("\n{0} out of range in FindAndSetNewlyAddedItem.., check index! \n{1}", item.Name, ex.Message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Rent and Booking-tab updating and sorting by column!

        internal sealed override void RentTabListSorting (int columnIndex) 
        {
            try
            {
                base.RentTabListSorting(columnIndex);
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /** Eriks custom-implementation of BookingTabListSorting!
         *  Overrides the FormFunctionsBase.BookingTabListSorting() -method! 
         *  This method is used in conjunction with Eriks custom-implementation of UpdateAndSortBookingsListView */
        internal sealed override void BookingTabListSorting(int columnIndex)
        {
            try
            {
                #region Sort by columnindex from ListView columns!

                switch (columnIndex)
                {
                    case (int)BookingTabListViewColumnIndex.BookingName:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.BookingName);
                        break;

                    case (int)BookingTabListViewColumnIndex.CustomerName:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.CustomerName);
                        break;

                    case (int)BookingTabListViewColumnIndex.VideoTitle:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.VideoTitle);
                        break;

                    case (int)BookingTabListViewColumnIndex.RentDate:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.RentDate);
                        break;

                    case (int)BookingTabListViewColumnIndex.ReturnedDate:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.ReturnedDate);
                        break;

                    case (int)BookingTabListViewColumnIndex.Cost:
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.Cost);
                        break;
                }

                #endregion
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /** Custom Implementation of Eriks sortingmethod! */
        internal sealed override void UpdateAndSortBookingsListView(BookingTabListViewColumnSorting sortingBy)
        {
            try
            {
                #region Clear ListView and check for empty datasource!
                /** Clear bookings ListView */
                bookingTabListView.Items.Clear();

                IEnumerable<VideoBooking> bookings = null;
                IEnumerable<Video> videoList = null;
                IEnumerable<Customer> customerList = null;

                /** Check if there are bookings in the datasource! */
                if (booking.VideoBookingCount != 0)
                    bookings = booking.GetVideoBookingCollection();
                else
                    /** Set bookings as an empty Enum */
                    bookings = Enumerable.Empty<VideoBooking>();

                /** Check if there are videos in the datasource */
                if (booking.VideoCount != 0)
                    videoList = booking.GetVideoCollection();
                else
                    throw new VideoRentalException("Videos missing in database.");

                /** Check if there are customers in the datasource! */
                if (booking.CustomerCount != 0)
                    customerList = booking.GetCustomerCollection();
                else
                    throw new VideoRentalException("Customers missing in database.");

                #endregion

                /** QueryForSortedBookings is used to hold the sorted bookings-list */
                IEnumerable<VideoBooking> queryForSortedBookings = null;

                if (bookings != null)
                {
                    #region Sortby property: Ascending or Descending depending on what bookingClickOneTwo is set as ( true or false )

                    /** Sortby property: Ascending or Descending depending on what bookingClickOneTwo is set as ( true or false ) */
                    switch (sortingBy)
                    {
                        case BookingTabListViewColumnSorting.BookingName:
                            #region SortyBy: BookingTabListViewColumnSorting.BookingName

                            /** Sort by BookingName Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.Name ascending
                                    select b;
                            }

                            /** Sort by BookingName Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.Name descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.VideoTitle:
                            #region SortBy: BookingTabListViewColumnSorting.VideoTitle

                            /** Sort by VideoName Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    join v in videoList
                                        on b.VideoID equals v.Id
                                    orderby v.Name ascending
                                    select b;
                            }

                            /** Sort by VideoName Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    join v in videoList
                                        on b.VideoID equals v.Id
                                    orderby v.Name descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.CustomerName:
                            #region SortyBy: BookingTabListViewColumnSorting.CustomerName:

                            /** Sort by CustomerName Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    join c in customerList
                                        on b.CustomerID equals c.Id
                                    orderby c.Name ascending
                                    select b;
                            }

                            /** Sort by CustomerName Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    join c in customerList
                                        on b.CustomerID equals c.Id
                                    orderby c.Name descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.RentDate:
                            #region SortyBy: BookingTabListViewColumnSorting.RentDate:

                            /** Sort by RentDate Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.RentDate ascending
                                    select b;
                            }

                            /** Sort by RentDate Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.RentDate descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.ReturnedDate:
                            #region SortyBy: BookingTabListViewColumnSorting.ReturnedDate

                            /** Sort by ReturnDate Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.ReturnedDate ascending
                                    select b;
                            }

                            /** Sort by ReturnedDate Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.ReturnedDate descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.Cost:
                            #region SortyBy: BookingTabListViewColumnSorting.Cost:

                            /** Sort by Cost Ascending */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.Cost ascending
                                    select b;
                            }

                            /** Sort by Cost Descending */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in bookings
                                    orderby b.Cost descending
                                    select b;
                            }
                            break;
                            #endregion
                    }
                    #endregion

                    /** Create the Booking ListView by using the inherited method from FormFunctionsBase */
                    CreateBookingListView(queryForSortedBookings);
                }
                else
                    throw new VideoRentalException("Bookingslist is empty!");
            }
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Rent & Return
        internal sealed override void BookingTabReturn(int? selectedVideoBooking, DateTimePicker dtpBookingTab, TabControl tabIndexController)
        {
            try
            {
                base.BookingTabReturn(selectedVideoBooking, dtpBookingTab, tabIndexController);
            }
            #region Catch
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        internal sealed override void RentTabRent(int? selectedFilm, Customer selectedCustomer, TabControl tabIndexController )
        {
            try
            {
                base.RentTabRent(selectedFilm, selectedCustomer, tabIndexController);
            }
            #region Catch
            catch (VideoRentalException vre)
            {
                throw vre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        #endregion
    }
}
