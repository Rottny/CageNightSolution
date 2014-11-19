using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBmethods
{
    class dbUpdateMethods
    {
       #region UpdateMethods

        //Updating: GenreID, VideoName(Title), NrOfDaysWOPenalty
        public bool UpdateVideo(Video videoItem, Video videoUpdateItem)
        {
            if (videoItem != null && videoUpdateItem != null)
            {
                try
                {
                    //Kolla om videoItem existerar i VideoDictionary
                    IEnumerable<Video> getVideoObject = GetVideo(videoItem);

                    if (getVideoObject != null)
                    {
                        Video videoToUpdate = getVideoObject.FirstOrDefault();
                        VideoDictionary.Where(v => v.Key.Equals(videoToUpdate.Id)).First().Value.GenreId = videoUpdateItem.GenreId;
                        VideoDictionary.Where(v => v.Key.Equals(videoToUpdate.Id)).First().Value.Name = videoUpdateItem.Name;
                        VideoDictionary.Where(v => v.Key.Equals(videoToUpdate.Id)).First().Value.NrOfDaysWOPenalty = videoUpdateItem.NrOfDaysWOPenalty;
                        return true;
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(videoItem,
                        String.Format("Video: {0} does not exist in datasource, unable to Update",
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
                String.Format("Video: {0} is not a valid type to update!",
                videoItem.GetType().ToString()));
        }

        //Updating: GenreName
        public bool UpdateGenre(Genre genreItem, Genre genreUpdateItem)
        {
            if (genreItem != null && genreUpdateItem != null)
            {
                try
                {
                    //Kolla om genreItem existerar i GenreDictionary
                    IEnumerable<Genre> getGenreObject = GetGenre(genreItem);

                    if (getGenreObject != null)
                    {
                        Genre genreToUpdate = getGenreObject.FirstOrDefault();
                        GenreDictionary.Where(g => g.Key.Equals(genreToUpdate.Id)).First().Value.Name = genreUpdateItem.Name;
                        return true;
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(genreItem,
                        String.Format("Genre: {0} does not exist in datasource, unable to Update",
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
                String.Format("Genre: {0} is not a valid type to update!",
                genreItem.GetType().ToString()));
        }

        //Updating: FName, EName
        public bool UpdateCustomer(Customer customerItem, Customer customerUpdateItem)
        {
            if (customerItem != null && customerUpdateItem != null)
            {
                try
                {
                    //Kolla om customerItem existerar i CustomerDictionary
                    IEnumerable<Customer> getCustomerObject = GetCustomer(customerItem);

                    if (getCustomerObject != null)
                    {
                        Customer customerToUpdate = getCustomerObject.FirstOrDefault();
                        CustomerDictionary.Where(c => c.Key.Equals(customerToUpdate.Id)).First().Value.FName = customerUpdateItem.FName;
                        CustomerDictionary.Where(c => c.Key.Equals(customerToUpdate.Id)).First().Value.EName = customerUpdateItem.EName;
                        return true;
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(customerItem,
                        String.Format("Customer: {0} does not exist in datasource, unable to Update",
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
                String.Format("Customer: {0} is not a valid type to update!",
                customerItem.GetType().ToString()));
        }

        //Updating: ReturnedDate, VideoID, CustomerID, Name (CustomerName + VideoName), Cost
        public bool UpdateVideoBooking(VideoBooking videoBookingItem, VideoBooking videoBookingUpdateItem)
        {
            if (videoBookingItem != null && videoBookingUpdateItem != null)
            {
                try
                {
                    //Kolla om videoBookingItem existerar i VideoBookingDictionary
                    IEnumerable<VideoBooking> getVideoBookingObject = GetVideoBooking(videoBookingItem);
                    VideoBooking vbo = getVideoBookingObject.FirstOrDefault();

                    if (vbo != default(VideoBooking))
                    {
                        //Hämta videoTiteln och customerName som ska uppdateras
                        Video video = VideoDictionary.Where(v => v.Key.Equals(videoBookingUpdateItem.VideoID)).FirstOrDefault().Value;
                        Customer customer = CustomerDictionary.Where(c => c.Key.Equals(videoBookingUpdateItem.CustomerID)).FirstOrDefault().Value;

                        //Kolla om vi hittade existerande video och customer i respektive datakälla.
                        if (video != default(Video) && customer != default(Customer))
                        {
                            VideoBookingDictionary.Where(vb => vb.Key.Equals(vbo.Id)).First().Value.Name = customer.Name + " : " + video.Name;
                        }
                        else if (video == default(Video) && customer == default(Customer))
                        {
                            throw new VideoRentalException(videoBookingUpdateItem,
                                    String.Format("Could not update VideoBooking, invalid Customer and Video"));
                        }

                        VideoBookingDictionary.Where(vb => vb.Key.Equals(vbo.Id)).First().Value.ReturnedDate = videoBookingUpdateItem.ReturnedDate;
                        VideoBookingDictionary.Where(vb => vb.Key.Equals(vbo.Id)).First().Value.VideoID = videoBookingUpdateItem.VideoID;
                        VideoBookingDictionary.Where(vb => vb.Key.Equals(vbo.Id)).First().Value.CustomerID = videoBookingUpdateItem.CustomerID;
                        VideoBookingDictionary.Where(vb => vb.Key.Equals(vbo.Id)).First().Value.Cost = videoBookingUpdateItem.Cost;
                        return true;
                    }

                    //Get-metoden misslyckades med att hitta aktuellt item i datakällan, kasta VideoRentalException!
                    throw new VideoRentalException(videoBookingItem,
                        String.Format("Booking: {0} does not exist in datasource, unable to Update",
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
                String.Format("Booking: {0} is not a valid type to update!",
                videoBookingItem.GetType().ToString()));
        }

        #endregion
    }
}
