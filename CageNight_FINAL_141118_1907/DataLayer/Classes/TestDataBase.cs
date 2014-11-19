using DataLayer.Exceptions;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class TestDataBase : IDataBase
    {
        #region Dictionaries and Properties for counting dictionaries.
        private Dictionary<Guid, Video> VideoDictionary;
        private Dictionary<Guid, Genre> GenreDictionary;
        private Dictionary<Guid, VideoBooking> VideoBookingDictionary;
        private Dictionary<Guid, Customer> CustomerDictionary;

        //Update 14-11-10!
        public int VideoCount { get { return VideoDictionary.Count > 0 ? VideoDictionary.Count : 0; } }
        public int GenreCount { get { return GenreDictionary.Count > 0 ? GenreDictionary.Count : 0; } }
        public int VideoBookingCount { get { return VideoBookingDictionary.Count > 0 ? VideoBookingDictionary.Count : 0; } }
        public int CustomerCount { get { return CustomerDictionary.Count > 0 ? CustomerDictionary.Count : 0; } }
        #endregion

        public TestDataBase()
        {
            VideoDictionary = new Dictionary<Guid, Video>();
            GenreDictionary = new Dictionary<Guid, Genre>();
            VideoBookingDictionary = new Dictionary<Guid, VideoBooking>();
            CustomerDictionary = new Dictionary<Guid, Customer>();

            #region MOCVALUES
            #region Videos

            var dummyVideo = new Video(MOCVALUES.videoID1, MOCVALUES.genreID1, false, "The Rock", 4);
            var dummyVideo2 = new Video(MOCVALUES.videoID2, MOCVALUES.genreID2, true, "Face Off", 6);
            var dummyVideo3 = new Video(MOCVALUES.videoID3, MOCVALUES.genreID3, true, "Con Air", 3);
            var dummyVideo4 = new Video(MOCVALUES.videoID4, MOCVALUES.genreID1, false, "Wild at heart", 6);
            var dummyVideo5 = new Video(MOCVALUES.videoID5, MOCVALUES.genreID3, false, "Raising Arizona", 3);
            var dummyVideo6 = new Video(MOCVALUES.videoID6, MOCVALUES.genreID4, false, "Gone in Sixty Seconds", 4);
            var dummyVideo7 = new Video(MOCVALUES.videoID7, MOCVALUES.genreID3, false, "National Treasure", 3);
            var dummyVideo8 = new Video(MOCVALUES.videoID8, MOCVALUES.genreID3, false, "Vampire's Kiss", 3);

            #endregion

            #region Genres
            var dummyGenre = new Genre(MOCVALUES.genreID1, "Horror");
            var dummyGenre2 = new Genre(MOCVALUES.genreID2, "Action");
            var dummyGenre3 = new Genre(MOCVALUES.genreID3, "Drama");
            var dummyGenre4 = new Genre(MOCVALUES.genreID4, "Crime");
            var dummyGenre5 = new Genre(MOCVALUES.genreID5, "Comedy");
            #endregion

            #region Customer
            var dummyCustomer = new Customer(MOCVALUES.customerID1, "Patricia", "Arquette");
            var dummyCustomer2 = new Customer(MOCVALUES.customerID2, "Lisa Marie", "Presley");
            var dummyCustomer3 = new Customer(MOCVALUES.customerID3, "Alice", "Kim");
            var dummyCustomer4 = new Customer(MOCVALUES.customerID4, "Christina", "Fulton");
            #endregion

            #region Bookings
            var dummyBooking = new VideoBooking(MOCVALUES.videobookingID1, MOCVALUES.videoID3, MOCVALUES.customerID3, DateTime.Now.AddDays(-2), DateTime.MinValue, "Alice Kim : Con Air");
            /** Con Air, 
             * Alice Kim, 
             * DateTime.Now,
             * Not Returned (DateTime.MinValue),
             * Alice Kim : Con Air */

            var dummyBooking2 = new VideoBooking(MOCVALUES.videobookingID2, MOCVALUES.videoID4, MOCVALUES.customerID4, DateTime.Now.AddDays(-2), DateTime.MinValue, "Christina Fulton : Wild at heart");
            /** The Face Off, 
             * Wild at heart,
             * Christina Fulton,
             * DateTime.Now.AddDays(-2), 
             * Not Return (DateTime.MinValue), 
             * Christina Fulton : Wild at heart */
            #endregion

            #region Add to Dictionaries

            VideoDictionary.Add(MOCVALUES.videoID1, dummyVideo);
            VideoDictionary.Add(MOCVALUES.videoID2, dummyVideo2);
            VideoDictionary.Add(MOCVALUES.videoID3, dummyVideo3);
            VideoDictionary.Add(MOCVALUES.videoID4, dummyVideo4);
            VideoDictionary.Add(MOCVALUES.videoID5, dummyVideo5);
            VideoDictionary.Add(MOCVALUES.videoID6, dummyVideo6);
            VideoDictionary.Add(MOCVALUES.videoID7, dummyVideo7);
            VideoDictionary.Add(MOCVALUES.videoID8, dummyVideo8);

            GenreDictionary.Add(MOCVALUES.genreID1, dummyGenre);
            GenreDictionary.Add(MOCVALUES.genreID2, dummyGenre2);
            GenreDictionary.Add(MOCVALUES.genreID3, dummyGenre3);
            GenreDictionary.Add(MOCVALUES.genreID4, dummyGenre4);
            GenreDictionary.Add(MOCVALUES.genreID5, dummyGenre5);

            VideoBookingDictionary.Add(MOCVALUES.videobookingID1, dummyBooking);
            VideoBookingDictionary.Add(MOCVALUES.videobookingID2, dummyBooking2);

            CustomerDictionary.Add(MOCVALUES.customerID1, dummyCustomer);
            CustomerDictionary.Add(MOCVALUES.customerID2, dummyCustomer2);
            CustomerDictionary.Add(MOCVALUES.customerID3, dummyCustomer3);
            CustomerDictionary.Add(MOCVALUES.customerID4, dummyCustomer4);

            #endregion
            #endregion
        }

        #region AddMethods
        public bool AddVideo(Video videoItem)
        {
            try
            {
                if (videoItem != null)
                {
                    /** Get and Check for video in datasource! */
                    var getVideo = GetVideo(videoItem.Id) != null ? GetVideo(videoItem.Id) : null;

                    //Dictionary has items and the specified item does exist!
                    if (VideoCount != 0 && getVideo != null)
                        throw new VideoRentalException(videoItem, String.Format("Video {0} already exists in datasource, could not add!", videoItem.Name));

                    //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                    if ((VideoCount != 0 && getVideo == null) || VideoCount == 0)
                    {
                        VideoDictionary.Add(videoItem.Id, videoItem);
                        return true;
                    }
                }
                throw new VideoRentalException(videoItem, String.Format("Could not add video {0}", videoItem.Name));
            }
            catch (Exception ex)
            {
                throw new VideoRentalException(videoItem, String.Format("Could not add video to datasource {0}\n{1}", videoItem.Name, ex.Message));
            }
        }
        public bool AddGenre(Genre genreItem)
        {
            try
            {
                if (genreItem != null)
                {
                    /** Get and Check for genre in datasource! */
                    var getGenre = GetGenre(genreItem.Id) != null ? GetGenre(genreItem.Id) : null;

                    //Dictionary has items and the specified item does exist!
                    if (GenreCount != 0 && getGenre != null)
                        throw new VideoRentalException(genreItem, String.Format("Genre {0} already exists in datasource, could not add!", genreItem.Name));

                    //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                    if (GenreCount != 0 && getGenre == null || (GenreCount == 0))
                    {
                        GenreDictionary.Add(genreItem.Id, genreItem);
                        return true;
                    }
                }
                throw new VideoRentalException(genreItem, String.Format("Could not add genre {0}", genreItem.Name));
            }
            catch (Exception ex)
            {
                throw new VideoRentalException(genreItem, String.Format("Could not add genre to datasource {0}\n{1}", genreItem.Name, ex.Message));
            }
        }
        public bool AddCustomer(Customer customerItem)
        {
            try
            {
                if (customerItem != null)
                {
                    /** Get and Check for genre in datasource! */
                    var getCustomer = GetCustomer(customerItem.Id) != null ? GetCustomer(customerItem.Id) : null;

                    //Dictionary has items and the specified item does exist!
                    if (CustomerCount != 0 && getCustomer != null)
                        throw new VideoRentalException(customerItem, String.Format("Customer {0} already exists in datasource, could not add!", customerItem.Name));

                    //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                    if (CustomerCount != 0 && getCustomer == null || (CustomerCount != 0))
                    {
                        CustomerDictionary.Add(customerItem.Id, customerItem);
                        return true;
                    }
                }
                throw new VideoRentalException(customerItem, String.Format("Could not add customer {0}", customerItem.Name));
            }
            catch (Exception ex)
            {
                throw new VideoRentalException(customerItem, String.Format("Could not add customer to datasource {0}\n{1}", customerItem.Name, ex.Message));
            }
        }
        public bool AddVideoBooking(VideoBooking videoBookingItem)
        {
            try
            {
                if (videoBookingItem != null)
                {
                    /** Get and Check for genre in datasource! */
                    var getVideoBooking = GetVideoBooking(videoBookingItem.Id) != null ? GetVideoBooking(videoBookingItem.Id) : null;

                    //Dictionary has items and the specified item does exist!
                    if (VideoBookingCount != 0 && getVideoBooking != null)
                        throw new VideoRentalException(videoBookingItem, String.Format("Booking already exists in datasource, {0}", videoBookingItem.Name));

                    //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                    if (VideoBookingCount != 0 && getVideoBooking == null || (VideoBookingCount == 0))
                    {
                        VideoBookingDictionary.Add(videoBookingItem.Id, videoBookingItem);
                        return true;
                    }
                }
                throw new VideoRentalException(videoBookingItem, String.Format("Could not add booking {0}", videoBookingItem.Name));
            }
            catch (Exception ex)
            {
                throw new VideoRentalException(videoBookingItem, String.Format("Could not add booking {0}\n{1}", videoBookingItem.Name, ex.Message));
            }
        }
        #endregion

        #region GetMethods

        /** Returns Enumerable<TYPE> if successfull, null if searched item does not exist! 
            ID checks for an item with a matching ID. ( Not optional! )
         *  NAME checkes for an item with a matching Name. ( Optional! )
         *  ITEM checks for an item with a number of matching qualities, I.E Name, GenreID...etc.. ( Optional! )
            Throws a VideoRentalException if both ID and ITEM are default! */
        public IEnumerable<Video> GetVideo(Guid videoID, string videoName = default(String), Video videoItem = default(Video))
        {
            if (videoItem != default(Video) && videoItem != null)
            {
                /** Check if Database has a match for videoItem: Name, Genre, NrOfDaysWOPenalty and bIsRented! */
                IEnumerable<Video> queryVideoCollection =
                     from video in VideoDictionary
                     where video.Value.Name.Equals(videoItem.Name)
                     where video.Value.GenreId.Equals(videoItem.GenreId)
                     where video.Value.NrOfDaysWOPenalty.Equals(videoItem.NrOfDaysWOPenalty)
                     where video.Value.bIsRented.Equals(videoItem.bIsRented)
                     select video.Value;

                return queryVideoCollection.FirstOrDefault() != default(Video) ? queryVideoCollection : null;
            }
            else if (videoName != default(String) && videoName != null)
            {
                /** Check if Database has a match for videoItem: VideoName! */
                IEnumerable<Video> queryVideoCollection =
                     from video in VideoDictionary
                     where video.Value.Name.Equals(videoName)
                     select video.Value;

                return queryVideoCollection.FirstOrDefault() != default(Video) ? queryVideoCollection : null;
            }
            else if (videoID != default(Guid) && videoID != null)
            {
                /** Check if Database has a match for videoItem: VideoID! */
                IEnumerable<Video> queryVideoCollection =
                     from video in VideoDictionary
                     where video.Key.Equals(videoID)
                     select video.Value;

                return queryVideoCollection.FirstOrDefault() != default(Video) ? queryVideoCollection : null;
            }
            throw new VideoRentalException(videoItem, String.Format("Could not Get the requested Video from datasource: {0} \n {1}", videoItem.GetType().ToString()));
        }

        public IEnumerable<Genre> GetGenre(Guid genreID, string genreName = default(String), Genre genreItem = default(Genre))
        {
            if (genreItem != default(Genre) && genreItem != null)
            {
                /** Check if Database has a match for genreItem: Name! */
                IEnumerable<Genre> queryGenreCollection =
                     from genre in GenreDictionary
                     where genre.Value.Name.Equals(genreItem.Name)
                     select genre.Value;

                return queryGenreCollection.FirstOrDefault() != default(Genre) ? queryGenreCollection : null;
            }
            else if (genreName != default(String) && genreName != null)
            {
                /** Check if Database has a match for genreName: Name! */
                IEnumerable<Genre> queryGenreCollection =
                     from genre in GenreDictionary
                     where genre.Value.Name.Equals(genreName)
                     select genre.Value;

                return queryGenreCollection.FirstOrDefault() != default(Genre) ? queryGenreCollection : null;
            }
            else if (genreID != default(Guid) && genreID != null)
            {
                /** Check if Database has a match for genreItem: ID! */
                IEnumerable<Genre> queryGenreCollection =
                     from genre in GenreDictionary
                     where genre.Key.Equals(genreID)
                     select genre.Value;

                return queryGenreCollection.FirstOrDefault() != default(Genre) ? queryGenreCollection : null;
            }
            throw new VideoRentalException(genreItem, String.Format("Could not get the requested Genre from datasource: {0}", genreItem.GetType().ToString()));
        }

        public IEnumerable<Customer> GetCustomer(Guid customerID, string customerName = default(String), Customer customerItem = default(Customer))
        {
            if (customerItem != default(Customer) && customerItem != null)
            {
                /** Check if Database has a match for customerItem: FName, EName! */
                IEnumerable<Customer> queryCustomerCollection =
                     from customer in CustomerDictionary
                     where customer.Value.FName.Equals(customerItem.FName)
                     where customer.Value.EName.Equals(customerItem.EName)
                     select customer.Value;

                return queryCustomerCollection.FirstOrDefault() != default(Customer) ? queryCustomerCollection : null;
            }
            else if (customerName != default(String) && customerName != null)
            {
                /** Check if Database has a match for customerName: Name! */
                IEnumerable<Customer> queryCustomerCollection =
                     from customer in CustomerDictionary
                     where customer.Value.Name.Equals(customerName)
                     select customer.Value;

                return queryCustomerCollection.FirstOrDefault() != default(Customer) ? queryCustomerCollection : null;
            }
            else if (customerID != default(Guid) && customerID != null)
            {
                /** Check if Database has a match for customerItem: ID! */
                IEnumerable<Customer> queryCustomerCollection =
                     from customer in CustomerDictionary
                     where customer.Key.Equals(customerID)
                     select customer.Value;

                return queryCustomerCollection.FirstOrDefault() != default(Customer) ? queryCustomerCollection : null;
            }
            throw new VideoRentalException(customerItem, String.Format("Could not get the requested Customer from datasource : {0}", customerItem.GetType().ToString()));
        }

        public IEnumerable<VideoBooking> GetVideoBooking(Guid videoBookingID, string videoBookingName = default(String), VideoBooking videoBookingItem = default(VideoBooking))
        {
            if (videoBookingItem != default(VideoBooking) && videoBookingItem != null)
            {
                /** Check if Database has a match for videoBookingItem: Name, VideoID, CustomerID, RentDate, ReturnedDate, Cost! */
                IEnumerable<VideoBooking> queryVideoBookingCollection =
                     from booking in VideoBookingDictionary
                     where booking.Value.Name.Equals(videoBookingItem.Name)
                     where booking.Value.VideoID.Equals(videoBookingItem.VideoID)
                     where booking.Value.CustomerID.Equals(videoBookingItem.CustomerID)
                     where booking.Value.RentDate.Equals(videoBookingItem.RentDate)
                     where booking.Value.ReturnedDate.Equals(videoBookingItem.ReturnedDate)
                     where booking.Value.Cost.Equals(videoBookingItem.Cost)
                     select booking.Value;

                return queryVideoBookingCollection.FirstOrDefault() != default(VideoBooking) ? queryVideoBookingCollection : null;
            }
            else if (videoBookingName != default(String) && videoBookingName != null)
            {
                /** Check if Database has a match for videoBookingName: Name! */
                IEnumerable<VideoBooking> queryVideoBookingCollection =
                     from booking in VideoBookingDictionary
                     where booking.Value.Name.Equals(videoBookingName)
                     select booking.Value;

                return queryVideoBookingCollection.FirstOrDefault() != default(VideoBooking) ? queryVideoBookingCollection : null;
            }
            else if (videoBookingID != default(Guid) && videoBookingID != null)
            {
                /** Check if Database has a match for videoBookingItem: ID! */
                IEnumerable<VideoBooking> queryVideoBookingCollection =
                     from booking in VideoBookingDictionary
                     where booking.Key.Equals(videoBookingID)
                     select booking.Value;

                return queryVideoBookingCollection.FirstOrDefault() != default(VideoBooking) ? queryVideoBookingCollection : null;
            }
            throw new VideoRentalException(videoBookingItem, String.Format("Could not get the requested Booking from datasource: {0}", videoBookingItem.GetType().ToString()));
        }

        #endregion

        #region DeleteMethods
        public bool DeleteVideo(Video videoItem)
        {
            if (videoItem != null)
            {
                try
                {
                    if (VideoDictionary.Remove(videoItem.Id))
                        return true;
                }
                catch (Exception ex)
                {
                    throw new VideoRentalException(videoItem, String.Format("Unable to delete Video: {0}, \n {1]}", videoItem.Name, ex.Message));
                }
            }
            throw new VideoRentalException(videoItem, String.Format("Video: {0} is not a valid type to delete!", videoItem.GetType().ToString()));
        }
        public bool DeleteGenre(Genre genreItem)
        {
            if (genreItem != null)
            {
                try
                {
                    if (GenreDictionary.Remove(genreItem.Id))
                        return true;
                }
                catch (Exception ex)
                {
                    throw new VideoRentalException(genreItem, String.Format("Unable to delete Genre: {0}, \n {1]}", genreItem.Name, ex.Message));
                }
            }
            throw new VideoRentalException(genreItem, String.Format("Genre: {0} is not a valid type to delete!", genreItem.GetType().ToString()));
        }
        public bool DeleteCustomer(Customer customerItem)
        {
            if (customerItem != null)
            {
                try
                {
                    if (CustomerDictionary.Remove(customerItem.Id))
                        return true;
                }
                catch (Exception ex)
                {
                    throw new VideoRentalException(customerItem, String.Format("Unable to delete Customer: {0}, \n {1]}", customerItem.Name, ex.Message));
                }
            }
            throw new VideoRentalException(customerItem, String.Format("Customer: {0} is not a valid object to delete!", customerItem.GetType().ToString()));
        }
        public bool DeleteVideoBooking(VideoBooking videoBookingItem)
        {
            if (videoBookingItem != null)
            {
                try
                {
                    if (VideoBookingDictionary.Remove(videoBookingItem.Id))
                        return true;
                }
                catch (Exception ex)
                {
                    throw new VideoRentalException(videoBookingItem, String.Format("Unable to delete Booking: {0}, \n {1]}", videoBookingItem.Name, ex.Message));
                }
            }
            throw new VideoRentalException(videoBookingItem, String.Format("Booking: {0} is not a valid object to delete!", videoBookingItem.GetType().ToString()));
        }
        #endregion

        #region UpdateMethods
        //Updating: GenreID, VideoName(Title), NrOfDaysWOPenalty
        public bool UpdateVideo(Video videoItem, Video videoItemToUpdate)
        {
            try
            {
                videoItemToUpdate.GenreId = videoItem.GenreId;
                videoItemToUpdate.Name = videoItem.Name;
                videoItemToUpdate.NrOfDaysWOPenalty = videoItem.NrOfDaysWOPenalty;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Updating: GenreName
        public bool UpdateGenre(Genre genreItem, Genre genreItemToUpdate)
        {
            try
            {
                genreItemToUpdate.Name = genreItem.Name;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Updating: FName, EName
        public bool UpdateCustomer(Customer customerItem, Customer customerItemToUpdate)
        {
            try
            {
                customerItemToUpdate.FName = customerItem.FName;
                customerItemToUpdate.EName = customerItem.EName;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Updating: VideoID, CustomerID, Name (CustomerName + VideoName)
        public bool UpdateVideoBooking(VideoBooking videoBookingItem, VideoBooking videoBookingItemToUpdate)
        {
            try
            {
                videoBookingItemToUpdate.Name = String.Format("{0} : {1}",
                    GetCustomer(videoBookingItem.CustomerID).First().Name, GetVideo(videoBookingItem.VideoID).First().Name);
                videoBookingItemToUpdate.VideoID = videoBookingItem.VideoID;
                videoBookingItemToUpdate.CustomerID = videoBookingItem.CustomerID;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetCollectionMethods
        /** Return an IEnumerable<TYPE> if successfull, Returns null if failed! */
        public IEnumerable<Video> GetVideoCollection()
        {
            IEnumerable<Video> queryVideoCollection =
                       from video in VideoDictionary
                       select video.Value;

            if (queryVideoCollection.FirstOrDefault() != default(Video))
                return queryVideoCollection;
            else
                return null;
        }
        public IEnumerable<Genre> GetGenreCollection()
        {
            IEnumerable<Genre> queryGenreCollection =
                        from genre in GenreDictionary
                        select genre.Value;

            if (queryGenreCollection.FirstOrDefault() != default(Genre))
                return queryGenreCollection;
            else
                return null;
        }
        public IEnumerable<Customer> GetCustomerCollection()
        {
            IEnumerable<Customer> queryCustomerCollection =
                        from customer in CustomerDictionary
                        select customer.Value;

            if (queryCustomerCollection.FirstOrDefault() != default(Customer))
                return queryCustomerCollection;
            else
                return null;
        }
        public IEnumerable<VideoBooking> GetVideoBookingCollection()
        {
            IEnumerable<VideoBooking> queryVideoBookingCollection =
                        from booking in VideoBookingDictionary
                        select booking.Value;

            if (queryVideoBookingCollection.FirstOrDefault() != default(VideoBooking))
                return queryVideoBookingCollection;
            else
                return null;
        }
        #endregion

        public bool RentVideo(VideoBooking videoBooking, Video video, Customer customer)
        {
            try
            {
                VideoBooking createNewVB = new VideoBooking(
                                             videoBooking.Id,
                                             videoBooking.VideoID,
                                             videoBooking.CustomerID,
                                             DateTime.Now,
                                             DateTime.MinValue,
                                             videoBooking.Name);

                video.bIsRented = true;
                VideoBookingDictionary.Add(createNewVB.Id, createNewVB);
                return true;
            }
            catch (Exception ex)
            {
                throw new VideoRentalException(video, String.Format("Could not add booking to datasource when renting a film {0}!\n{1}", video.Name, ex.Message));
            }
        }
        public bool ReturnVideo(VideoBooking videoBookingItem)
        {
            try
            {
                /** Get the datasource version of VideoBooking and Video! */
                var dataSourceVideoBooking = GetVideoBooking(videoBookingItem.Id).First();
                var dataSourceVideo = GetVideo(videoBookingItem.VideoID).First();

                /** IF ReturnedDate is set to default, 
                * set new ReturnedDate, set Cost to the new value calculated in Bookings ReturnVideo
                * and set bIsRented as False for current film! */
                if (dataSourceVideoBooking.ReturnedDate == DateTime.MinValue)
                {
                    dataSourceVideoBooking.ReturnedDate = videoBookingItem.ReturnedDate;
                    dataSourceVideoBooking.Cost = videoBookingItem.Cost;
                    dataSourceVideo.bIsRented = false;
                    return true;
                }
                else throw new VideoRentalException(videoBookingItem, String.Format("Failed to Return video: {0}", videoBookingItem.Name));
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
    }
}
