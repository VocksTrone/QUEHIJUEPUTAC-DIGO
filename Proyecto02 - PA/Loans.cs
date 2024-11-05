using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02___PA
{
    public class Loans
    {
        public Books LoanBook { get; set; }
        public Reader Reader { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Loans(Books loanbook, Reader reader)
        {
            LoanBook = loanbook;
            Reader = reader;
            LoanDate = DateTime.Now;
            ReturnDate = null;
        }
        public void ReturnBook()
        {
            ReturnDate = DateTime.Now;
            LoanBook.Availability = true;
        }
    }
}