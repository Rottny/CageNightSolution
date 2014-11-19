using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBmethods
{
    class dbGetMethods
    {
        #region DeleteMethods

        public bool DeleteVideo( Video videoItem ) 
        {
            if (videoItem != null)
            {
                try
                {
                    //Kolla om videoItem existerar i VideoDictionary
                    IEnumerable<Video> getVideoObject = GetVideo(videoItem);

                    if (getVideoObject != null)
                    {
                        //Kolla om en booking har videoItem
                        IEnumerable<VideoBooking> joinVideoAndBooking =
                            from booking in VideoBookingDictionary
                            where booking.Value.RentedVideo.Id.Equals(getVideoObject.First().Id)
                            select booking.Value;

                        //Hittade videoItem i en bokning. Kasta exception.
                        if (joinVideoAndBooking.FirstOrDefault() != default(VideoBooking))
                        {
                            throw new VideoRentalException(videoItem,
                                String.Format("Video already exists in a current booking! BookingName: {0}, unable to Delete", 
                                joinVideoAndBooking.First().Name));
                        }

                        //Hittade ingen aktuell bokning för filmen, fortsätt med radering.
                        else if (joinVideoAndBooking.FirstOrDefault() == default(VideoBooking))
                        {
                            VideoDictionary.Remove(getVideoObject.First().Id);
                            return true;
                        }
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(videoItem,
                        String.Format("Video: {0} does not exist in datasource, unable to Delete",
                        videoItem.Name));
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
            throw new VideoRentalException(videoItem,
                String.Format("Video: {0} is not a valid type to delete!",
                videoItem.GetType().ToString()));
        }
        public bool DeleteGenre(Genre genreItem)
        {
            if (genreItem != null)
            {
                try
                {
                    //Kolla om genreItem existerar i GenreDictionary
                    IEnumerable<Genre> getGenreObject = GetGenre(genreItem);

                    if (getGenreObject != null)
                    {
                        //Kolla om ett genreItem är associerat med en Video
                        IEnumerable<Video> joinGenreAndVideo =
                            from video in VideoDictionary
                            where video.Value.GenreId.Equals(getGenreObject.First().Id)
                            select video.Value;

                        //Hittade genreItem i en Video. Kasta exception.
                        if (joinGenreAndVideo.FirstOrDefault() != default(Video))
                        {
                            throw new VideoRentalException(genreItem,
                                String.Format("Genre {0} already exists in a current Video-item! VideoName: {1}, unable to Delete", 
                                getGenreObject.First().Name, joinGenreAndVideo.First().Name));
                        }

                        //Hittade ingen aktuell film associerad med genren, fortsätt med radering.
                        else if (joinGenreAndVideo.FirstOrDefault() == default(Video))
                        {
                            GenreDictionary.Remove(genreItem.Id);
                            return true;
                        }
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(genreItem,
                        String.Format("Genre: {0} does not exist in the datasource, unable to Delete",
                        genreItem.Name));
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
            throw new VideoRentalException(genreItem,
                String.Format("Genre: {0} is not a valid type to delete!",
                genreItem.GetType().ToString()));
        }
        public bool DeleteCustomer(Customer customerItem)
        {
            if (customerItem != null)
            {
                try
                {
                    //Kolla om customerItem existerar i CustomerDictionary
                    IEnumerable<Customer> getCustomerObject = GetCustomer(customerItem);

                    if (getCustomerObject != null)
                    {
                        //Kolla om ett customerItem är associerat med en VideoBooking
                        IEnumerable<VideoBooking> joinCustomerAndBooking =
                            from booking in VideoBookingDictionary
                            where booking.Value.CustomerID.Equals(getCustomerObject.First().Id)
                            select booking.Value;

                        //Hittade customerItem i en bokning. Kasta exception.
                        if (joinCustomerAndBooking.FirstOrDefault() != default(VideoBooking))
                        {
                            throw new VideoRentalException(customerItem,
                                String.Format("Customer {0} already exists in a current Booking! BookingName: {1}, unable to Delete",
                                getCustomerObject.First().Name, joinCustomerAndBooking.First().Name));
                        }

                        //Hittade ingen aktuell bokning för customerItem, fortsätt med radering.
                        else if (joinCustomerAndBooking.FirstOrDefault() == default(VideoBooking))
                        {
                            CustomerDictionary.Remove(customerItem.Id);
                            return true;
                        }
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(customerItem,
                        String.Format("Customer: {0} does not exist in the datasource, unable to Delete",
                        customerItem.Name));
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
            throw new VideoRentalException(customerItem,
                String.Format("Customer: {0} is not a valid object to delete!", 
                customerItem.GetType().ToString()));
        }
        public bool DeleteVideoBooking(VideoBooking videoBookingItem)
        {
            if (videoBookingItem != null)
            {
                try
                {
                    //Kolla om videoBookingItem existerar i VideoBookingDictionary
                    IEnumerable<VideoBooking> getVideoBookingObject = GetVideoBooking(videoBookingItem);

                    if (getVideoBookingObject != null)
                    {
                        //Kolla om ett videoBookingItem är associerat med en Customer och Video
                        IEnumerable<VideoBooking> joinVideoCustomerAndBooking =
                            from booking in VideoBookingDictionary
                            join video in VideoDictionary on booking.Value.RentedVideo.Id equals video.Key
                            join customer in CustomerDictionary on booking.Value.CustomerID equals customer.Key
                            select booking.Value;

                        //Hittade en aktuell VideoBooking med matchande Customer och Video i resp. dictionary.
                        if (joinVideoCustomerAndBooking.FirstOrDefault() != default(VideoBooking))
                        {
                            VideoBookingDictionary.Remove(videoBookingItem.Id);
                            return true;
                        }

                        //Hittade ingen VideoBooking med matchande Customer och Video i  resp. dictionary.
                        else if (joinVideoCustomerAndBooking.FirstOrDefault() == default(VideoBooking))
                        {
                            throw new VideoRentalException(videoBookingItem,
                                String.Format("Unable to find and delete any Booking: {0} with a matching Customer and Video",
                                getVideoBookingObject.First().Name));
                        }
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(videoBookingItem,
                        String.Format("Booking: {0} does not exist in the datasource!",
                        videoBookingItem.Name));
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
            throw new VideoRentalException(videoBookingItem,
                String.Format("Booking: {0} is not a valid object to delete!",
                videoBookingItem.GetType().ToString()));
        }

        #endregion
    }
}
