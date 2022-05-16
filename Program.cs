namespace es05_mattina // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Banca MiaBanca = new Banca("Banca di Italia");
            Cliente mioCliente = new Cliente { CodiceFiscale = "aaaaaa", Nome = "Mario", Cognome = "Rossi", Stipendio = 15 };
            string sAppo = mioCliente.ToString();
            MiaBanca.UpdateCliente("abc", 12.5);

            Console.WriteLine("Lista operazioni:");
            Console.WriteLine("1 immetti nuovo cliente");
            Console.WriteLine("2 modifica cliente");
            Console.WriteLine("3 rimuovi cliente");
            Console.WriteLine("4 cerca cliente");
            Console.WriteLine("5 cerca prestiti per cliente");


            Console.WriteLine("Cosa vuoi fare?");
            string sOperazione = Console.ReadLine();

            while (sOperazione != "")
            {

                //Verifica codice operazione dell'utente

                if (Convert.ToInt32(sOperazione) == 1)
                {
                    /* Console.WriteLine("Inserisci il nome:");
                    string sNome = Console.ReadLine();
                    Console.WriteLine("Inserisci il cognome:");
                    string sCognome = Console.ReadLine();
                    Console.WriteLine("Inserisci il Codice Fiscale:");
                    string sCodiceFiscale = Console.ReadLine();
                    Console.WriteLine("Inserisci il tuo stipendio:");
                    double dStipendio = Console.ReadLine(); */

                    Console.WriteLine("hai aggiunto un cliente");

                    MiaBanca.AggiungiCliente("Mario", "Rossi", "aaaaaa", 10.5);
                    break;


                }
                else if (Convert.ToInt32(sOperazione) == 2)
                {
                    MiaBanca.UpdateCliente("aaaaaa", 12.5);
                    break;
                }
                else if (Convert.ToInt32(sOperazione) == 3)
                {
                    MiaBanca.RimuoviCliente("aaaaaa");
                    break;
                }
                else if (Convert.ToInt32(sOperazione) == 4)
                {
                    MiaBanca.RicercaPrestito("aaaaaa");
                    break;
                }
                else if (Convert.ToInt32(sOperazione) == 5)
                {
                    MiaBanca.NumeroPrestitiCliente("aaaaaa");
                    break;
                }
                else if (Convert.ToInt32(sOperazione) == 6)
                {


                    MiaBanca.AggiungiPrestito(10000.0, 500.0, new DateTime(2020, 12, 24), new DateTime(2021, 12, 24), "aaaaaa");
                    Console.WriteLine("Prestito Aggiunto");
                    break;
                }
                else if (Convert.ToInt32(sOperazione) == 7)
                {
                    MiaBanca.NumeroPrestitiCliente("aaaaaa");
                    break;
                }

                Console.WriteLine("Cosa vuoi fare?");
            }






            /*
            Console.WriteLine("Lista operazioni:");
            Console.WriteLine("1 immetti nuovo studente");
            Console.WriteLine("2 immetti nuova sede");

            //Creo istanza Università
             universita lMiaUniversita = new universita();

            //Carichiamo i dati dal file di un disco condiviso 
            //e li mettiamo nella mia istanza Università





            Console.WriteLine("Cosa vuoi fare?");
            string sOperazione = Console.ReadLine();

            while(sOperazione != "")
            {

                //Verifica codice operazione dell'utente

                if (Convert.ToInt32(sOperazione) == 1)
                {
                    Console.WriteLine("Inserisci il nome:");
                    string sNome = Console.ReadLine();
                    Console.WriteLine("Inserisci il cognome:");
                    string sCognome = Console.ReadLine();
                    Console.WriteLine("Inserisci la data di nascita:");
                    string sDataNascita = Console.ReadLine();
                    lMiaUniversita.AggiungiStudente(sNome, sCognome, sDataNascita)
                }
                else if(Convert.ToInt32(sOperazione) == 2)
                {
                    Console.WriteLine("Inserisci la sede:");
                    string sSede = Console.ReadLine();
                    lMiaUniversita.AggiungiSede(sSede); 
                }

                Console.WriteLine("Cosa vuoi fare?");
            }

            //Scarica i dati nel file (salviamo i dati)

            */
        }
    }
}
