namespace es05_mattina
{
    public class studente
    {
        public string Nome;
        public string Cognome;
        public DateTime dDataNascita;
        public ulong lMatricola;
    }

    public class universita
    {
        private List<string> lsSedi; //List ci permette di definire una lista con un tipo specificato
        private List<studente> lsStudenti;

        public universita()
        {
            lsSedi = new List<string>();
            lsStudenti = new List<studente>();


        }

        public void AggiungiSede(string sSede)
        {
            lsSedi.Add(sSede);
        }

        public bool AggiungiStudente(string sNome, string sCognome, string sDataNascita, ulong ulMatricola)
        {
            bool bRetValue;
            DateTime dtDataNascitaStud;


            bRetValue = DateTime.TryParse(sDataNascita, out dtDataNascitaStud);
            if (bRetValue)

            {
                studente mioStudente = new studente();
                mioStudente.Nome = sNome;
                mioStudente.Cognome = sCognome;
                mioStudente.dDataNascita = dtDataNascitaStud;
                mioStudente.lMatricola = ulMatricola;
                lsStudenti.Add(mioStudente);
                return true;
            }
            else
            {
                return false;
            }








        }
        public void RimuoviSede(string sSede)
        {
            lsSedi.Remove(sSede);
        }

        public void RimuoviStudente(ulong lMatricola)
        {
            foreach (studente std in lsStudenti)
            {
                if (std.lMatricola == lMatricola)
                {
                    lsStudenti.Remove(std);
                    return;
                }
            }
        }

        public bool CercaSede(string sSede)
        {
            foreach (string sede in lsSedi)
            {
                if (sede.ToLower() == sSede.ToLower())
                {
                    return true;
                }


            }
            return false;
        }

        public void CercaStudenteAnno(int iAnno, out List<studente> lMatchingList)
        {

            //lsStudenti FindAll ()
            lMatchingList = new List<studente>();

            foreach (studente std in lsStudenti)
            {
                if (std.dDataNascita.Year == iAnno)
                {
                    lMatchingList.Add(std);
                }
            }

            //lMatchingList = lsStudenti.FindAll(t => t.dDataNascita.Year == iAnno);
            // t prende lo studente, ritorna se t.annoStudente == annoInserito
        }
    }
}