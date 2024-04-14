namespace WebApplicationTest.Models
{
    namespace MvcApp.Models
    {
        public class SortViewModel
        {
            // Значения для сортировки по разным полям
            public SortState FNameSort { get; set; }
            public SortState LNameSort { get; set; }
            public SortState EmailSort { get; set; }
            public SortState DateOfHireSort { get; set; }
            public SortState DateOfBirthSort { get; set; }
            public SortState PositionSort { get; set; }
            public SortState AddressSort { get; set; }
            public SortState CitySort { get; set; }
            public SortState RegionSort { get; set; }

            public SortState Current { get; set; } // Значение свойства, выбранного для сортировки
            public bool Up { get; set; }  // Флаг сортировки по возрастанию или убыванию

            public SortViewModel(SortState sortOrder)
            {
                // Значения по умолчанию для различных полей сортировки
                FNameSort = SortState.FNameAsc;
                LNameSort = SortState.LNameAsc;
                EmailSort = SortState.EmailAsc;
                DateOfHireSort = SortState.DateOfHireAsc;
                DateOfBirthSort = SortState.DateOfBirthAsc;
                PositionSort = SortState.PositionAsc;
                AddressSort = SortState.AddressAsc;
                CitySort = SortState.CityAsc;
                RegionSort = SortState.RegionAsc;

                Up = true; // Исходно сортировка устанавливается по возрастанию

                // Проверка направления сортировки и установка флага Up соответственно
                if (sortOrder == SortState.LNameDesc || sortOrder == SortState.FNameDesc
                    || sortOrder == SortState.EmailDesc || sortOrder == SortState.DateOfHireDesc
                    || sortOrder == SortState.DateOfBirthDesc || sortOrder == SortState.PositionDesc
                    || sortOrder == SortState.AddressDesc || sortOrder == SortState.CityDesc
                    || sortOrder == SortState.RegionDesc)
                {
                    Up = false;
                }

                // Установка текущего направления сортировки в соответствии с переданным sortOrder
                switch (sortOrder)
                {
                    case SortState.FNameDesc:
                        Current = FNameSort = SortState.FNameAsc;
                        break;
                    case SortState.LNameAsc:
                        Current = LNameSort = SortState.LNameDesc;
                        break;
                    // ... аналогичные блоки для остальных полей сортировки
                    default:
                        Current = FNameSort = SortState.FNameDesc;
                        break;
                }
            }
        }
    }
}
