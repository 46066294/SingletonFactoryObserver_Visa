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
            Console.WriteLine("\nPagado con Visa\n...importe: " + importe + "\n...cuenta: " + CCC);
        }
    }
    public class MasterCard : IPagos
    {
        public int importe { get; set; }
        public string CCC { get; set; }
        public string contraseña { get; set; }

        public void Pagar()
        {
            Console.WriteLine("\nPagado con MasterCard\n...importe: " + importe + 
                "\n...cuenta: " + CCC + "\n...contrasenya: " + contraseña);
        }
    }

         //static
    public sealed class FactorySingleton
    {                                        
        //private static readonly FactorySingleton instance = new FactorySingleton(typeof(MasterCard));
        private static readonly FactorySingleton instance = new FactorySingleton();
        private List<Object> tarjetas { get; set;}

        private FactorySingleton()
        {
            //tarjetas.Add(this);
            Console.WriteLine("...desde constructor FactorySingleton sin NINgun parametro");
        }

        public static FactorySingleton Instance
        {
            get
            {
                return instance;
            }
        }

        // Propiedad para acceder a la instancia
        public static Object CreaObjetoParaTarjeta(Type type) 
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
            
            //Console.WriteLine("\nTipo de tarjeta:");
            //var input = Console.ReadLine();

            var TipoDeTarjeta = Type.GetType("ConsoleApplication7.Visa"/* + input*/);
            //var TarjetaTipada = TipoDeTarjeta.GetConstructors()[0].Invoke(new object[] { });
            Visa item = (Visa)FactorySingleton.CreaObjetoParaTarjeta(TipoDeTarjeta);
            if (item == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }
            item.importe = 1001;
            item.CCC = "111-222-333-Visa";
            item.Pagar();
            Console.WriteLine("Tipo de dato: " + item.GetType());




            var TipoDeTarjeta2 = Type.GetType("ConsoleApplication7.MasterCard"/* + input*/);
            //var TarjetaTipada = TipoDeTarjeta.GetConstructors()[0].Invoke(new object[] { });
            MasterCard item2 = (MasterCard)FactorySingleton.CreaObjetoParaTarjeta(TipoDeTarjeta2);
            if (item2 == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }
            item2.importe = 999;
            item2.CCC = "999-888-777-MasterCard";
            item2.contraseña = "testingPass";
            item2.Pagar();
            Console.WriteLine("Tipo de dato: " + item2.GetType());



                
            
            /*
            Visa item = (Visa)FactorySingleton.CreaObjetoParaTarjeta(typeof(Visa));
            if(item == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }

            item.importe = 1001;
            item.CCC = "cuenta Visa";
            item.Pagar();
            
            MasterCard item2 = (MasterCard)FactorySingleton.CreaObjetoParaTarjeta(typeof(MasterCard));
            if (item2 == null)
            {
                throw new System.ArgumentNullException("...valor nulo::EL TIPO INTRODUCIDO NO EXISTE");
            }

            item2.importe = 555;
            item2.CCC = "cuenta MasterCard";
            item2.contraseña = "testingPass";
            item2.Pagar();*/
            
        }
        //--------------METODOS--------------


    }//Program

    
 
}
