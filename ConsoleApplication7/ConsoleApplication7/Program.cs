using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{

    interface IPagos
    {
        void Pagar();
    }

    public class Visa : IPagos
    {
        public int importe { get; set; }
        public string CCC { get; set; }
        
        public void Pagar() 
        {
            Console.WriteLine("Pagado con Visa\n...importe: " + importe + "\n...cuenta: " + CCC);
        }
    }
    public class MasterCar : IPagos
    {
        public int importe { get; set; }
        public string CCC { get; set; }
        public string contraseña { get; set; }
        
        public void Pagar()
        {
            Console.WriteLine("Pagado con MasterCard\n...importe: " + importe + "\n...cuenta: " + CCC + "\n...contrasenya: " + contraseña);
        }
    }


    static class Factory
    {
        public static Object CreaTarjeta(Type type) 
        {
            return Activator.CreateInstance(type);
        }
    }


    public class Program 
    {
        public enum TipoPago
        {
            Visa,
            MasterCar
        }

        public static void Main(string[] args)
        {
            //var item = new Visa();
            //var item = Activator.CreateInstance<Visa>();
            Visa item = (Visa)Factory.CreaTarjeta(typeof(Visa));
            if(item == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }
            item.importe = 1001;
            item.CCC = "cuenta Visa";
            item.Pagar();

            //var item2 = Activator.CreateInstance<MasterCar>();
            MasterCar item2 = (MasterCar)Factory.CreaTarjeta(typeof(MasterCar));
            if (item2 == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }
            item2.importe = 555;
            item2.CCC = "cuenta MasterCard";
            item2.contraseña = "lololoPOPOPO";
            item2.Pagar();
            
        }
        //--------------METODOS--------------


    }//Program

    
 
}
