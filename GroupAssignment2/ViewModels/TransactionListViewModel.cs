using GroupAssignment2.Areas.Identity.Data;
using GroupAssignment2.Models;

namespace GroupAssignment2.ViewModels
{
    public class TransactionListViewModel
    {
        public IEnumerable<Transaction>? Transactions { get; set; }

        public string? CurrentViewName;

        public TransactionListViewModel(IEnumerable<Transaction>? transactions, string? currentViewName)
        {
            Transactions = transactions;
            CurrentViewName = currentViewName;
        }
    }
}
