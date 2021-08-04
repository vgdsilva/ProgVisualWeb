using Formulario.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Formulario.Regras.Utils
{
    public class EnviarEmail
    {
        Email email = new Email();

        public bool SendEmail(string Assunto, string Destinatario, string Mensagem)
        {
            string assunto = Assunto ;
            string destinatario = Destinatario;
            string mensagem = Mensagem;

            if (!ValidaEnderecoEmail(destinatario))
            {
                return false;
            }

            return DispararEmail(assunto, mensagem, destinatario);
        }

        private bool DispararEmail(string assunto, string mensagem, string destinatario)
        {
            try
            {
                MailMessage mensagemEmail = new MailMessage(email.Mail, destinatario, assunto, mensagem);

                SmtpClient client = new SmtpClient(email.Host, email.Port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(email.Mail, email.Password);
                //client.UseDefaultCredentials = true;
                client.Timeout = 10000;
                client.EnableSsl = true;

                client.Send(mensagemEmail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
