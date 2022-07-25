using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proiect1
{
    public partial class Clienti1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(enableSession: true)]
        public static Response GetClienti(string data)
        {
            var res = new Response();
            try
            {
                res.data = Clienti.GetClienti();
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
        public static Response DeleteClient(string data)
        {
            var res = new Response();
            var idClient = Convert.ToInt32(data);
            if (Clienti.DeleteClient(idClient))
            {
                res.succes = true;
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
        public static Response GetClient(string data)
        {
            var res = new Response();
            var idClient = Convert.ToInt32(data);
            try
            {
                res.data = Clienti.GetClient(idClient);
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
        public static Response ClientAM(string Id, string Nume, string Prenume, string Mail, string Telefon)
        {
            var idClientInt = Convert.ToInt32(Id);
            var res = new Response();
            DateTime date = new DateTime();
            try
            {
                res.data = Clienti.ClientAM(idClientInt, Nume, Prenume, Mail, Telefon);
                res.succes = true;
            }
            catch (Exception)
            {
                res.data = null;
                res.succes = false;
            }
            return res;
        }
    }
}