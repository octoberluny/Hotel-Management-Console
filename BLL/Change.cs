using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BLL
{
    [Serializable]
    public class Logic : ISerializable
    {
        private List<Client> cl = new List<Client>();
        private List<Realty> rl = new List<Realty>();

        public Logic() { }

        public void AddClient(string name, string surname, int account, int phone, string mail)
        {
            cl.Add(new Client(name, surname, account, phone, mail));
        }
        public void ChangeClientName(Client cl, string name)
        {
            cl.set_name(name);
        }
        public void ChangeClientSurname(Client cl, string surname)
        {
            cl.set_surname(surname);
        }
        public void ChangeClientAccount(Client cl, int account)
        {
            cl.set_account(account);
        }
        public void ChangeClientPhone(Client cl, int phone)
        {
            cl.set_phone(phone);
        }
        public void ChangeClientMail(Client cl, string mail)
        {
            cl.set_mail(mail);
        }
        public Client ViewClient(string name, string surname)
        {
            for (int i = 0; i < cl.Count(); i++)
                if (cl[i].get_name() == name && cl[i].get_surname() == surname)
                    return cl[i];
            return new Client("null", "null", 0, 0, "null");

        }
        //
        public bool AddRealtyToClient(Client client, Realty realty)
        {
            return client.AddRealty(realty);
        }
        public List<Client> ViewAllClients()
        {
            return cl;
        }

        public void AddRealty(string adress, string type, double price)
        {
            rl.Add(new Realty(adress, type, price));
        }
        public Realty ViewRealty(string adress, int k)
        {
            for (int i = 0; i < rl.Count(); i++)
                if (rl[i].get_adress() == adress)
                    return rl[i];
            return new Realty("null", "null", 0);
        }
        public void ChangeRealtyAdress(Realty realty, string adress)
        {
            realty.set_adress(adress);
        }
        public void ChangeRealtyType(Realty realty, string type)
        {
            realty.set_type(type);
        }
        public void ChangeRealtyPrice(Realty realty, double price)
        {
            realty.set_price(price);
        }
        public List<Realty> ViewAllRealty()
        {
            return rl;
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("clients", (object)cl, typeof(List<Client>));//упаквка обьектов
            info.AddValue("realty", (object)rl, typeof(List<Realty>));

        }
        public Logic(SerializationInfo info, StreamingContext context)
        {
            cl = (List<Client>)info.GetValue("clients", typeof(List<Client>));
            rl = (List<Realty>)info.GetValue("realty", typeof(List<Realty>));
        }
    }

}