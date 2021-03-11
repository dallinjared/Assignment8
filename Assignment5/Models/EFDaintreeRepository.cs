using System;
using System.Linq;

namespace Assignment5.Models
{
    public class EFDaintreeRepository : IDaintreeRepository
    {
        private DaintreeDBContext _context;

        //Constructor
        public EFDaintreeRepository (DaintreeDBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
