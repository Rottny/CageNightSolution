using DataLayer.Exceptions;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class Booking : IDataLayer
    {
        #region Variables, Properties
        private IDataBase db;

        public int VideoCount { get { return db.VideoCount; } }
        public int GenreCount { get { return db.GenreCount; } }
        public int VideoBookingCount { get { return db.VideoBookingCount; } }
        public int CustomerCount { get { return db.CustomerCount; } }
        #endregion

        public Booking(IDataBase database)
        {
            db = database;
        }

        #region AddMethods
        public bool AddVideo(Video videoItem)
        {
            try
            {
                if (VideoCount != 0)
                {
                    /** Check for an already existing Video with the same Name-property */
                    var getVideo = GetVideo(videoItem.Id, videoItem.Name);

                    /** IF a matching VideoName already exists! */
                    if (getVideo != null)
                        throw new VideoRentalException(videoItem, String.Format("A Video with the same name: {0} already exists!", videoItem.Name));
                    
                    /** IF NO matching VideoName exists!  */
                    else if (getVideo == null)
                        return db.AddVideo(videoItem);
                }
                return db.AddVideo(videoItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        public bool AddGenre(Genre genreItem)
        {
            try
            {
                /** GenreDictionary has items! */
                if ( GenreCount != 0 )
                {
                    /** Check for an already existing Genre with the same Name-property */
                    var getGenre = GetGenre(genreItem.Id, genreItem.Name);

                    /** IF a matching GenreName already exists! */
                    if (getGenre != null)
                        throw new VideoRentalException(genreItem, String.Format("A Genre with the same name: {0} already exists!", genreItem.Name));
                    
                    /** IF NO matching GenreName exists!  */
                    else if (getGenre == null)
                        return db.AddGenre(genreItem);
                }
                return db.AddGenre(genreItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        public bool AddCustomer(Customer customerItem)
        {
            try
            {
                 /** CustomerDictionary has items! */
                if (CustomerCount != 0)
                {
                    /** Check for an already existing Customer with the same Name-property */
                    var getCustomer = GetCustomer(customerItem.Id, customerItem.Name);

                    /** IF a matching CustomerName already exists! */
                    if (getCustomer != null)
                        throw new VideoRentalException(customerItem, String.Format("A Customer with the same name: {0} already exists!", customerItem.Name));

                    /** IF NO matching CustomerName exists!  */
                    else if (getCustomer == null)
                        return db.AddCustomer(customerItem);
                }
                return db.AddCustomer(customerItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        public bool AddVideoBooking(VideoBooking videoBookingItem)
        {
            try
            {
                return db.AddVideoBooking(videoBookingItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetMethods

        public IEnumerable<Video> GetVideo(Guid videoID, string videoName = default(String), Video videoItem = default(Video))
        {
            try
            {
                return db.GetVideo(videoID, videoName: videoName, videoItem: videoItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Genre> GetGenre(Guid genreID, string genreName = default(String), Genre genreItem = default(Genre))
        {
            try
            {
                return db.GetGenre(genreID, genreName: genreName ,genreItem: genreItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Customer> GetCustomer(Guid customerID, string customerName = default(String), Customer customerItem = default(Customer))
        {
            try
            {
                return db.GetCustomer(customerID, customerName: customerName,customerItem: customerItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<VideoBooking> GetVideoBooking(Guid videoBookingID, string videoBookingName = default(String), VideoBooking videoBookingItem = default(VideoBooking))
        {
            try
            {
                return db.GetVideoBooking(videoBookingID, videoBookingName: videoBookingName, videoBookingItem: videoBookingItem);
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DeleteMethods
        public bool DeleteVideo(Video videoItem)
        {
            try
            {
                /** videoItem exists in datasource? */
                IEnumerable<Video> getVideoObject = GetVideo(videoItem.Id);
                if (getVideoObject != null)
                {
                    /** Bookings exists in datasource? */
                    if (VideoBookingCount != 0)
                    {
                        /** Check if videoItem exists in a booking! */
                        IEnumerable<VideoBooking> joinVideoAndBooking =
                            from booking in db.GetVideoBookingCollection()
                            where booking.VideoID.Equals(getVideoObject.First().Id)
                            select booking;

                        /** videoItem exists in a booking! Throw VideoRentalException */
                        if (joinVideoAndBooking.FirstOrDefault() != default(VideoBooking))
                            throw new VideoRentalException(videoItem, String.Format("Video already exists in a current booking! \n {0}, unable to Delete", joinVideoAndBooking.First().Name));

                        /** videoItem does not exists in a booking! Delete videoItem in datasource! */
                        else if (joinVideoAndBooking.FirstOrDefault() == default(VideoBooking))
                            return db.DeleteVideo(videoItem);
                    }
                    else return db.DeleteVideo(videoItem);
                }
                /** videoItem Get failed! Throw VideoRentalException! */
                throw new VideoRentalException(videoItem, String.Format("Unable find {0}, cannot delete!", videoItem.Name));
            }
            #region Catch 
            catch (VideoRentalException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        public bool DeleteGenre(Genre genreItem)
        {
            try
            {
                /** genreItem exists in datasource? */
                IEnumerable<Genre> getGenreObject = GetGenre(genreItem.Id);
                if (getGenreObject != null)
                {
                    /** Videos exists in datasource? */
                    if (VideoCount != 0)
                    {
                        /** Check if genreItem exists in a video! */
                        IEnumerable<Video> joinGenreAndVideo =
                            from video in db.GetVideoCollection()
                            where video.GenreId.Equals(getGenreObject.First().Id)
                            select video;

                        /** genreItem exists in a video! Throw VideoRentalException */
                        if (joinGenreAndVideo.FirstOrDefault() != default(Video))
                            throw new VideoRentalException(genreItem, String.Format("Genre {0} already exists in a current film! {1}, unable to Delete", getGenreObject.First().Name, joinGenreAndVideo.First().Name));

                        /** genreItem does not exists in a video! Delete genreItem in datasource! */
                        else if (joinGenreAndVideo.FirstOrDefault() == default(Video))
                            return db.DeleteGenre(genreItem);
                    }
                    return db.DeleteGenre(genreItem);
                }
                throw new VideoRentalException(genreItem, String.Format("Genre: {0} does not exist in the datasource, unable to Delete", genreItem.Name));
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        public bool DeleteCustomer(Customer customerItem)
        {
            try
            {    
                /** customerItem exists in datasource? */
                IEnumerable<Customer> getCustomerObject = GetCustomer(customerItem.Id);
                if (getCustomerObject != null)
                {
                    /** Bookings exists in datasource? */
                    if (VideoBookingCount != 0)
                    {
                        /** Check if customerItem exists in a booking! */
                        IEnumerable<VideoBooking> joinCustomerAndBooking =
                            from booking in db.GetVideoBookingCollection()
                            where booking.CustomerID.Equals(getCustomerObject.First().Id)
                            select booking;

                        /** customerItem exists in a booking! Throw VideoRentalException */
                        if (joinCustomerAndBooking.FirstOrDefault() != default(VideoBooking))
                            throw new VideoRentalException(customerItem, String.Format("Customer {0} already exists in a current Booking! \nBookingName: {1} - unable to Delete", getCustomerObject.First().Name, joinCustomerAndBooking.First().Name));

                        /** customerItem does not exists in a booking! Delete customerItem in datasource! */
                        else if (joinCustomerAndBooking.FirstOrDefault() == default(VideoBooking))
                            return db.DeleteCustomer(customerItem);
                    }
                    else return db.DeleteCustomer(customerItem);
                }
                throw new VideoRentalException(customerItem, String.Format("Customer: {0} does not exist in the datasource, unable to Delete", customerItem.Name));
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        public bool DeleteVideoBooking(VideoBooking videoBookingItem)
        {
            try
            {
                /** videoBookingItem exists in datasource? */
                IEnumerable<VideoBooking> getVideoBookingObject = GetVideoBooking(videoBookingItem.Id);
                if (getVideoBookingObject != null)
                {
                    /** Videos and Customers exists? */
                    if (VideoCount != 0 && CustomerCount != 0 && VideoBookingCount != 0)
                    {
                        /** Check if a Video and Customer exist in a booking! */
                        IEnumerable<VideoBooking> joinVideoCustomerAndBooking =
                            from booking in db.GetVideoBookingCollection()
                            join video in db.GetVideoCollection() on booking.VideoID equals video.Id
                            join customer in db.GetCustomerCollection() on booking.CustomerID equals customer.Id
                            select booking;

                        /** videoBookingItem does not have a Customer and Video associated! Throw VideoRentalException */
                        if (joinVideoCustomerAndBooking.FirstOrDefault() == default(VideoBooking))
                            throw new VideoRentalException(videoBookingItem, String.Format("Unable to find and delete any Booking: {0} with a matching Customer and Video", getVideoBookingObject.First().Name));

                        /** videoBookingItem exists and has a Customer and Video associated! Delete Booking! */
                        if (joinVideoCustomerAndBooking.FirstOrDefault() != default(VideoBooking))
                            return db.DeleteVideoBooking(videoBookingItem);
                    }
                    else throw new VideoRentalException(String.Format("No Videos {0} AND Customers {1} AND Bookings exists in datasource!", VideoCount, CustomerCount));
                }
                throw new VideoRentalException(videoBookingItem, String.Format("Booking: {0} does not exist in the datasource!", videoBookingItem.Name));
            }
            catch (VideoRentalException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateMethods
        public bool UpdateVideo(Video videoItem)
        {
            try
            {
                if (videoItem != null)
                {
                    /** Check if videoItem exists in VideoDictionary! */
                    IEnumerable<Video> getVideoObjectToUpdate = GetVideo(videoItem.Id);
                    if (getVideoObjectToUpdate != null)
                    {
                        #region Check for an already existing Video with the same Name-property

                        /** Check for an already existing Video with the same Name-property */
                        var getVideo = GetVideo(videoItem.Id, videoItem.Name);

                        /** IF a matching VideoName already exists! */
                        if (getVideo != null)
                        {
                            /** Get the Current GenreName for the Selected Video 
                             *  and check if videoItem.GenreID differs from the DataSource version */
                            var getCurrentGenreNameFromDB = 
                                GetGenre(getVideoObjectToUpdate.First().GenreId) != null ? 
                                GetGenre(getVideoObjectToUpdate.First().GenreId).First() : 
                                null;

                            var getCurrentGenreNameFromSelectedVideo = 
                                GetGenre(videoItem.GenreId) != null ? 
                                GetGenre(videoItem.GenreId).First() : 
                                null;

                            /** Check and compare new GenreName ( from UI ) and Old GenreName ( from DataBase )*/
                            if (getCurrentGenreNameFromDB != null && getCurrentGenreNameFromSelectedVideo != null)
                            {
                                /** IF New GenreName != Old GenreName 
                                 *  OR New NrOfDaysWOPenalty != Old NewNrOfDaysWOPenalty */
                                if (!getCurrentGenreNameFromDB.Name.Equals(getCurrentGenreNameFromSelectedVideo.Name) ||
                                    getVideoObjectToUpdate.First().NrOfDaysWOPenalty != videoItem.NrOfDaysWOPenalty)
                                    return db.UpdateVideo(videoItem, getVideoObjectToUpdate.First());
                            }
                            throw new VideoRentalException(videoItem, String.Format("A Video with the same title and genre already exists: {0} : {1}", videoItem.Name, getCurrentGenreNameFromSelectedVideo.Name));
                        }

                        /** IF NO matching VideoName exists!  */
                        else if (getVideo == null) return db.UpdateVideo(videoItem, getVideoObjectToUpdate.First());

                        #endregion
                    }
                    else throw new VideoRentalException(String.Format("Could not get video: {0} when updating!", videoItem.Name));
                }
                throw new VideoRentalException(videoItem, String.Format("Video: {0} is not a valid type to update!", videoItem.GetType().ToString()));
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
        public bool UpdateGenre(Genre genreItem)
        {
            try
            {
                if (genreItem != null)
                {
                    /** Check if genreItem exists in GenreDictionary! */
                    IEnumerable<Genre> getGenreObjectToUpdate = GetGenre(genreItem.Id);

                    if (getGenreObjectToUpdate != null)
                    {
                        /** Check if theres already a Genre with matching Name in datasource! */
                        var getGenre = GetGenre(genreItem.Id, genreItem.Name);
                        
                        /** IF a matching GenreName already exists! */
                        if (getGenre != null)
                            throw new VideoRentalException(genreItem, String.Format("A Genre with the same name: {0} already exists!", genreItem.Name));

                        /** IF NO matching GenreName exists!  */
                        else if (getGenre == null)
                            return db.UpdateGenre(genreItem, getGenreObjectToUpdate.First());
                    }
                    else throw new VideoRentalException(genreItem, String.Format("Genre: {0} does not exist in datasource, unable to Update", genreItem.Name));
                }
                throw new VideoRentalException(genreItem, String.Format("Genre: {0} is not a valid type to update!", genreItem.GetType().ToString()));
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
        public bool UpdateCustomer(Customer customerItem)
        {
           try
           {
               if (customerItem != null)
               {
                   /** Check if customerItem exists in CustomerDictionary! */
                   IEnumerable<Customer> getCustomerObjectToUpdate = GetCustomer(customerItem.Id);
                   if (getCustomerObjectToUpdate != null)
                   {
                       var getCustomer = GetCustomer(customerItem.Id, customerItem.Name);

                       /** IF a matching CustomerName already exists! */
                       if (getCustomer != null)
                           throw new VideoRentalException(customerItem, String.Format("A Customer with the same name: {0} already exists!", customerItem.Name));

                       /** IF NO matching GenreName exists!  */
                       else if (getCustomer == null)
                           return db.UpdateCustomer(customerItem, getCustomerObjectToUpdate.First());
                   }

                   else throw new VideoRentalException(customerItem, String.Format("Customer: {0} does not exist in datasource, unable to Update", customerItem.Name));
               }
               throw new VideoRentalException(customerItem, String.Format("Customer: {0} is not a valid type to update!", customerItem.GetType().ToString()));
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
        public bool UpdateVideoBooking(VideoBooking videoBookingItem)
        {
            try
            {
                if (videoBookingItem != null)
                {
                    /** Check if videoBookingItem exists in datasource! */
                    IEnumerable<VideoBooking> getVideoBookingObjectToUpdate = GetVideoBooking(videoBookingItem.Id);
                    if (getVideoBookingObjectToUpdate != null)
                    {
                        /** Check if Video and Customer exists in the datasource! */
                        if (GetVideo(videoBookingItem.VideoID) != null && GetCustomer(videoBookingItem.CustomerID) != null)
                            return db.UpdateVideoBooking(videoBookingItem, getVideoBookingObjectToUpdate.First());

                        else throw new VideoRentalException(videoBookingItem, String.Format("Could not update VideoBooking, invalid Customer and Video"));
                    }
                    else throw new VideoRentalException(videoBookingItem, String.Format("Booking: {0} does not exist in datasource, unable to Update", videoBookingItem.Name));
                }
                else throw new VideoRentalException(videoBookingItem, String.Format("Booking: {0} is not a valid type to update!", videoBookingItem.GetType().ToString()));
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

        #region GetCollectionMethods
        public IEnumerable<Video> GetVideoCollection()
        {
            IEnumerable<Video> getVideoCollection = db.GetVideoCollection();

            if (getVideoCollection != null)
            {
                return getVideoCollection;
            }
            else 
                throw new VideoRentalException(String.Format("Could not get VideoCollection from datasource"));
        }
        public IEnumerable<Genre> GetGenreCollection()
        {
            IEnumerable<Genre> getGenreCollection = db.GetGenreCollection();

            if (getGenreCollection != null)
            {
                return getGenreCollection;
            }
            else
                throw new VideoRentalException(String.Format("Could not get GenreCollection from datasource"));
        }
        public IEnumerable<Customer> GetCustomerCollection()
        {
            IEnumerable<Customer> getCustomerCollection = db.GetCustomerCollection();

            if (getCustomerCollection != null)
            {
                return getCustomerCollection;
            }
            else
                throw new VideoRentalException(String.Format("Could not get CustomerCollection from datasource"));
        }
        public IEnumerable<VideoBooking> GetVideoBookingCollection()
        {
            IEnumerable<VideoBooking> getVideoBookingCollection = db.GetVideoBookingCollection();

            if (getVideoBookingCollection != null)
            {
                return getVideoBookingCollection;
            }
            else
                throw new VideoRentalException(String.Format("Could not get VideoBookingCollection from datasource"));
        }
        #endregion

        public bool RentVideo(Video videoItem, Customer customerItem)
        {
            try
            {
                if (videoItem != null && customerItem != null)
                {
                    /** Get and Check that Customer and Video are OK! */
                    var getCustomer = GetCustomer(customerItem.Id) != null ? GetCustomer(customerItem.Id).First() : null;
                    var getVideo = GetVideo(videoItem.Id) != null ? GetVideo(videoItem.Id).First() : null;
                    
                    /** IF Customer AND Video are OK! 
                     *  AND Video IS NOT Rented out, continue!  */
                    if (getCustomer != null && getVideo != null && !getVideo.bIsRented)
                            /** DataBase RentVideo! */
                            return db.RentVideo( new VideoBooking(
                                videoItem.Id, 
                                customerItem.Id, 
                                DateTime.Today, 
                                String.Format("{0} : {1}", getCustomer.Name, getVideo.Name)), getVideo, getCustomer);

                    else throw new VideoRentalException(getVideo, String.Format("Video {0} is alreay rented out!", getVideo.Name));
                }
                throw new VideoRentalException(videoItem, String.Format("Customer {0} OR Video {0} not valid when renting!", customerItem.GetType().ToString(), videoItem.GetType().ToString()));
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
        public bool ReturnVideo(VideoBooking videoBooking)
        {
            try
            {
                if (videoBooking != null)
                {
                    #region Check if ReturneDate is ok!

                    if ((videoBooking.ReturnedDate.Day - videoBooking.RentDate.Day == 0) &&
                         (videoBooking.ReturnedDate.Hour - videoBooking.ReturnedDate.Hour <= 1))
                    { /** Film rented and returned at the same day and hour, ok! */ }

                    /** Make sure ReturnDate is earlier than RentDate for Booking! */
                    else if (DateTime.Compare(videoBooking.RentDate, videoBooking.ReturnedDate) > 0)
                        throw new VideoRentalException(videoBooking, String.Format("ReturnDate is earlier than RentDate for Booking! \n{0}.", videoBooking.Name));

                    #endregion

                    #region Get Film from datasource and calculate Cost!

                    var bookedVideoItem = GetVideo(videoBooking.VideoID);
                    if (bookedVideoItem != null)
                    {
                        /** Cost: atleast 50kr, even when returning at the same day! */
                        int timeDifference = (int)videoBooking.ReturnedDate.Subtract(videoBooking.RentDate).Days;
                        if (timeDifference < 1)
                            timeDifference = 1;
                        int cost = timeDifference * 50;
                        int overtime = timeDifference - bookedVideoItem.First().NrOfDaysWOPenalty;

                        if (overtime > 0)
                            cost += overtime * 20;

                        videoBooking.Cost = cost;
                        return db.ReturnVideo(videoBooking);
                    }
                    #endregion

                    else throw new VideoRentalException(videoBooking,String.Format("Could not find a video for the current booking!"));
                }
                throw new VideoRentalException(videoBooking, String.Format("Booking {0} is not a valid type!", videoBooking.GetType().ToString()));
            }
            #region Catch
            catch (VideoRentalException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
