using Formulario.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Formulario.ConsoleApp
{
    public class EnvioDeEmail
    {
        Email email = new Email();

        
        //string Host = "smtp-mail.outlook.com";
        //int Port = 587;
        //string Email = "vinigasparello@hotmail.com";
        //string Senha = "";

        public void EnviarEmail(string assunto, string mensagem)
        {
            string Assunto = assunto;
            string Mensagem = mensagem;

            DispararEmail(Assunto, Mensagem, email.Destinatario);
        }

        public bool DispararEmail(string Assunto, string Mensagem, string Destinatario)
        {
            try
            {
                MailMessage mensagemEmail = new MailMessage(email.Mail, Destinatario, Assunto, Mensagem);

                SmtpClient client = new SmtpClient(email.Host, email.Port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(email.Mail, email.Password);
                client.Timeout = 10000;

                client.EnableSsl = true;

                client.Send(mensagemEmail);
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
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
