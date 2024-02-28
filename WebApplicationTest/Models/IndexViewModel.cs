using WebApplicationTest.Models.MvcApp.Models;

namespace WebApplicationTest.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Emploee> Emploees { get; set; } = new List<Emploee>();
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? minstanding { get; set; }
        public SortViewModel SortViewModel { get; set; } = new SortViewModel(SortState.FNameAsc);

        public int[] EmployeeIds { get; set; }
    }
}
