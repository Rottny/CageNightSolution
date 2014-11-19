using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBmethods
{
    class dbGetCollectionMethods
    {
        #region GetCollectionMethods

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
    }
}
