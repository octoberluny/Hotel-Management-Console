using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum SortingParameter { Name, Surname, Account, Type, Price };

    public static class SORTING
    {
        public static List<Client> SortClients(SortingParameter sorting_param, Logic L)
        {
            List<Client> SortedClientsList = L.ViewAllClients();

            if (sorting_param == SortingParameter.Name)         // по имени
                SortedClientsList.Sort(delegate (Client x, Client y)
                {
                    if (x.get_name() == y.get_name()) return 0;
                    else return x.get_name().CompareTo(y.get_name());
                });

            else if (sorting_param == SortingParameter.Surname) // по фамилии
                SortedClientsList.Sort(delegate (Client x, Client y)
                {
                    if (x.get_surname() == y.get_surname()) return 0;
                    else return x.get_surname().CompareTo(y.get_surname());
                });

            else if (sorting_param == SortingParameter.Account)  // по банковскому счёту
                SortedClientsList.Sort(delegate (Client x, Client y)
                {
                    if (x.get_account() == y.get_account()) return 0;
                    else return x.get_account().CompareTo(y.get_account());
                });

            else throw new Exception("Неверный параметр сортировки.");

            return SortedClientsList;
        }

        public static List<Realty> SortRealtys(SortingParameter sorting_param, Logic L)
        {
            List<Realty> SortedRealtysList = L.ViewAllRealty();

            if (sorting_param == SortingParameter.Type)       // по типу
                SortedRealtysList.Sort(delegate (Realty x, Realty y)
                {
                    if (x.get_type() == y.get_type()) return 0;
                    else return x.get_type().CompareTo(y.get_type());
                });

            else if (sorting_param == SortingParameter.Price) // по цене
                SortedRealtysList.Sort(delegate (Realty x, Realty y)
                {
                    if (x.get_price() == y.get_price()) return 0;
                    else return x.get_price().CompareTo(y.get_price());
                });

            else throw new Exception("Неверный параметр сортировки.");

            return SortedRealtysList;
        }
    }
}
