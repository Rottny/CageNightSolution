using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBmethods
{
    class dbGetMethods
    {
            #region GetMethods

        //Returnerar true om den hittar valt Item, null om den inte finns
        //Kastar ett generellt Exception om parametern Item är null.
        public IEnumerable<Video> GetVideo(Video videoItem)
        {
            if (videoItem != null)
            {
                IEnumerable<Video> queryVideoCollection =
                     from video in VideoDictionary
                     where video.Key.Equals(videoItem.Id)
                     select video.Value;

                if (queryVideoCollection.FirstOrDefault() != default(Video))
                    return queryVideoCollection;
                else
                    return null;
            }
            throw new Exception(String.Format("Could not Get the requested Video : {0} \n {1}", videoItem.GetType().ToString()));
        }
        public IEnumerable<Genre> GetGenre(Genre genreItem)
        {
            if (genreItem != null)
            {
                IEnumerable<Genre> queryGenreCollection =
                     from genre in GenreDictionary
                     where genre.Key.Equals(genreItem.Id)
                     select genre.Value;

                if (queryGenreCollection.FirstOrDefault() != default(Genre))
                    return queryGenreCollection;
                else
                    return null;
            }
            throw new Exception(String.Format("Could not get the requested Genre : {0}", genreItem.GetType().ToString()));
        }
        public IEnumerable<Customer> GetCustomer(Customer customerItem)
        {
            if (customerItem != null)
            {
                IEnumerable<Customer> queryCustomerCollection =
                     from customer in CustomerDictionary
                     where customer.Key.Equals(customerItem.Id)
                     select customer.Value;

                if (queryCustomerCollection.FirstOrDefault() != default(Customer))
                    return queryCustomerCollection;
                else
                    return null;
            }
            throw new Exception(String.Format("Could not get the requested Customer : {0}", customerItem.GetType().ToString()));
        }
        public IEnumerable<VideoBooking> GetVideoBooking(VideoBooking videoBookingItem)
        {
            if (videoBookingItem != null)
            {
                IEnumerable<VideoBooking> queryVideoBookingCollection =
                     from booking in VideoBookingDictionary
                     where booking.Key.Equals(videoBookingItem.Id)
                     select booking.Value;

                if (queryVideoBookingCollection.FirstOrDefault() != default(VideoBooking))
                    return queryVideoBookingCollection;
                else
                    return null;
            }
            throw new Exception(String.Format("Could not get the requested Booking : {0}", videoBookingItem.GetType().ToString()));
        }

        #endregion
    }
}
