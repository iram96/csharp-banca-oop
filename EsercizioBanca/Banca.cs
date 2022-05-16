/*Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.La banca è caratterizzata da - un nome - un insieme di clienti (una lista) - un insieme di prestiti concessi ai clienti (una lista)I clienti sono caratterizzati da - nome, - cognome, - codice fiscale - stipendioI prestiti sono caratterizzati da - intestatario del prestito (il cliente), - un ammontare, una rata, - una data inizio, - una data fine. Per la banca deve essere possibile:- aggiungere, modificare, eliminare e ricercare un cliente. - aggiungere un prestito. - effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale - sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere. */

namespace es05_mattina
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public double Stipendio { get; set; }

    }

    public class Prestito
    {
        public double Ammontare { get; set; }
        public double Rata { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public string CF { get; set; }
    }

    public class Banca
    {
        private string NomeBanca { get; set; }
        private List<Cliente> lListaClienti { get; set; }
        private List<Prestito> lListaPrestiti { get; set; }

        public Banca(string sNome)
        {
            NomeBanca = sNome;
            lListaClienti = new List<Cliente>();
            lListaPrestiti = new List<Prestito>();
        }

        public bool AggiungiPrestito(double dAmmontare, double dRata, DateTime dDataInizio, DateTime dDataFine, string sCodiceFiscale)
        {
            Prestito newPrestito = new Prestito { Ammontare = dAmmontare, Rata = dRata, DataInizio = dDataInizio, DataFine = dDataFine, CF = sCodiceFiscale };

            if (lListaClienti.Exists(x => x.CodiceFiscale == sCodiceFiscale))
            {
                lListaPrestiti.Add(newPrestito);
                return true;

            }
            else
            {

                return false;
            }

        }

        public bool AggiungiCliente(string sNome, string sCognome, string sCodiceFiscale, double dStipendio)
        {
            Cliente mioCliente = new Cliente { Nome = sNome, Cognome = sCognome, CodiceFiscale = sCodiceFiscale, Stipendio = dStipendio };
            lListaClienti.Add(mioCliente);
            return true;
        }

        public bool UpdateCliente(string sCodiceFiscale, double dStipendio)
        {
            Cliente mioCliente = lListaClienti.Find(x => x.CodiceFiscale == sCodiceFiscale);
            if (mioCliente != null)
            {
                mioCliente.Stipendio = dStipendio;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void RimuoviCliente(string sCodiceFiscale)
        {
            foreach (Cliente clt in lListaClienti)
            {
                if (clt.CodiceFiscale == sCodiceFiscale)
                {
                    lListaClienti.Remove(clt);
                    return;
                }

            }

        }

        public bool RicercaCliente(string CodiceFiscale)
        {
            foreach (Cliente clt in lListaClienti)
            {
                if (clt.CodiceFiscale == CodiceFiscale)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RicercaPrestito(string sCodiceFiscale)
        {
            foreach (Prestito prs in lListaPrestiti)
            {
                if (prs.CF == sCodiceFiscale)
                {
                    return true;
                }
            }
            return false;
        }

        public int NumeroPrestitiCliente(string sCodiceFiscale)
        {
            foreach (Cliente clt in lListaClienti)
            {
                if (clt.CodiceFiscale == sCodiceFiscale)
                {
                    return lListaPrestiti.Count;
                }
            }
            return 0;
        }

        /* 
         public bool AddPrestito(string cf, double ammontare, double rata, DateTime dataInizio, DateTime dataFine)
    {
        Prestito prestito = new Prestito();
        prestito.CF = cf;
        prestito.Ammontare = ammontare;
        prestito.Rata = rata;
        prestito.DataInizio = dataInizio;
        prestito.DataFine= dataFine;
        //ma prima devo sapere se il cliente è cliente
        if (lListaClienti.Exists(c => c.CodiceFiscale == cf))
        {
            lListaPrestiti.Add(prestito);
            return true;
        } else
        {
            return false;
        }
    }
    public Dictionary<string, double> AmmontarePrestitiPerCliente()
    {
        //con un dizionario, lista di coppie chiave, valore
        Dictionary<string, double> kv = new Dictionary<string, double>();
        foreach (Prestito pr in lListaPrestiti)
        {
            if (kv.ContainsKey(pr.CF))
            {
                kv[pr.CF] += pr.Ammontare;
            } else
            {
                kv[pr.CF] = pr.Ammontare;
            }
        }
        return kv;
    }
    //molto simile al vettore di oggetti in javascript
    //[{key: valore}, {key: valore}, ...
    public Dictionary<string, double> AmmontarePrestitiPerCliente1()
    {
        //con un dizionario, lista di coppie chiave, valore
        Dictionary<string, double> kv = new Dictionary<string, double>();
        foreach (Prestito pr in lListaPrestiti)
        {
            //Il valore di default dei double è 0.0
            kv[pr.CF] += pr.Ammontare;
        }
        return kv;
    }
    public List<Tuple<string, double>> AmmontarePrestitiPerCliente2()
    {
        //Senza dizionario, che non conoscete ancora
        List<Tuple<string, double>> lkv = new List<Tuple<string, double>>();
        foreach (Prestito pr in lListaPrestiti)
        {
            //per prima cosa cerco il primo elemento che contiene il cf
            var it = lkv.Find(c => (c.Item1 == pr.CF));
            if (it == null)
            {
                lkv.Add(new Tuple<string, double>(pr.CF, pr.Ammontare));
            } else
            {
                var tot = it.Item2+pr.Ammontare;
                //se non funziona questa, allora eliminare it e poi inserirlo di nuovo
                it = new Tuple<string, double>(pr.CF, tot);
                //lkv.Remove(it);
                //lkv.Add(new Tuple<string, double>(pr.CF, tot));
            }
        }
        return lkv;
    }*/

    }
}