using csharp_gestore_eventi;

//1.Nel vostro programma principale Program.cs, chiedete all’utente di inserire un
//nuovo evento con tutti i parametri richiesti dal costruttore.

Console.Write("Inserisci il nome dell'evento: ");
string titolo = Console.ReadLine();
Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
DateTime data = DateTime.Parse(Console.ReadLine());
Console.Write("Inserisci il numero di posti totali: ");
int capienza = int.Parse(Console.ReadLine());

Evento e = new Evento(titolo, data, capienza);

Console.Write("Quanti posti desideri prenotare? ");
int postiPrenotati = int.Parse(Console.ReadLine());

e.PrenotaPosti(postiPrenotati);
Console.WriteLine("");
Console.WriteLine($"Numero di posti prenotati = {postiPrenotati}");
Console.WriteLine($"Numero di posti disponibili = {e.CapienzaMassima - postiPrenotati}");
Console.WriteLine("");

string sceltaUtente = null;
while (sceltaUtente == "si" || sceltaUtente != "no")
{
    Console.WriteLine("");
    Console.Write("Vuoi disdire dei posti? (si/no)? ");
    sceltaUtente = Console.ReadLine();
   
    if (sceltaUtente == "si")
    {
        Console.Write("Indica il numero di posti da disdire: ");
        int postiDaRimuovere = int.Parse(Console.ReadLine());

        int postiPrenotatiAggionrati = e.DisdiciPosti(postiDaRimuovere);
        int postiDisponibiliAggiornati = e.CapienzaMassima - postiPrenotatiAggionrati;
        Console.WriteLine("");

        Console.WriteLine($"Numero di posti prenotati= {postiPrenotatiAggionrati}");
        Console.WriteLine($"Numero di posti disponibili= {postiDisponibiliAggiornati}");
    }
    else if (sceltaUtente == "no")
    {
        Console.WriteLine("Ok va bene!");
    }
}








