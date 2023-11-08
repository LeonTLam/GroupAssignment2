using GroupAssignment2.Areas.Identity.Data;
using GroupAssignment2.Models;

namespace GroupAssignment2.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<ApplicationUser>? Customers { get; set; }
        public IEnumerable<Housing>? Housings { get; set; }
        public Housing? housing { get; set; }
        public Order? order { get; set; }
    }
}
