namespace WebApplicationTest.Models
{
    namespace MvcApp.Models
    {
        public class SortViewModel
        {
            public SortState FNameSort { get; set; } // значение для сортировки по имени
            public SortState LNameSort { get; set; }    // значение для сортировки по фамилии
            public SortState EmailSort { get; set; }   // значение для сортировки по электронной почте
            public SortState DateOfHireSort { get; set; } // значение для сортировки по дате приема на работу
            public SortState DateOfBirthSort { get; set; } // значение для сортировки по дате рождения
            public SortState PositionSort { get; set; } // значение для сортировки по должности
            public SortState AddressSort { get; set; } // значение для сортировки по адресу
            public SortState CitySort { get; set; } // значение для сортировки по городу
            public SortState RegionSort { get; set; } // значение для сортировки по региону

            public SortState Current { get; set; }// значение свойства, выбранного для сортировки
            public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

            public SortViewModel(SortState sortOrder)
            {
                // значения по умолчанию
                FNameSort = SortState.FNameAsc;
                LNameSort = SortState.LNameAsc;
                EmailSort = SortState.EmailAsc;
                DateOfHireSort = SortState.DateOfHireAsc;
                DateOfBirthSort = SortState.DateOfBirthAsc;
                PositionSort = SortState.PositionAsc;
                AddressSort = SortState.AddressAsc;
                CitySort = SortState.CityAsc;
                RegionSort = SortState.RegionAsc;

                Up = true;

                if (sortOrder == SortState.LNameDesc || sortOrder == SortState.FNameDesc
                    || sortOrder == SortState.EmailDesc || sortOrder == SortState.DateOfHireDesc
                    || sortOrder == SortState.DateOfBirthDesc || sortOrder == SortState.PositionDesc
                    || sortOrder == SortState.AddressDesc || sortOrder == SortState.CityDesc
                    || sortOrder == SortState.RegionDesc)
                {
                    Up = false;
                }

                switch (sortOrder)
                {
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
            }

            //public SortViewModel(SortState sortOrder, string sortProperty)
            //{
            //    // Установка свойств для сортировки
            //    switch (sortProperty)
            //    {
            //        case "FName":
            //            FNameSort = sortOrder;
            //            Current = FNameSort;
            //            break;
            //        case "LName":
            //            LNameSort = sortOrder;
            //            Current = LNameSort;
            //            break;
            //        case "Email":
            //            EmailSort = sortOrder;
            //            Current = EmailSort;
            //            break;
            //        case "DateOfHire":
            //            DateOfHireSort = sortOrder;
            //            Current = DateOfHireSort;
            //            break;
            //        case "DateOfBirth":
            //            DateOfBirthSort = sortOrder;
            //            Current = DateOfBirthSort;
            //            break;
            //        case "Position":
            //            PositionSort = sortOrder;
            //            Current = PositionSort;
            //            break;
            //        case "Address":
            //            AddressSort = sortOrder;
            //            Current = AddressSort;
            //            break;
            //        case "City":
            //            CitySort = sortOrder;
            //            Current = CitySort;
            //            break;
            //        case "Region":
            //            RegionSort = sortOrder;
            //            Current = RegionSort;
            //            break;
            //        default:
            //            // Если передано неизвестное свойство, устанавливаем сортировку по умолчанию
            //            Current = FNameSort = SortState.FNameDesc;
            //            break;
            //    }

            //    // Установка направления сортировки
            //    Up = sortOrder switch
            //    {
            //        SortState.LNameDesc or
            //        SortState.EmailDesc or
            //        SortState.DateOfHireDesc or
            //        SortState.DateOfBirthDesc or
            //        SortState.PositionDesc or
            //        SortState.AddressDesc or
            //        SortState.CityDesc or
            //        SortState.RegionDesc => false,
            //        _ => true,
            //    };
            //}
        }
    }
}
