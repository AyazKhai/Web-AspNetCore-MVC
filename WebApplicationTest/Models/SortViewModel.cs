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
                    case SortState.FNameAsc:
                        Current = FNameSort = SortState.FNameDesc;
                        break;
                    case SortState.FNameDesc:
                        Current = FNameSort = SortState.FNameAsc;
                        break;
                    case SortState.LNameAsc:
                        Current = LNameSort = SortState.LNameDesc;
                        break;
                    case SortState.LNameDesc:
                        Current = LNameSort = SortState.LNameAsc;
                        break;
                    case SortState.EmailAsc:
                        Current = EmailSort = SortState.EmailDesc;
                        break;
                    case SortState.EmailDesc:
                        Current = EmailSort = SortState.EmailAsc;
                        break;
                    case SortState.DateOfHireAsc:
                        Current = DateOfHireSort = SortState.DateOfHireDesc;
                        break;
                    case SortState.DateOfHireDesc:
                        Current = DateOfHireSort = SortState.DateOfHireAsc;
                        break;
                    case SortState.DateOfBirthAsc:
                        Current = DateOfBirthSort = SortState.DateOfBirthDesc;
                        break;
                    case SortState.DateOfBirthDesc:
                        Current = DateOfBirthSort = SortState.DateOfBirthAsc;
                        break;
                    case SortState.PositionAsc:
                        Current = PositionSort = SortState.PositionDesc;
                        break;
                    case SortState.PositionDesc:
                        Current = PositionSort = SortState.PositionAsc;
                        break;
                    case SortState.AddressAsc:
                        Current = AddressSort = SortState.AddressDesc;
                        break;
                    case SortState.AddressDesc:
                        Current = AddressSort = SortState.AddressAsc;
                        break;
                    case SortState.CityAsc:
                        Current = CitySort = SortState.CityDesc;
                        break;
                    case SortState.CityDesc:
                        Current = CitySort = SortState.CityAsc;
                        break;
                    case SortState.RegionAsc:
                        Current = RegionSort = SortState.RegionDesc;
                        break;
                    case SortState.RegionDesc:
                        Current = RegionSort = SortState.RegionAsc;
                        break;
                    default:
                        Current = FNameSort = SortState.FNameDesc;
                        break;
                }

                //switch (sortOrder)
                //{
                //    case SortState.FNameDesc:
                //        FNameSort = SortState.FNameAsc;
                //        break;
                //    case SortState.LNameAsc:
                //        LNameSort = SortState.LNameDesc;
                //        break;
                //    case SortState.EmailAsc:
                //        EmailSort = SortState.EmailDesc;
                //        break;
                //    case SortState.DateOfHireAsc:
                //        DateOfHireSort = SortState.DateOfHireDesc;
                //        break;
                //    case SortState.DateOfBirthAsc:
                //        DateOfBirthSort = SortState.DateOfBirthDesc;
                //        break;
                //    case SortState.PositionAsc:
                //        PositionSort = SortState.PositionDesc;
                //        break;
                //    case SortState.AddressAsc:
                //        AddressSort = SortState.AddressDesc;
                //        break;
                //    case SortState.CityAsc:
                //        CitySort = SortState.CityDesc;
                //        break;
                //    case SortState.RegionAsc:
                //        RegionSort = SortState.RegionDesc;
                //        break;
                //    default:
                //        FNameSort = SortState.FNameDesc;
                //        break;
                //}

                //Current = sortOrder;
                //Up = sortOrder switch
                //{
                //    SortState.FNameDesc => false,
                //    SortState.LNameDesc => false,
                //    SortState.EmailDesc => false,
                //    SortState.DateOfHireDesc => false,
                //    SortState.DateOfBirthDesc => false,
                //    SortState.PositionDesc => false,
                //    SortState.AddressDesc => false,
                //    SortState.CityDesc => false,
                //    SortState.RegionDesc => false,
                //    _ => true
                //};
            }
        }
    }
}
