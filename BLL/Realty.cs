using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Realty
    {

        public string adress;
        public string type;
        public double price;

        public Realty() { }
        public Realty(string adress, string type, double price)
        {
            this.adress = adress;
            this.type = type;
            this.price = price;

        }
        public string get_adress() { return adress; }
        public string get_type() { return type; }
        public double get_price() { return price; }
        public void set_adress(string adress) { this.adress = adress; }
        public void set_type(string type) { this.type = type; }
        public void set_price(double price) { this.price = price; }

        public override string ToString()
        {
            if (this.price != 0)
            {
                return "Адрес: " + this.adress + "\nТип недвижимости: " + this.type + "\nЦена: " + this.price;
            }
            else
                return "Ошибка. Недвижимости нет!";
        }
    }
}
