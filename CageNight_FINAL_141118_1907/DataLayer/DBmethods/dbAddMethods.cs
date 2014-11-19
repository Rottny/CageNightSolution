using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBmethods
{
    class dbAddMethods
    {
      #region AddMethods

        public bool AddVideo( Video videoItem ) 
        {
            if (videoItem != null)
            {
                //Dictionary has items and the specified item does exist!
                if (VideoDictionary.Count > 0 && GetVideo(videoItem) != null)
                {
                    throw new VideoRentalException(videoItem,
                        String.Format("Video {0} already exists in datasource, could not add!", videoItem.Name));
                }

                //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                if ((VideoDictionary.Count > 0 && GetVideo(videoItem) == null) ||
                    (VideoDictionary.Count == 0))
                {
                    VideoDictionary.Add(videoItem.Id, videoItem);
                    return true;
                }
            }
            throw new VideoRentalException(videoItem, String.Format("Could not add video {0}", videoItem.Name));
        }
        public bool AddGenre( Genre genreItem )
        {
            if (genreItem != null)
            {
                //Dictionary has items and the specified item does exist!
                if (GenreDictionary.Count > 0 && GenreDictionary.Where(v => v.Key.Equals(genreItem.Id)).First().Value != null)
                {
                    throw new VideoRentalException(
                        genreItem, String.Format("Genre {0} already exists in datasource, could not add!", genreItem.Name));
                }

                //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                if ((GenreDictionary.Count > 0 && !(GenreDictionary.Where(v => v.Key.Equals(genreItem.Id)).First().Value != null)) ||
                    (GenreDictionary.Count == 0))
                {
                    GenreDictionary.Add(genreItem.Id, genreItem);
                    return true;
                }
            }
            throw new VideoRentalException(genreItem, String.Format("Could not add genre {0}", genreItem.Name));
        }
        public bool AddCustomer( Customer customerItem )
        {
            if (customerItem != null)
            {
                //Dictionary has items and the specified item does exist!
                if (CustomerDictionary.Count > 0 && CustomerDictionary.Where(v => v.Key.Equals(customerItem.Id)).First().Value != null)
                {
                    throw new VideoRentalException(
                        customerItem, String.Format("Customer {0} already exists in datasource, could not add!", customerItem.Name));
                }

                //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                if ((CustomerDictionary.Count > 0 && !(CustomerDictionary.Where(v => v.Key.Equals(customerItem.Id)).First().Value != null)) ||
                    (CustomerDictionary.Count == 0))
                {
                    CustomerDictionary.Add(customerItem.Id, customerItem);
                    return true;
                }
            }
            throw new VideoRentalException(customerItem, String.Format("Could not add customer {0}", customerItem.Name));
        }
        public bool AddVideoBooking( VideoBooking videoBookingItem )
        {
            if (videoBookingItem != null)
            {
                //Dictionary has items and the specified item does exist!
                if (VideoBookingDictionary.Count > 0 && VideoBookingDictionary.Where(v => v.Key.Equals(videoBookingItem.Id)).First().Value != null)
                {
                    throw new VideoRentalException(
                        videoBookingItem, String.Format("Booking already exists in datasource, {0}", videoBookingItem.Name));
                }

                //Dictionary has items and the specified item does not exist OR the dictionary is empty.
                if ((VideoBookingDictionary.Count > 0 && !(VideoBookingDictionary.Where(v => v.Key.Equals(videoBookingItem.Id)).First().Value != null)) ||
                    (VideoBookingDictionary.Count == 0))
                {
                    VideoBookingDictionary.Add(videoBookingItem.Id, videoBookingItem);
                    return true;
                }
            }
            throw new VideoRentalException(videoBookingItem, String.Format("Could not add booking {0}", videoBookingItem.Name));
        }

        #endregion
    }
}
