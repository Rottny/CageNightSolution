using DataLayer.Exceptions;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class Customer : IItem
    {
        #region Properties
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string EName { get; set; }
        public string Name
        {
            get { return String.Format("{0} {1}", FName, EName); }
            set { String.Format("{0} {1}", FName, EName); }
        }

        #endregion

        #region Constructors

        public Customer(Guid id, string forename, string surname)
        {
            Id = id;
            FName = forename;
            EName = surname;
        }

        public Customer(string fname, string ename)
        {
            Id = Guid.NewGuid();
            FName = fname;
            EName = ename;
        }

        #endregion
    }
}
