using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        public string titolo;
        public DateTime data;
        public int capienzaMassima;
        public int postiPrenotati { get; private set; }
        public string Titolo {
            get{

                return titolo;
            }
           set {
                try{
                    titolo = value;
                    if (titolo == null)
                        throw new Exception();
                }catch(Exception e){
                    Console.WriteLine("Il nome non può essere vuoto");
                }
            } 
        }
        public DateTime Data
        {
            get{
                return data;
            }
            set{
                try
                {
                   data = value;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Inserisci una data successiva alla data odierna");
                }
            }
        }
        
        public int CapienzaMassima
        {
            get
            {
                return capienzaMassima;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "La capienza massima non può essere inferiore o uguale a 0"
                     );
                }
                capienzaMassima = value;
            }
        }
    

        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            this.Titolo = titolo;
            this.Data = data;
            this.CapienzaMassima = capienzaMassima;
            this.postiPrenotati = 0;
        }
        //. PrenotaPosti: aggiunge i posti passati come parametro ai posti prenotati. Se
        //l’evento è già passato o non ha posti o non ha più posti disponibili deve sollevare
        //un’eccezione.
        public void PrenotaPosti(int prenotaPosto)
        {
            try
            {
                if (DateTime.Now.CompareTo(this.Data) > 0 || this.CapienzaMassima == 0 ||  this.CapienzaMassima - this.postiPrenotati <= 0)
                {
                    throw new Exception();
                }
                this.postiPrenotati += prenotaPosto;
            }catch (Exception e)
            {
                Console.WriteLine("Errore nella prenotazione! Assicurati di aver scritto i dati correttamente");
            }
        }
        //DisdiciPosti: riduce del i posti prenotati del numero di posti indicati come
        //parametro.Se l’evento è già passato o non ci sono i posti da disdire
        //sufficienti, deve sollevare un’eccezione
        public int DisdiciPosti(int disdiciPosti)
        {
            try
            {
                if (DateTime.Now.CompareTo(this.Data) > 0 || this.postiPrenotati < disdiciPosti)
                {
                    throw new Exception();
                }
                this.postiPrenotati -= disdiciPosti;
                Console.WriteLine("");
                Console.WriteLine("Operazione completata con successo");
                Console.WriteLine("");
                return this.postiPrenotati;

            }
            catch (Exception e)
            {
                Console.WriteLine("******************");
                Console.WriteLine("Non è possibile disdire il posto prenotato,assicurati di aver inserito i dati correttamente");
                Console.WriteLine("******************");
                return 0;
            }
        }

        //l’override del metodo ToString() in modo che venga restituita una stringa
        //contenente: data formattata – titolo
        //Per formattare la data correttamente usate
        //nomeVariabile.ToString("dd/MM/yyyy"); applicata alla vostra variabile
        //DateTime.
        public override string ToString()
        {
            return this.Data.ToString($"dd/MM/yyyy - {this.Titolo}");
        }
    }
}






































//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace csharp_gestore_eventi
//{
//    public class Evento
//    {
//        public string titolo;
//        public DateTime data;
//        public int capienzaMassima;
//        public int postiPrenotati { get; private set; }

//        public string Titolo
//        {
//            get { return titolo; }
//            set
//            {
//                try
//                {
//                    titolo = value;
//                    if (titolo == null)
//                        throw new Exception();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("è obbligatorio inserire il titolo!");
//                }
//            }
//        }

//        public DateTime Data
//        {
//            get { return data; }
//            set
//            {
//                try
//                {
//                    data = value;

//                    if (DateTime.Now.CompareTo(this.data) > 0)
//                        throw new Exception();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("Non puoi inserire una data già trascorsa!");
//                }
//            }
//        }
//        public int CapienzaMassima
//        {
//            get { return capienzaMassima; }
//            private set
//            {
//                try
//                {
//                    capienzaMassima = value;

//                    if (capienzaMassima <= 0)
//                        throw new Exception();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("La capienza deve essere un numero positivo!");
//                }
//            }
//        }


//        public Evento(string titolo, DateTime data, int capienzaMassima)
//        {
//            Titolo = titolo;
//            Data = data;
//            CapienzaMassima = capienzaMassima;
//            this.postiPrenotati = 0;
//        }

//        public void PrenotaPosti(int numeroPosti)
//        {

//            try
//            {
//                if (this.capienzaMassima == 0 || DateTime.Now.CompareTo(this.data) > 0 || this.capienzaMassima - this.postiPrenotati <= 0 || this.CapienzaMassima < numeroPosti)
//                {
//                    throw new Exception();
//                }
//                this.postiPrenotati += numeroPosti;
//                Console.WriteLine("Posti prenotati, hai riservato " + numeroPosti + " posti per te");

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Errore nella prenotazione! Assicurati di aver scritto i dati correttamente");
//            }
//        }

//        public int DisdiciPosti(int postiDaRimuovere)
//        {
//            try
//            {
//                if (DateTime.Now.CompareTo(this.data) > 0 || this.postiPrenotati < postiDaRimuovere)
//                {
//                    throw new Exception();
//                }
//                this.postiPrenotati -= postiDaRimuovere;
//                Console.WriteLine("Disdetta avvenuta con successo!");

//                return this.postiPrenotati;

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Errore nella disdetta! Assicurati di aver scritto i dati correttamente");
//                return 0;
//            }

//        }

//        public override string ToString()
//        {
//            return this.data.ToString("dd/MM/yyyy") + "- " + this.titolo;
//        }
//    }
//}