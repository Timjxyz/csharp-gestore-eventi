using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        private string titolo {
            get{

                return this.titolo;
            }
            set { 
                if(value == null){
                    throw new ArgumentException( "Il nome non può essere vuoto!!");
                }
                this.titolo = value;
            }
        }
        private DateTime data
        {
            get{
                return this.data;
            }
            set{
                try
                {
                    this.data = value;

                }
                catch (Exception e)
                {
                    Console.WriteLine("Inserisci una data successiva alla data odierna");
                }
            }
        }
        
        private int capienzaMassima
        {
            get
            {
                return this.capienzaMassima;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "La capienza massima non può essere inferiore o uguale a 0"
                     );
                }
                this.capienzaMassima = value;
            }
        }
        public int postiPrenotati { get; private set; }

        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            this.titolo = titolo;
            this.data = data;
            this.capienzaMassima = capienzaMassima;
            this.postiPrenotati = 0;
        }
        //. PrenotaPosti: aggiunge i posti passati come parametro ai posti prenotati. Se
        //l’evento è già passato o non ha posti o non ha più posti disponibili deve sollevare
        //un’eccezione.
        public void PrenotaPosti(int prenotaPosto)
        {
            try
            {
                if (DateTime.Now.CompareTo(this.data) > 0 || this.capienzaMassima == 0 ||  this.capienzaMassima - this.postiPrenotati <= 0)
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
        public void DisdiciPostii(int disdiciPosti)
        {
            try
            {
                if (DateTime.Now.CompareTo(this.data) > 0 || this.postiPrenotati < disdiciPosti)
                {
                    throw new Exception();
                }
                this.postiPrenotati -= disdiciPosti;

            }
            catch (Exception e)
            {
                Console.WriteLine("******************");
                Console.WriteLine("Non è possibile disdire il posto prenotato,assicurati di aver inserito i dati correttamente");
                Console.WriteLine("******************");
            }
        }

        //l’override del metodo ToString() in modo che venga restituita una stringa
        //contenente: data formattata – titolo
        //Per formattare la data correttamente usate
        //nomeVariabile.ToString("dd/MM/yyyy"); applicata alla vostra variabile
        //DateTime.
        public override string ToString()
        {
            return this.data.ToString($"dd/MM/yyyy - {this.titolo}");
        }
    }
}

