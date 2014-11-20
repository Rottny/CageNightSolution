using DataLayer.Classes;
using DataLayer.Interface;
using CageNight.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Exceptions;

namespace CageNight.Classes
{
    internal abstract class FormFunctionsBase
    {
        #region Variables, ComboBoxes, ListViews, TextBoxes, Events

        protected bool rentbClickOneTwo;
        protected bool bookingbClickOneTwo;

        protected IDataLayer booking;

        protected ComboBox cboMainTabVideo; 
        protected ComboBox cboMainTabVideoGenre;
        protected ComboBox cboMainTabCustomer;
        protected ComboBox cboMainTabGenre;

        protected ComboBox cboRentTabCustomers;
        
        protected ListView bookingTabListView;
        protected ListView rentTabListView;

        protected TextBox txtMainTabVideo;

        protected int NrOfUpdates = 0;

        public delegate void UpdateAndFillTabsHandler();
        public event UpdateAndFillTabsHandler UpdateAndFillTabs;

        #endregion

        #region Constructor

        public FormFunctionsBase(  IDataLayer booking, ComboBox cboMainTabVideo, ComboBox cboMainTabVideoGenre, ComboBox cboMainTabCustomer,
                                   ComboBox cboMainTabGenre, ComboBox cboRentTabCustomers, ListView bookingTabListView, ListView rentTabListView,
                                   TextBox txtMainTabVideo)
        {
            /** Booking from Form1 */
            this.booking = booking;

            /** MaintenanceTab ComboBoxes */
            this.cboMainTabVideo = cboMainTabVideo;
            this.cboMainTabVideoGenre = cboMainTabVideoGenre;
            this.cboMainTabCustomer = cboMainTabCustomer;
            this.cboMainTabGenre = cboMainTabGenre;
            this.cboRentTabCustomers = cboRentTabCustomers;
            /** MaintenanceTab ComboBoxes */
            
            /** BookingTab and RentTabs ListViews */
            this.bookingTabListView = bookingTabListView;
            this.rentTabListView = rentTabListView;

            /** MaintenanceTab VideoTitle TextBox */
            this.txtMainTabVideo = txtMainTabVideo;

            /** Set default true for ListView-sorting during the first update */
            rentbClickOneTwo = true;
            bookingbClickOneTwo = true;

            /** Subscribe to the UpdateAndFillTabs-Event! */
            UpdateAndFillTabs += FormFunctionsBase_UpdateAndFillTabs;
        }
        #endregion

        #region Events, UpdateAndFillAllTabs!

        /** UpdateAndFillAllTabs-method used by the UpdateAndFillTabs-event! */
        internal void FormFunctionsBase_UpdateAndFillTabs()
        {
            try
            {
                /** Update the total number of updates to the UI since program start, NrOfUpdates starts at 0! */
                NrOfUpdates++;

                UpdateAndFillMaintenaceTab();
                UpdateAndFillBookingsTab();
                UpdateAndFillRentTab();
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

        #region Update and fill tabs
        internal virtual void UpdateAndFillMaintenaceTab() 
        {
            try
            {
                /** Clear old data from ComboBoxes */
                cboMainTabVideo.Items.Clear();
                cboMainTabVideoGenre.Items.Clear();
                cboMainTabCustomer.Items.Clear();
                cboMainTabGenre.Items.Clear();

                List<Video> videoList = null;
                List<Customer> customerList = null;
                List<Genre> genreList = null;
            
                /** Add new data to ComboBoxes*/
                #region Videos

                /** Check that Videos are not empty! */
                if (booking.VideoCount != 0) 
                {
                    /** Get the list */
                    videoList = booking.GetVideoCollection().ToList();
                    
                    /** Add data to ComboBox */
                    foreach (Video video in videoList)
                    {
                        cboMainTabVideo.Items.Add(video);
                    }
                    cboMainTabVideo.SelectedIndex = 0;
                }

                /** If Videos are empty, add "..empty!" to Videos */
                else if (booking.VideoCount == 0)
                {
                    cboMainTabVideo.Items.Add(new Video(Guid.Empty, Guid.Empty, false, "..empty!", 0));

                    /** Select the "..empty!" - Video in ComboBox */
                    cboMainTabVideo.SelectedIndex = 0;
                }
                #endregion

                #region Customers

                /** Check that Customers are not empty! */
                if (booking.CustomerCount != 0)
                {
                    /** Get the list */
                    customerList = booking.GetCustomerCollection().ToList();

                    /** Add data to ComboBox */
                    foreach (Customer customer in customerList)
                    {
                        cboMainTabCustomer.Items.Add(customer);
                    }

                    /** Set a default item */
                    cboMainTabCustomer.SelectedIndex = 0;
                }

                /** If Customers are empty, add "..empty!" to Customers */
                else if (booking.CustomerCount == 0)
                {
                    cboMainTabCustomer.Items.Add(new Customer(Guid.Empty, "..empty!", ""));

                    /** Select the "..empty!" - Customer in ComboBox */
                    cboMainTabCustomer.SelectedIndex = 0;
                }
                #endregion

                #region Genres

                /** Check that Genres is not empty! */
                if (booking.GenreCount != 0) 
                {
                    /** Get the list */
                    genreList = booking.GetGenreCollection().ToList();

                    /** Add data to ComboBoxes */
                    foreach (Genre genre in genreList)
                    {
                        cboMainTabGenre.Items.Add(genre);
                        cboMainTabVideoGenre.Items.Add(genre);
                    }
                    
                    /** Set a default item */
                    cboMainTabGenre.SelectedIndex = 0;
                }

                 /** If Genres are empty, add "..empty!" to Genres */
                else if (booking.GenreCount == 0)
                {
                    cboMainTabGenre.Items.Add(new Genre(Guid.Empty, "..empty!"));

                    /** Select the "..empty!" - Genre in ComboBox */
                    cboMainTabGenre.SelectedIndex = 0;
                    cboMainTabVideoGenre.SelectedIndex = 0;
                }
                #endregion

                #region Select default Video and associated Genre

                Video selectedVideo = (Video)cboMainTabVideo.SelectedItem;

                /** Video & Genres contains items and first item in list IS NOT "..empty!" */
                if (booking.VideoCount != 0 && booking.GenreCount != 0 && selectedVideo.Name != "..empty!" )
                {
                    /** Set Genre and VideoTitle (Grouping Videos) */
                    cboMainTabVideoGenre.SelectedItem = booking.GetGenre(selectedVideo.GenreId, default(String), default(Genre)).First();
                    txtMainTabVideo.Text = booking.GetVideo(selectedVideo.Id, default(String), default(Video)).First().Name;
                    return;
                }

                /** Video & Genres contains items and first item in list IS "..empty!" */
                else if (booking.VideoCount != 0 && booking.GenreCount != 0 && selectedVideo.Name == "..empty!")
                {
                    /** Select first item as default! */
                    cboMainTabVideo.SelectedIndex = 0;
                    cboMainTabGenre.SelectedIndex = 0;

                    txtMainTabVideo.Text = "..empty!";
                    return;
                }

                #endregion

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
        internal virtual void UpdateAndFillBookingsTab()
        {
            try
            {
                /** Update and sort BookingsList on BookingName as default */
                UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.BookingName);

                #region Set ListView properties and hide columns using the ColumnWidthChanging-Event!

                /** ListView properties */
                bookingTabListView.HideSelection = false;
                bookingTabListView.View = View.Details;
                bookingTabListView.FullRowSelect = true;
                bookingTabListView.MultiSelect = false;

                /** Auto-resize for the column-contents size. Important that it is executed in this order for the .View-proprty to work fine. */
                bookingTabListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                /** Increase the width of VideoTitle and Cost-column. */
                bookingTabListView.Columns[Convert.ToInt32(BookingTabListViewColumnIndex.VideoTitle)].Width = 100;
                bookingTabListView.Columns[Convert.ToInt32(BookingTabListViewColumnIndex.Cost)].Width = 100;

                /** Hide column with index 0 that holds the VideoBookingID in Booking-Tabs ListView. */
                bookingTabListView.Columns[Convert.ToInt32(BookingTabListViewColumnIndex.BookingID)].Width = 0;
                bookingTabListView.ColumnWidthChanging += bookingTabListView_ColumnWidthChanging;
                #endregion
            }
            catch (VideoRentalException)
            {
                /** UpdateAndSortBookingsListView throws a VideoRentalException if ListView is empty..
                 * ..that we ignore and add an item to the the Bookings ListView with the string "EMPTY LIST!" */
                bookingTabListView.Items.Add(new ListViewItem(new string[7] { "EMPTY LIST!", "EMPTY LIST!", "EMPTY LIST!", "EMPTY LIST!",
                                                                              "EMPTY LIST!", "EMPTY LIST!", "EMPTY LIST!" } ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal virtual void UpdateAndFillRentTab() 
        {
            try
            {
                #region Remove old data, Update and set properties for ListView and hide VideoID-column with the ColumnWidthChanging-event!
                
                /** Sort Rents ListView by default on bIsRented! */
                UpdateAndSortRentListView ( RentTabListViewColumnSorting.bIsRented );

                /** RentTabs ListView properties */
                rentTabListView.HideSelection = false;
                rentTabListView.View = View.Details;
                rentTabListView.FullRowSelect = true;
                rentTabListView.MultiSelect = false;

                /** AutoResize for the ListView columns on ColumnContent. 
                    IMPORTANT that this is the order after the ListView.View propery!! */
                rentTabListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                /** Increase the size for the last column, AllowedDaysWOPenalty! */
                rentTabListView.Columns[Convert.ToInt32(RentTabListViewColumnIndex.AllowedDaysWOPenalty)].Width = 100;

                /** Hide ListView column with index 0 that contains VideoID */
                rentTabListView.Columns[Convert.ToInt32(RentTabListViewColumnIndex.VideoID)].Width = 0;
                rentTabListView.ColumnWidthChanging += rentTabListView_ColumnWidthChanging;

                #endregion

                #region ComboBox for Customers 

                /** Combobox for Customers */
                List<Customer> customerList = new List<Customer>();
                customerList = booking.GetCustomerCollection() != null ? booking.GetCustomerCollection().ToList<Customer>() : null;
                
                cboRentTabCustomers.Items.Clear();
                if (customerList != null)
                {
                    foreach (Customer c in customerList)
                    {
                        cboRentTabCustomers.Items.Add(c);
                    }
                }
                else cboRentTabCustomers.Items.Add(new Customer(Guid.Empty, "list empty!", ""));

                /** Select index 0 for Customers ComboBox */
                cboRentTabCustomers.SelectedIndex = 0;

                /** RentTab Customers ComboBox */
                cboRentTabCustomers.DisplayMember = "Name";

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
        internal virtual void UpdateAndFillAllTabs()
        {
            try
            {
                /** Check if we subscribe to the event ( NOT null! ) */
                if (UpdateAndFillTabs != null)
                    UpdateAndFillTabs();

                else throw new VideoRentalException(String.Format("No subscription to UpdateAndFillTabs-event i FormFunctionsBase!!")); 
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

        #region RentTab
        internal virtual void RentTabListSorting ( int columnIndex )
        {
            try
            {
                #region Sorts the RentList depending on the ColumnIndex klicked!

                switch (columnIndex)
                {
                    case 1: // RentTabListViewColumnIndex.Film
                        ListViewClickOneTwo(ref rentbClickOneTwo);
                        UpdateAndSortRentListView(RentTabListViewColumnSorting.Name);
                        break;

                    case 2: //RentTabListViewColumnIndex.Genre
                        ListViewClickOneTwo(ref rentbClickOneTwo);
                        UpdateAndSortRentListView(RentTabListViewColumnSorting.Genre);
                        break;

                    case 3: //RentTabListViewColumnIndex.bIsRented
                        ListViewClickOneTwo(ref rentbClickOneTwo);
                        UpdateAndSortRentListView(RentTabListViewColumnSorting.bIsRented);
                        break;

                    case 4: //RentTabListViewColumnIndex.NrOfDaysWOPenalty
                        ListViewClickOneTwo(ref rentbClickOneTwo);
                        UpdateAndSortRentListView(RentTabListViewColumnSorting.NrOfDaysWOPenalty);
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
        internal virtual void UpdateAndSortRentListView ( RentTabListViewColumnSorting sortingBy  )
        {
            try
            {
                rentTabListView.Items.Clear();

                IEnumerable<Video> films = booking.GetVideoCollection();
                IEnumerable<Video> queryForSortedFilms = null;

                switch (sortingBy)
                {
                    case RentTabListViewColumnSorting.Name:
                        #region SortyBy: RentTabListViewColumnSorting.Name
                        if (rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.Name descending
                                select f;
                        }
                        else if (!rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.Name ascending
                                select f;
                        }
                        break;
                        #endregion

                    case RentTabListViewColumnSorting.Genre:
                        #region SortBy: RentTabListViewColumnSorting.Genre
                        if (rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.GenreId descending
                                select f;
                        }
                        else if (!rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.GenreId ascending
                                select f;
                        }
                        break;
                        #endregion

                    case RentTabListViewColumnSorting.bIsRented:
                        #region SortyBy: RentTabListViewColumnSorting.bIsRented
                        if (rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.bIsRented descending
                                select f;
                        }
                        else if (!rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.bIsRented ascending
                                select f;
                        }
                        break;
                        #endregion

                    case RentTabListViewColumnSorting.NrOfDaysWOPenalty:
                        #region SortyBy: RentTabListViewColumnSorting.NrOfDaysWOPenalty
                        if (rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.NrOfDaysWOPenalty descending
                                select f;
                        }
                        else if (!rentbClickOneTwo)
                        {
                            queryForSortedFilms =
                                from f in films
                                orderby f.NrOfDaysWOPenalty ascending
                                select f;
                        }
                        break;
                        #endregion
                }
                CreateRentListView(queryForSortedFilms);
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
        protected void CreateRentListView(IEnumerable<Video> queryForSortedFilms)
        {
            if (queryForSortedFilms != null)
            {
                List<Video> filmList = queryForSortedFilms.ToList();

                #region Create the temporary String-array holding all the property-values for the new ListView-item

                /** Create the temporary String-array holding all the property-values for the new ListView-item */
                for (int i = 0; i < filmList.Count; i++)
                {
                    string[] tmpString = new string[5];
                    tmpString[0] = filmList[i].Id.ToString();
                    tmpString[1] = filmList[i].Name;
                    tmpString[2] = booking.GetGenre(filmList[i].GenreId, default(String), default(Genre)).First().Name;
                    tmpString[3] = filmList[i].bIsRented == true ? "Rented Out!" : "Available!";
                    tmpString[4] = filmList[i].NrOfDaysWOPenalty.ToString();

                    /** Add and create a new ListView-item */
                    rentTabListView.Items.Add(new ListViewItem(tmpString));
                }

                #endregion
            }
            else throw new VideoRentalException("Could not the ListView from datasource! (FormFunctions.CreateRentListView)");
        }
        #endregion

        #region BookingTab
        internal virtual void BookingTabListSorting ( int columnIndex )
        {
            try
            {
                switch (columnIndex)
                {
                    #region Sorts the BookingList depending on the ColumnIndex klicked!

                    case 1: //BookingTabListViewColumnSorting.BookingName
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.BookingName);
                        break;

                    case 2: //BookingTabListViewColumnSorting.VideoTitle
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.VideoTitle);
                        break;

                    case 3: //BookingTabListViewColumnSorting.CustomerName
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.CustomerName);
                        break;

                    case 4: //BookingTabListViewColumnSorting.RentDate
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.RentDate);
                        break;

                    case 5: //BookingTabListViewColumnSorting.ReturnedDate
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.ReturnedDate);
                        break;

                    case 6: //BookingTabListViewColumnSorting.Cost
                        ListViewClickOneTwo(ref bookingbClickOneTwo);
                        UpdateAndSortBookingsListView(BookingTabListViewColumnSorting.Cost);
                        break;

                    #endregion
                }
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

        /** Eriks custom sorting-implementation, is Overridden in FormFunctions */
        internal virtual void UpdateAndSortBookingsListView ( BookingTabListViewColumnSorting sortingBy )
        {
            try
            {
                bookingTabListView.Items.Clear();

                IEnumerable<VideoBooking> getVideoBookings = null;
                IEnumerable<VideoBooking> queryForSortedBookings = null;

                /** Check if there are Bookings in the datasource */
                if (booking.VideoBookingCount != 0)
                {
                    /** Get the Booking collection as a IEnumerable for further LinQ-queries. Throws a VideoRentalException if datasource is empty! */
                    getVideoBookings = booking.GetVideoBookingCollection();

                    #region Sort by the BookingTabListViewColumnSorting enum

                    /** Sort by the BookingTabListViewColumnSorting enum */
                    switch (sortingBy)
                    {
                        case BookingTabListViewColumnSorting.BookingName:
                            #region SortyBy: BookingTabListViewColumnSorting.BookingName

                            /** Sort the ListView by ascending booking-Name */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.Name ascending
                                    select b;
                            }

                            /** Sort the ListView by descending booking-name */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.Name descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.VideoTitle:
                            #region SortBy: BookingTabListViewColumnSorting.VideoTitle

                            /** Sort the ListView by ascending Video-ID ( also video Name ) */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.VideoID ascending
                                    select b;
                            }

                            /** Sort the ListView by descending Video-ID ( also video Name ) */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.VideoID descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.CustomerName:
                            #region SortyBy: BookingTabListViewColumnSorting.CustomerName:

                            /** Sort the ListView by ascending Customer-ID ( also customer Name ) */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.CustomerID ascending
                                    select b;
                            }

                            /** Sort the ListView by descending Customer-ID ( also video Name ) */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.CustomerID descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.RentDate:
                            #region SortyBy: BookingTabListViewColumnSorting.RentDate:

                            /** Sort the ListView by ascending RentDate */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.RentDate ascending
                                    select b;
                            }

                            /** Sort the ListView by descending RentDate */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.RentDate descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.ReturnedDate:
                            #region SortyBy: BookingTabListViewColumnSorting.ReturnedDate

                            /** Sort the ListView by ascending ReturnedDate */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.ReturnedDate ascending
                                    select b;
                            }

                            /** Sort the ListView by descending ReturnedDate */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.ReturnedDate descending
                                    select b;
                            }
                            break;
                            #endregion

                        case BookingTabListViewColumnSorting.Cost:
                            #region SortyBy: BookingTabListViewColumnSorting.Cost:

                            /** Sort the ListView by ascending Cost */
                            if (bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.Cost ascending
                                    select b;
                            }

                            /** Sort the ListView by descending Cost */
                            else if (!bookingbClickOneTwo)
                            {
                                queryForSortedBookings =
                                    from b in getVideoBookings
                                    orderby b.Cost descending
                                    select b;
                            }
                            break;
                            #endregion
                    }

                    #endregion

                    /** Create each ListView-item from a String-array holding all the columns/properties */
                    CreateBookingListView(queryForSortedBookings);
                }
                /** BookingList is empty! */
                else throw new VideoRentalException("Bookingslist is empty!");
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
        protected void CreateBookingListView( IEnumerable<VideoBooking> queryForSortedBookings  )
        {

            /** LinQ-query from UpdateAndSortBOokingsListView that is to be created as a list of ListView-items*/
            if (queryForSortedBookings != null)
            {
                bookingTabListView.Items.Clear();

                List<VideoBooking> bookingList = queryForSortedBookings.ToList();

                #region Create the temporary String-array holding all the property-values for the new ListView-item

                /** Create the temporary String-array holding all the property-values for the new ListView-item */
                for (int i = 0; i < bookingList.Count; i++)
                {
                    string[] tmpString = new string[7];
                    tmpString[0] = bookingList[i].Id.ToString();
                    tmpString[1] = bookingList[i].Name;
                    tmpString[2] = booking.GetCustomer(bookingList[i].CustomerID, default(String), default(Customer)).First().Name;
                    tmpString[3] = booking.GetVideo(bookingList[i].VideoID, default(String), default(Video)).First().Name;
                    tmpString[4] = bookingList[i].RentDate.ToString();
                    tmpString[5] = bookingList[i].ReturnedDate.Equals(DateTime.MinValue) ? "Not Returned" : bookingList[i].ReturnedDate.ToString();
                    tmpString[6] = bookingList[i].Cost.ToString();

                    /** Add and create a new ListView-item */
                    bookingTabListView.Items.Add(new ListViewItem(tmpString));
                }

                #endregion
            }
            else throw new VideoRentalException("Could not fill the ListView from datasource! FormFunctions.CreateBookingListView!");
        }
        #endregion

        #region Helperfunctions
        protected void ListViewClickOneTwo( ref bool clickOneTwo ) 
        {
            /** Set true or false, sets how a ListView is sorted, Ascending or Descending */
            bool? oldState = null;
            if (!clickOneTwo)
            {
                oldState = clickOneTwo;
                clickOneTwo = true;
            }
            if (clickOneTwo && oldState == null)
            {
                oldState = clickOneTwo;
                clickOneTwo = false;
            }
        }
        protected void bookingTabListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //Hide VideoBookingID on the BookingTab
            if (e.ColumnIndex == Convert.ToInt32(BookingTabListViewColumnIndex.BookingID))
            {
                //Sets the new width of the column to 0
                e.NewWidth = 0;    

                //Cancels the event, disabling it.
                e.Cancel = true;   
            }
        }
        protected void rentTabListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //Hide VideoID on the RentTab
            if (e.ColumnIndex == Convert.ToInt32(RentTabListViewColumnIndex.VideoID))
            {
                //Sets the new width of the column to 0
                e.NewWidth = 0;

                //Cancels the event, disabling it.
                e.Cancel = true;  
            }
        }
        #endregion

        #region Rent & Return
        /******************* RETURNVIDEO ******************************************************************************
            * ReturnVideo checks if the string from the ListView is valid, IF so..
            * ..it takes the VideoBooking-objects ID and checks if it exists in the datasource.
            * It then creates a VideoBooking-object from the Booking-tab.
            * The VideoBooking-object contains all the nescessary information required for returning a booking.
            * ( This object is created through the second constructor in the VideoBooking-class )
            * 
            * 1. Guid videoBookingId.
            * 2. Guid videoID
            * 3. Guid customerID
            * 4. DateTime rentDate
            * 5. DateTime returnedDate ( from the DateTimePicker-control in the UI )!
            * 6. string Name
            * 
            * Next we check If the DateTimePickers value is less than the current date, IF it is: throw a VideoRentalException
            * ELSE: set the precise returnvalues of the current Hour, Minute and Seconds + ReturnDate from the UI-controller DateTimePicker
            * Send it through booking.ReturnVideo(bookingObject) that calculates the total Cost of the booking..
            * ...and if it has a valid Timestamp ( not earlier than RentDate ). 
            * DataBase checks if ReturnedDate == DateTime.MinValue, wich is our signature for a booking that has not been Returned.
            * Set the associated films bIsRented property to FALSE and set cost + returnedDate. Return TRUE!
            * ************************************************************************************************************/
        internal virtual void BookingTabReturn(int? selectedVideoBooking, DateTimePicker dtpBookingTab, TabControl tabIndexController )
        {
            try
            {
                #region Input-checks!

                /** Check for correct inputvalues  */
                if (selectedVideoBooking != null)
                {
                    int index = Convert.ToInt32(selectedVideoBooking);

                    /** Get the ID-property as a string from the RentTab ListView */
                    var checkForValidVideoBookingID =
                        bookingTabListView.Items[index].SubItems[Convert.ToInt32(BookingTabListViewColumnIndex.BookingID)].Text != String.Empty ?
                        bookingTabListView.Items[index].SubItems[Convert.ToInt32(BookingTabListViewColumnIndex.BookingID)].Text : String.Empty;
                #endregion

                    #region Found a valid videoID, parse it to a guid a find it in the datasource!

                    /** Found a valid videoID, parse it to a guid a find it in the datasource! */
                    if (checkForValidVideoBookingID != String.Empty)
                    {
                        /** Get the VideoBooking, OK IF != Null */
                        var getVideoBooking = booking.GetVideoBooking(Guid.Parse(checkForValidVideoBookingID), default(String), default(VideoBooking));
                        if (getVideoBooking != null)
                        {
                            /** Create a new valid object corresponding to the same object in the database */
                            VideoBooking getVideoBookingFromDB = getVideoBooking.First();
                            VideoBooking videoBookingToReturn = new VideoBooking(
                                getVideoBookingFromDB.Id,
                                getVideoBookingFromDB.VideoID,
                                getVideoBookingFromDB.CustomerID,
                                getVideoBookingFromDB.RentDate,
                                getVideoBookingFromDB.ReturnedDate,
                                getVideoBookingFromDB.Name);
                    #endregion

                            #region DateTimeCheck

                            /** If the DateTimePickers value is less than the current date, throw exception */
                            if (dtpBookingTab.Value.Date < DateTime.Now.Date)
                            {
                                throw new VideoRentalException(videoBookingToReturn,
                                    String.Format("Please choose a new date from the UI for current booking: {0} !", videoBookingToReturn.Name));
                            }
                            else
                            {
                                /** Set precise returnvalues of the current Hour, Minute and Seconds + ReturnDate from the UI-controller DateTimePicker */
                                var currentHour = DateTime.Now.Hour;
                                var currentMinute = DateTime.Now.Minute;
                                var currentSecond = DateTime.Now.Second;
                                var chosenDateFromUI = dtpBookingTab.Value.Date;
                                var finalDateTimeFromUI = chosenDateFromUI.Add(new TimeSpan(currentHour, currentMinute, currentSecond));

                                videoBookingToReturn.ReturnedDate = finalDateTimeFromUI;
                            }
                            #endregion

                            bool bReturnSuccess = booking.ReturnVideo(videoBookingToReturn);

                            #region MessageBox Success!!

                            /** Return was successfull! Managed to find existing booking and set DateTime and Video.bIsRented = false */
                            if (bReturnSuccess)
                            {
                                /** Check if we subscribe to the event ( NOT null! ) */
                                if (UpdateAndFillTabs != null)
                                    UpdateAndFillAllTabs();

                                var msgResult =
                                    MessageBox.Show(
                                    String.Format("Video successfully returned! Goto Rentals? ", videoBookingToReturn.Name),
                                    "Rented Video!",
                                    MessageBoxButtons.OKCancel);

                                switch (msgResult)
                                {
                                    case DialogResult.OK:
                                        //0 == Rent-tab
                                        tabIndexController.SelectTab(0);    
                                        break;
                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                        }
                            #endregion

                        /** Could not find the booking! */ 
                        else if (getVideoBooking == null) throw new VideoRentalException("Failed to get a valid Booking from datasource when returning a film!");
                    }
                }
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
        internal virtual void RentTabRent(int? selectedFilm, Customer selectedCustomer, TabControl tabIndexController )
        {
            try
            {
                #region Check for correct inputvalues

                /** Check for correct inputvalues  */
                if (selectedFilm != null && selectedCustomer != null)
                {
                    int index = Convert.ToInt32(selectedFilm);

                    /** Get the ID-property as a string from the RentTab ListView */
                    var checkForValidVideoID =
                        rentTabListView.Items[index].SubItems[Convert.ToInt32(RentTabListViewColumnIndex.VideoID)].Text != String.Empty ?
                        rentTabListView.Items[index].SubItems[Convert.ToInt32(RentTabListViewColumnIndex.VideoID)].Text : String.Empty;

                #endregion

                    #region Found a valid videoID, parse it to a guid and find it in the datasource!

                    /** Found a valid videoID, parse it to a guid and find it in the datasource! */
                    if (checkForValidVideoID != String.Empty)
                    {
                        var getVideo = booking.GetVideo(Guid.Parse(checkForValidVideoID), default(String), default(Video));
                        if (getVideo != null)
                        {
                            Video videoToRent = getVideo.First();

                    #endregion

                            bool bRentSuccess = booking.RentVideo(videoToRent, selectedCustomer);

                            #region MessageBox Success!

                            /** Successfull finding matching video and customer for rental, matching video aslo has bIsRented = false set */
                            if (bRentSuccess)
                            {
                                /** Check if we subscribe to the event ( NOT null! ) */
                                if (UpdateAndFillTabs != null)
                                    UpdateAndFillAllTabs();

                                var msgResult =
                                    MessageBox.Show(
                                    String.Format("Rented {0}! Proceed to Bookings-tab?", videoToRent.Name),
                                    "Rented Video!",
                                    MessageBoxButtons.OKCancel);

                                switch (msgResult)
                                {
                                    case DialogResult.OK:
                                        // 1 == Bookings-tab
                                        tabIndexController.SelectTab(1);      
                                        break;
                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                            #endregion
                        }

                        /** GetVideo! failed! */
                        else if (getVideo == null) throw new VideoRentalException("Failed to get a valid Video from datasource when renting a film!");
                    }
                }
                else throw new VideoRentalException("Select a Video and Customer before proceeding!");
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
