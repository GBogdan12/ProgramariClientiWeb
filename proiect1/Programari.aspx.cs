using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proiect1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(enableSession: true)]
        public static Response GetProgramari(string data)
        {
            var res = new Response();
            try
            {
                DateTime date = new DateTime();
                if (DateTime.TryParseExact(data, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    res.data = Programari.GetProgramari(date);
                    res.succes = true;
                }
            }
            catch (Exception)
            {
                res.succes = false;
                res.data = null;
            }
            return res;
        }
        [WebMethod(enableSession: true)]
        public static Response DeleteProgramare(string data)
        {
            var res = new Response();
            var idProg = Convert.ToInt32(data);
            if (Programari.DeleteProgramare(idProg))
            {
                res.succes=true;
                res.data = true;
            }
            else
            {
                res.succes = false;
                res.data = null;
            }      
            return res;
        }

        [WebMethod(enableSession: true)]
        public static Response GetProgramare(string data)
        {
            var res = new Response();
            var idProg = Convert.ToInt32(data);
            try
            {
                res.data = Programari.GetProgramare(idProg);
                res.succes = true;
            }
            catch (Exception)
            {

                res.succes = false;
                res.data = null;
            }
            return res;
        }
        [WebMethod(enableSession: true)]
        public static Response ProgramareAM(string Id, string Nume, string Prenume, string Mail, string Telefon, string Serviciu, string Data, string idClient )
        {
            var idProg = Convert.ToInt32(Id);
            var idClientInt = Convert.ToInt32(idClient);
            var res = new Response();
            DateTime date = new DateTime();
            if (DateTime.TryParseExact(Data, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                res.data = Programari.ProgramareAM(idProg, date, Serviciu, idClientInt, Telefon,Mail,Nume,Prenume);
                res.succes = true;
            }
            else
            {
                res.data = null;
                res.succes=false;
            }
            return res;
        }
    }
}