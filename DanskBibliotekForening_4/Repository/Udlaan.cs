using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Udlaan
    {
        public Udlaan()
        {
        }
        public Udlaan(DateTime _afleveringsDato)
        {
            AfleveringsDato = _afleveringsDato;
        }
        private DateTime _afleveringsDato;

        public DateTime AfleveringsDato
        {
            get { return _afleveringsDato; }
            set { _afleveringsDato = value; }
        }

        public void BeregnAfleveringsDato(DateTime lentdate, string userStatus)
        {
            throw new NotImplementedException();
        } 

    }
}
