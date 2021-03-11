using System;
using System.Linq;

namespace Assignment5.Models
{
    public interface IDaintreeRepository
    {
        IQueryable<Book> Books { get; }
    }
}
