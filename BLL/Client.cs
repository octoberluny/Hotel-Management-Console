using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Client
    {

        private const int MaxRealties = 4;

        public string name;
        public string surname;
        public int account;
        public int phone;
        public string mail;
        public List<Realty> realties = new List<Realty>();

        public Client() { }
        public Client(string name, string surname, int account, int phone, string mail)
        {
            this.name = name;
            this.surname = surname;
            this.account = account;
            this.phone = phone;
            this.mail = mail;
        }

        public string get_name() { return name; }
        public string get_surname() { return surname; }
        public int get_account() { return account; }
        public int get_phone() { return phone; }
        public string get_mail() { return mail; }
        public void set_name(string name) { this.name = name; }
        public void set_surname(string surname) { this.surname = surname; }
        public void set_account(int account) { this.account = account; }
        public void set_phone(int phone) { this.phone = phone; }
        public void set_mail(string mail) { this.mail = mail; }

        public bool AddRealty(Realty realty)
        {
            if (realties.Count >= 4) return false;
            realties.Add(realty);
            return true;
        }
        public bool RemoveRealty(Realty realty)
        {
            for (int i = 0; i < realties.Count; i++)
                if (realty == realties[i])
                {
                    realties.RemoveAt(i);
                    return true;
                }
            return false;
        }
        public bool ExistRealty(Realty exist)
        {
            foreach (Realty r in realties)
                if (r == exist)
                    return true;
            return false;
        }

        public override string ToString()
        {
            if (this.name != "null")
            {
                return "Клиент: " + this.name + " " + this.surname + "\nБанковский счет: " + this.account + "\nТелефон: " + this.phone + "\nПочта: " + this.mail;
            }
            else
                return "Ошибка. Клиентов нет!";
        }
    }
}
