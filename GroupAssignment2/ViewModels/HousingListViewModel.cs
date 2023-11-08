using GroupAssignment2.Models;

namespace GroupAssignment2.ViewModels
{
    public class HousingListViewModel
    {
        public IEnumerable<Housing> Housings;
        public string? CurrentViewName;

        public HousingListViewModel(IEnumerable<Housing> housings, string? currentViewName)
        {
            Housings = housings;
            CurrentViewName = currentViewName;
        }
    }
}
