using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tempNavn.LoginKlasser
{
    static class SendEmail
    {
        private static string passord = "storasveien";
        private static MailMessage msg;

        public static void sendEpost(string epost, string beskjed, string emne)
        {
            try
            {
                msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                //bruker gruppe eposten som avsender
                msg.From = new MailAddress("Admin@gmail.com");
                /* Tips: bruk overload-metoder i stedet for if-tester              
                 * sendEpost(string epost, string message, string subject) {
                 * sendEpost(epost, message, subject, null, null, null);
                 * }
                 **/
                msg.To.Add(epost);

                msg.Subject = emne;

                msg.Body = beskjed;
                msg.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential("sysut14gr03@gmail.com", passord);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
