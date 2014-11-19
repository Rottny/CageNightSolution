using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class Video : IItem
    {
        #region Properties
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public bool bIsRented { get; set; }
        public int NrOfDaysWOPenalty { get; set; }
        #endregion

        #region Constructors
        public Video(Guid genreId, bool IsRented, string title, int nrOfDaysWOPenalty)
        {
            Id = Guid.NewGuid();
            GenreId = genreId;
            Name = title;
            bIsRented = IsRented;
            NrOfDaysWOPenalty = nrOfDaysWOPenalty;
        }

        public Video(Guid videoId, Guid genreId, bool IsRented, string title, int nrOfDaysWOPenalty)
        {
            Id = videoId;
            GenreId = genreId;
            Name = title;
            bIsRented = IsRented;
            NrOfDaysWOPenalty = nrOfDaysWOPenalty;
        }
        #endregion
    }
}
