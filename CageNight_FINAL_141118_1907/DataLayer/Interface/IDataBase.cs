using DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IDataBase
    {
        int VideoCount { get; }
        int GenreCount { get; }
        int VideoBookingCount { get; }
        int CustomerCount { get; }

        bool AddVideo(Video videoItem);
        bool AddGenre(Genre genreItem);
        bool AddCustomer(Customer customerItem);
        bool AddVideoBooking(VideoBooking videoBooking);

        IEnumerable<Video> GetVideo(Guid videoID, string videoName, Video videoItem);
        IEnumerable<Genre> GetGenre(Guid genreID, string genreName, Genre genreItem);
        IEnumerable<Customer> GetCustomer(Guid customerID, string customerName, Customer customerItem);
        IEnumerable<VideoBooking> GetVideoBooking(Guid videoBookingID, string videoBookingName, VideoBooking videoBookingItem);

        bool DeleteVideo(Video videoItem);
        bool DeleteGenre(Genre genreItem);
        bool DeleteCustomer(Customer customerItem);
        bool DeleteVideoBooking(VideoBooking videoBooking);

        bool UpdateVideo(Video videoItem, Video videoItemToUpdate);
        bool UpdateGenre(Genre genreItem, Genre genreItemToUpdate);
        bool UpdateCustomer(Customer customerItem, Customer customerItemToUpdate);
        bool UpdateVideoBooking(VideoBooking videoBooking, VideoBooking videoBookingItemToUpdate);

        IEnumerable<Video> GetVideoCollection();
        IEnumerable<Genre> GetGenreCollection();
        IEnumerable<Customer> GetCustomerCollection();
        IEnumerable<VideoBooking> GetVideoBookingCollection();

        bool RentVideo(VideoBooking videoBooking, Video video, Customer customer);
        bool ReturnVideo(VideoBooking videoItem);
    }
}
