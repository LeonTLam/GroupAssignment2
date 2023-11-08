using GroupAssignment2.Areas.Identity.Data;
using GroupAssignment2.Models;

namespace GroupAssignment2.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<ApplicationUser> Users;
        public string? CurrentViewName;

        public UserListViewModel(IEnumerable<ApplicationUser> users, string? currentViewName)
        {
            Users = users;
            CurrentViewName = currentViewName;
        }
    }
}
