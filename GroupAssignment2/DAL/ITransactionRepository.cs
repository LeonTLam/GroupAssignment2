using GroupAssignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupAssignment2.DAL
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>?> GetAll();
        Task<bool> Create(Transaction transaction);
        Task<Transaction?> GetTransactionById(int id);
    }
}
