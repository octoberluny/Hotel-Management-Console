using System;
using System.Collections.Generic;
using System.Linq;

using DAL;
using BLL;

namespace PL
{ 
    class Menu
    {  
        public Logic lg;
        public Menu()
        {
            lg = (Logic)Serialization.Deserialize("price.txt");
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Пожалуйста, выберите номер:");
            Console.WriteLine("1. Действия с клиентом");
            Console.WriteLine("2. Действия с недвижимостью");
            Console.WriteLine("3. Управление предложениями недвижимости");
            Console.WriteLine("4. Поиск");
            Console.WriteLine("0. Сохранить и выйти");

            string s = Console.ReadLine();
            try
            {
                switch (s)
                {
                    case "1":
                        {
                            ClientMenu();
                            break;
                        }
                    case "2":
                        {
                            RealtyMenu();
                            break;
                        }
                    case "3":
                        {
                            ManageRealtyMenu();
                            break;
                        }
                    case "4":
                        {
                            SearchMenu();
                            break;
                        }
                    case "0":
                        {
                            Serialization.Serialize(lg, "price.txt");
                            System.Environment.Exit(0);
                            break;
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу");
                Console.ReadLine();
                MainMenu();
            }
        }
        public void ClientMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить клиента");
            Console.WriteLine("2. Удалить клиента");
            Console.WriteLine("3. Редактировать данные клиента");
            Console.WriteLine("4. Увидеть данные клиента (по имени и фамилии)");
            Console.WriteLine("5. Увидеть всех клиентов");
            Console.WriteLine("0. Вернуться в главное меню");
            string s = Console.ReadLine();
            try
            {
                switch (s)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        DeleteClient();
                        break;
                    case "3":
                        EditClient();
                        break;
                    case "4":
                        SeeClient();
                        break;
                    case "5":
                        SeeAllClient();
                        break;
                    case "0":
                        MainMenu();
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу");
                Console.ReadLine();
                ClientMenu();
            }

        }
        public void RealtyMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить недвижимость");
            Console.WriteLine("2. Удалить недвижимость");
            Console.WriteLine("3. Редактировать данные о недвижимости");
            Console.WriteLine("4. Увидеть данные недвижимости (по адресу)");
            Console.WriteLine("5. Увидеть всю недвижимость");
            Console.WriteLine("0. Вернуться в главное меню");
            string s = Console.ReadLine();
            try
            {
                switch (s)
                {
                    case "1":
                        AddRealty();
                        break;
                    case "2":
                        DeleteRealty();
                        break;
                    case "3":
                        EditRealty();
                        break;
                    case "4":
                        SeeRealty();
                        break;
                    case "5":
                        SeeAllRealty();
                        break;
                    case "0":
                        {
                            MainMenu();
                            break;
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавиу");
                Console.ReadLine();
                RealtyMenu();
            }
        }
        public void ManageRealtyMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Создать список предложений для клиента");
            Console.WriteLine("2. Найти доступную недвижимость за требованиями (тип, цена)");
            Console.WriteLine("3. Отклонить предложение недвижимости из списка");
            Console.WriteLine("4. Вывести список предложений клиента");
            Console.WriteLine("0. Вернуться в главное меню");
            string s = Console.ReadLine();
            try
            {
                switch (s)
                {
                    case "1":
                        AddList();
                        break;
                    case "2":
                        ClientNeeds();
                        break;
                    case "3":
                        DeleteNeeds();
                        break;
                    case "4":
                        AllList();
                        break;
                    case "0":
                        {
                            MainMenu();
                            break;
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadLine();
                RealtyMenu();
            }
        }
        public void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Поиск среди клиентов");
            Console.WriteLine("2. Поиск среди недвижимости");
            Console.WriteLine("3. Общий поиск");
            Console.WriteLine("4. Расширеный поиск клиента");
            Console.WriteLine("0. Вернуться в главное меню");
            string s = Console.ReadLine();
            try
            {
                switch (s)
                {
                    case "1":
                        SearchClient();
                        break;

                    case "2":
                        SearchRealty();
                        break;
                    case "3":
                        SearchAll();
                        break;
                    case "4":
                        SearchAllClient();
                        break;
                    case "0":
                        {
                            MainMenu();
                            break;
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadLine();
                RealtyMenu();
            }
        }

        //ClientMenu
        public void AddClient()
        {
            Console.Clear();
            Console.WriteLine("Введите данные клиента");
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            if (name.Length==0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите фамилию:");
            string surname = Console.ReadLine();
            if (surname.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите номер банковского счета цифрами:");
            int account = int.Parse(Console.ReadLine());
            if (account.ToString().Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите номер телефона цифрами:");
            int phone = int.Parse(Console.ReadLine());
            if (phone.ToString().Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите почту:");
            string mail = Console.ReadLine();
            if (mail.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }

            lg.AddClient(name, surname, account, phone, mail);
            Console.WriteLine("Клиент добавлен. Нажмите любую клавишу!");
            Console.ReadKey();
            ClientMenu();
        }
        public void DeleteClient()
        {
            Console.Clear();
            if (lg.ViewAllClients().Count() == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");

                Console.ReadKey();
                ClientMenu();
                return;
            }

            Console.WriteLine("Введите номер клиента, которого следует удалить:");
            SortingParameter sp = SortingParameter.Surname;
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int clientNumber;
            if (!int.TryParse(Console.ReadLine(), out clientNumber) || clientNumber < 0 || clientNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Клиент удален. Нажмите любую клавишу!");
            Console.ReadKey();
            lc.RemoveAt(clientNumber);
            ClientMenu();
        }
        public void EditClient()
        {
            Console.Clear();
            if (lg.ViewAllClients().Count() == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите номер клиента:");
            SortingParameter sp = SortingParameter.Surname;
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int clientNumber;
            if (!int.TryParse(Console.ReadLine(), out clientNumber) || clientNumber < 0 || clientNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }

            Client client = lc[clientNumber];

            Console.WriteLine("Выберите, что изменить:\n1 - имя, \n2 - фамилия, \n3 - банковский счет, \n4 - номер телефона, \n5 - почта");
            string _w = Console.ReadLine();
            switch (_w)
            {
                case "1":
                    {
                        //меняем имя
                        Console.Clear();
                        Console.WriteLine("Введите новое имя");
                        string q = Console.ReadLine();
                        lg.ChangeClientName(client, q);
                        Console.WriteLine(client);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        ClientMenu();
                        break;
                    }
                case "2":
                    {
                        //меняем фамилию
                        Console.Clear();
                        Console.WriteLine("Введите новую фамилию");
                        string q = Console.ReadLine();
                        lg.ChangeClientSurname(client, q);
                        Console.WriteLine(client);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        ClientMenu();
                        break;
                    }
                case "3":
                    {
                        //меняем банковский счет
                        Console.Clear();
                        Console.WriteLine("Введите новый банковский счет цифрами:");
                        int q = int.Parse(Console.ReadLine());
                        lg.ChangeClientAccount(client, q);
                        Console.WriteLine(client);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        ClientMenu();
                        break;
                    }
                case "4":
                    {
                        //меняем номер телефона
                        Console.Clear();
                        Console.WriteLine("Введите новый номер телефона цифрами:");
                        int q = int.Parse(Console.ReadLine());
                        lg.ChangeClientPhone(client, q);
                        Console.WriteLine(client);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        ClientMenu();
                        break;
                    }
                case "5":
                    {
                        //меняем почту
                        Console.Clear();
                        Console.WriteLine("Введите новую почту");
                        string q = Console.ReadLine();
                        lg.ChangeClientMail(client, q);
                        Console.WriteLine(client);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        ClientMenu();
                        break;
                    }
                default:
                    throw new Exception();
            }
            ClientMenu();
        }
        public void SeeClient()
        {
            Console.Clear();
            if (lg.ViewAllClients().Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Клиентов нет!");
                Console.ReadKey();
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите данные клиента");
            Console.WriteLine("Введите имя:");
            string _name = Console.ReadLine();
            if (_name.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите фамилию:");
            string _surname = Console.ReadLine();
            if (_surname.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine(lg.ViewClient(_name, _surname));
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            ClientMenu();
        }
        public void SeeAllClient()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип представления информации:");
            Console.WriteLine("1. Отсортировать клиентов по фамилии");
            Console.WriteLine("2. Отсортировать клиентов по имени");
            Console.WriteLine("3. Отсортировать клиентов по банковскому счету");
            Console.WriteLine("");
            Console.Write("Ваш выбор: ");
            if (lg.ViewAllClients().Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Клиентов нет!");
                Console.ReadKey();
                ClientMenu();
                return;
            }
            SortingParameter sp = 0;
            string w = Console.ReadLine();
            switch (w)
            {
                case "1": sp = SortingParameter.Surname; break;
                case "2": sp = SortingParameter.Name; break;
                case "3": sp = SortingParameter.Account; break;
                default: throw new Exception();
            }

            //выводим всех клиентов в цикле
            Console.Clear();
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(lc[i] + "\n");
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            ClientMenu();
        }

        //RealtyMenu
        public void AddRealty()
        {
            //добавление недвижимости - читаем поля недвижимости
            Console.Clear();
            Console.WriteLine("Введите данные о недвижимости");
            Console.WriteLine("Введите адрес:");
            string adress = Console.ReadLine();
            if (adress.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите тип недвижимости (1-комнатная квартира (1к), 2-комнатная (2к), 3-комнатная (3к), приватный участок (пу)):");
            string type = Console.ReadLine();
            if (type.Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }
            Console.WriteLine("Введите цену(int):");
            double price = double.Parse(Console.ReadLine());
            if (price.ToString().Length == 0)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                ClientMenu();
                return;
            }

            //добавляем недвижимость в лист
            lg.AddRealty(adress, type, price);
            Console.WriteLine("Недвижимость добавлена! Нажмите любую клавишу!");
            Console.ReadKey();
            RealtyMenu();
        }
        public void DeleteRealty()
        {
            Console.Clear();
            Console.WriteLine("Введите номер недвижимости, которую следует удалить:");

            if (lg.ViewAllRealty().Count() == 0)
            {
                Console.WriteLine("Недвижимости нет. Нажмите любую клавишу!");

                Console.ReadKey();
                RealtyMenu();
                return;
            }
            SortingParameter sp = SortingParameter.Type;
            List<Realty> lc = SORTING.SortRealtys(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int realtyNumber;
            if (!int.TryParse(Console.ReadLine(), out realtyNumber) || realtyNumber < 0 || realtyNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                RealtyMenu();
                return;
            }
            Console.WriteLine("Недвижимость удалена. Нажмите любую клавишу!");
            Console.ReadKey();
            lc.RemoveAt(realtyNumber);
            RealtyMenu();
        }
        public void EditRealty()
        {

            Console.Clear();
            Console.WriteLine("Введите данные о недвижимости");

            List<Realty> l = lg.ViewAllRealty();

            if (l.Count == 0)
            {
                Console.WriteLine("Недвижиммости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                RealtyMenu();
                return;
            }

            Console.WriteLine("Введите номер недвижимости, которую следует изменить:");
            for (int i = 0; i < l.Count; i++)
                Console.WriteLine(i + " " + l[i]);

            int realtyNumber;
            if (!int.TryParse(Console.ReadLine(), out realtyNumber) || realtyNumber < 0 || realtyNumber >= l.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }

            Console.Clear();

            Console.WriteLine(l[realtyNumber]);
            Console.WriteLine("Выберите, что изменить: 1 - адрес \n2 - тип, \n3 - цена");
            string w = Console.ReadLine();
            switch (w)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Введите адрес");
                        string _q = Console.ReadLine();
                        lg.ChangeRealtyAdress(l[realtyNumber], _q);
                        Console.WriteLine(l[realtyNumber]);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        RealtyMenu();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("Введите тип недвижимости");
                        string _q = Console.ReadLine();
                        lg.ChangeRealtyType(l[realtyNumber], _q);
                        Console.WriteLine(l[realtyNumber]);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        RealtyMenu();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Введите цену:");
                        double _q = double.Parse(Console.ReadLine());
                        lg.ChangeRealtyPrice(l[realtyNumber], _q);
                        Console.WriteLine(l[realtyNumber]);
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        RealtyMenu();
                        break;
                    }
                default:
                    throw new Exception();
            }

            Console.ReadKey();
            RealtyMenu();
        }
        public void SeeRealty()
        {
            Console.Clear();
            if (lg.ViewAllRealty().Count() == 0)
            {
                Console.WriteLine("Недвижимости нет");
                Console.ReadKey();
                RealtyMenu();
                return;
            }
            Console.WriteLine("Введите адрес недвижимости:");
            string adress = Console.ReadLine();
            Console.WriteLine(lg.ViewRealty(adress, 0));
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            RealtyMenu();
        }
        public void SeeAllRealty()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип представления информации:");
            Console.WriteLine("1. Отсортировать по типу недвижимости");
            Console.WriteLine("2. Отсортировать по цене недвижимости");
            Console.WriteLine("");
            Console.Write("Ваш выбор: ");
            if (lg.ViewAllRealty().Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Недвижимости нет!");
                Console.ReadKey();
                RealtyMenu();
                return;
            }
            SortingParameter sp = 0;
            string w = Console.ReadLine();
            switch (w)
            {
                case "1": sp = SortingParameter.Type; break;
                case "2": sp = SortingParameter.Price; break;
                default: throw new Exception();
            }
            Console.Clear();
            List<Realty> lr = SORTING.SortRealtys(sp, lg);
            for (int i = 0; i < lr.Count(); i++)
                Console.WriteLine(lr[i] + "\n");
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            RealtyMenu();
        }

        //ManageRealtyMenu
        public void AddList()
        {
            Console.Clear();
            Console.WriteLine("Создаем список предложений (максимум 4 недвижимости для клиента):");
            Console.WriteLine("Введите номер клиента:");

            if (lg.ViewAllClients().Count() == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            SortingParameter sp = SortingParameter.Surname;
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int clientNumber;
            if (!int.TryParse(Console.ReadLine(), out clientNumber) || clientNumber < 0 || clientNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            Console.WriteLine("Введите номер недвижимости:");

            sp = SortingParameter.Type;
            //выводим всех клиентов в цикле
            List<Realty> lr = SORTING.SortRealtys(sp, lg);
            int listOnScreenCount = 0;
            for (int i = 0; i < lr.Count(); i++)
                if (!lc[clientNumber].ExistRealty(lr[i]))
                    Console.WriteLine((listOnScreenCount = i) + " " + lr[i] + "\n");

            if (lg.ViewAllRealty().Count() == 0)
            {
                Console.WriteLine("Недвижимости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            if (listOnScreenCount == 0)
            {
                Console.WriteLine("Недвижимости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            int realtyNumber;
            if (!int.TryParse(Console.ReadLine(), out realtyNumber) || realtyNumber < 0 || realtyNumber > listOnScreenCount)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            if (!lg.AddRealtyToClient(lc[clientNumber], lr[realtyNumber]))
            {
                Console.WriteLine("Лимит недвижимости в списку превышен!");
                Console.ReadKey();
                ManageRealtyMenu();
            }
            Console.WriteLine("Недвижимость добавлена в список. Нажмите любую клавишу!");
            Console.ReadKey();
            ManageRealtyMenu();
        }
        public void ClientNeeds()
        { //За вимогами клієнта(тип і вартість) знайти чи доступні об`єкти нерухомості
            Console.Clear();
            if (lg.ViewAllRealty().Count() == 0)
            {
                Console.WriteLine("Недвижимости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            Console.WriteLine("Введите тип недвижимости (1к, 2к, 3к, пу):");
            string type = Console.ReadLine();
            Console.WriteLine("Введите минмиальную цену:");
            double minPrice;
            if (!double.TryParse(Console.ReadLine(), out minPrice))
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            Console.WriteLine("Введите максимальную цену:");
            double maxPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Доступная недвижимость:");

            foreach (Realty r in lg.ViewAllRealty())
                if (r.get_type() == type && r.get_price() >= minPrice && r.get_price() <= maxPrice)
                    Console.WriteLine(r);
            Console.ReadKey();
            ManageRealtyMenu();
        }
        public void DeleteNeeds()
        {
            Console.Clear();
            Console.WriteLine("Введите номер клиента:");

            if (lg.ViewAllClients().Count() == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            SortingParameter sp = SortingParameter.Surname;
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int clientNumber;
            if (!int.TryParse(Console.ReadLine(), out clientNumber) || clientNumber < 0 || clientNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }

            List<Realty> l = lg.ViewAllClients()[clientNumber].realties;

            if (l.Count == 0)
            {
                Console.WriteLine("Недвижиммости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            Console.WriteLine("Введите номер недвижимости, которую следует удалить:");
            for (int i = 0; i < l.Count; i++)
                Console.WriteLine(i + " " + l[i]);

            int realtyNumber;
            if (!int.TryParse(Console.ReadLine(), out realtyNumber) || realtyNumber < 0 || realtyNumber >= l.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }

            l.RemoveAt(realtyNumber);

            ManageRealtyMenu();
        }
        public void AllList()
        {
            Console.Clear();
            Console.WriteLine("Введите номер клиента:");

            if (lg.ViewAllClients().Count() == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }
            SortingParameter sp = SortingParameter.Surname;
            List<Client> lc = SORTING.SortClients(sp, lg);
            for (int i = 0; i < lc.Count(); i++)
                Console.WriteLine(i + " " + lc[i] + "\n");
            int clientNumber;
            if (!int.TryParse(Console.ReadLine(), out clientNumber) || clientNumber < 0 || clientNumber >= lc.Count)
            {
                Console.WriteLine("Ошибка ввода. Нажмите любую клавишу!");

                ManageRealtyMenu();
                return;
            }

            List<Realty> l = lg.ViewAllClients()[clientNumber].realties;

            if (l.Count == 0)
            {
                Console.WriteLine("Недвижиммости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                ManageRealtyMenu();
                return;
            }

            Console.WriteLine("Список недвижимости клиента:");
            for (int i = 0; i < l.Count; i++)
                Console.WriteLine(" " + l[i]);
            Console.ReadKey();
            ManageRealtyMenu();
        }

        //SearchMenu
        public void SearchClient()
        {
            Console.Clear();
            Console.WriteLine("Введите ключевое слово для поиска среди клиентов");

            if (lg.ViewAllClients().Count == 0)
            {
                Console.WriteLine("Клиентов нет. Нажмите любую клавишу!");
                SearchMenu();
                return;
            }
            string key = Console.ReadLine();
            int cnt = 0;

            List<Client> client = lg.ViewAllClients();

            for (int i = 0; i < lg.ViewAllClients().Count; i++)
            {
                if (client[i].name.Contains(key) || client[i].surname.Contains(key) || client[i].account.ToString().Contains(key) || client[i].phone.ToString().Contains(key) || client[i].mail.Contains(key))
                {
                    cnt++;
                }
            }
            Console.Clear();
            Console.WriteLine("Найдено совпадений: " + cnt);
            Console.WriteLine();
            if (cnt == 0)
            {
                Console.WriteLine("Не найдено ни одного совпадения.");
                Console.ReadKey();
                SearchMenu();
            }
            else
                for (int i = 0; i < lg.ViewAllClients().Count; i++)
                {
                    if (client[i].name.Contains(key) || client[i].surname.Contains(key) || client[i].account.ToString().Contains(key) || client[i].phone.ToString().Contains(key) || client[i].mail.Contains(key))
                    {
                        Console.WriteLine(client[i].ToString());
                    }
                }
            Console.ReadLine();
            SearchMenu();
            return;
        }
        public void SearchRealty()
        {
            Console.Clear();
            Console.WriteLine("Введите ключевое слово для поиска среди недвижимости");

            if (lg.ViewAllRealty().Count == 0)
            {
                Console.WriteLine("Недвижимости нет. Нажмите любую клавишу!");
                Console.ReadKey();
                SearchMenu();
                return;
            }
            string key = Console.ReadLine();
            int cnt = 0;

            List<Realty> realty = lg.ViewAllRealty();

            for (int i = 0; i < lg.ViewAllRealty().Count; i++)
            {
                if (realty[i].adress.Contains(key) || realty[i].type.Contains(key) || realty[i].price.ToString().Contains(key))
                {
                    cnt++;
                }
            }
            Console.Clear();
            Console.WriteLine("Найдено совпадений: " + cnt);
            Console.WriteLine();
            if (cnt == 0)
            {
                Console.WriteLine("Не найдено ни одного совпадения.");
            }
            for (int i = 0; i < lg.ViewAllRealty().Count; i++)
            {
                if (realty[i].adress.Contains(key) || realty[i].type.Contains(key) || realty[i].price.ToString().Contains(key))
                {
                    Console.WriteLine(realty[i].ToString());
                }
            }
            Console.ReadLine();
            SearchMenu();
            return;
        }
        public void SearchAll()
        {
            Console.Clear();
            Console.WriteLine("Введите ключевое слово для общего поиска:");

            if (lg.ViewAllRealty().Count == 0)
                if (lg.ViewAllClients().Count == 0)
                {
                    Console.WriteLine("Недвижимости и клиентов нет. Нажмите любую клавишу!");
                    Console.ReadKey();
                    SearchMenu();
                    return;
                }
            string key = Console.ReadLine();
            int cnt = 0;

            List<Realty> realty = lg.ViewAllRealty();
            List<Client> client = lg.ViewAllClients();

            for (int i = 0; i < lg.ViewAllRealty().Count; i++)
                if (realty[i].adress.Contains(key) || realty[i].type.Contains(key) || realty[i].price.ToString().Contains(key))
                {
                    cnt++;
                }
            for (int j = 0; j < lg.ViewAllClients().Count; j++)
            {
                if (client[j].name.Contains(key) || client[j].surname.Contains(key) || client[j].account.ToString().Contains(key) || client[j].phone.ToString().Contains(key) || client[j].mail.Contains(key))
                {
                    cnt++;
                }
            }
            Console.Clear();
            Console.WriteLine("Найдено совпадений: " + cnt);
            Console.WriteLine();
            if (cnt == 0)
            {
                Console.WriteLine("Не найдено ни одного совпадения.");
            }
            else
            {


                for (int i = 0; i < lg.ViewAllRealty().Count; i++)
                    if (realty[i].adress.Contains(key) || realty[i].type.Contains(key) || realty[i].price.ToString().Contains(key))
                {
                        Console.WriteLine("Найдено недвижимость:\n");
                        Console.WriteLine(realty[i].ToString());
                    }
                for (int j = 0; j < lg.ViewAllClients().Count; j++)
                {
                    if (client[j].name.Contains(key) || client[j].surname.Contains(key) || client[j].account.ToString().Contains(key) || client[j].phone.ToString().Contains(key) || client[j].mail.Contains(key))
                    {
                        Console.WriteLine("Найдено клиентов:");
                        Console.WriteLine(client[j].ToString());
                    }
                }
            }
            Console.ReadLine();
            SearchMenu();
            return;
        }
        public void SearchAllClient() 
            // Расширеный поиск клиента (по фамилии и бажаному типу недвижимости)
        {
            Console.Clear();
            Console.WriteLine("Если некоторые поля Вас не интересуют - оставьте их пустыми: \n");
            Console.WriteLine("Введите данные клиента");
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите номер банковского счета:");
            string account = Console.ReadLine();
            Console.WriteLine("Введите номер телефона:");
            string phone = Console.ReadLine();
            Console.WriteLine("Введите почту:");
            string mail = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Введите данные о недвижимости");
            Console.WriteLine("Введите адрес:");
            string adress = Console.ReadLine();
            Console.WriteLine("Введите тип недвижимости (1-комнатная квартира (1к), 2-комнатная (2к), 3-комнатная (3к), приватный участок (пу)):");
            string type = Console.ReadLine();
            Console.WriteLine("Введите цену:");
            string price = Console.ReadLine();

            foreach(Client client in lg.ViewAllClients())
            {
                if (
                    (client.name.Contains(name) || name == "") &&
                    (client.surname.Contains(surname) || surname == "") &&
                    (client.account.ToString().Contains(account) || account == "") &&
                    (client.phone.ToString().Contains(phone) || phone == "") &&
                    (client.mail.Contains(mail) || mail == "")
                )
                {
                    foreach (Realty realty in client.realties)
                    {
                        if (
                            (realty.adress.Contains(adress) || adress == "") &&
                            (realty.type.Contains(type) || type == "") &&
                            (realty.price.ToString().Contains(price) || price == "")

                        )
                        {
                            Console.WriteLine(client);
                            Console.WriteLine(realty);
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.ReadLine();
            SearchMenu();
        }
    }
}
