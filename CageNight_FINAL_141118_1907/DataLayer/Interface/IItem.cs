using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IItem
    {
        Guid Id { get; set; }
        String Name { get; set; }
    }
}
