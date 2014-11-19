using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class Genre : IItem
    {
        #region Properties
        public Guid Id { get; set; }
        public String Name { get; set; }
        #endregion

        #region Constructors
        public Genre(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Genre(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion
    }
}
