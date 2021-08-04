using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Entidades.Entidades
{
    public class Email
    {

        public string Host { get { return "smtp.gmail.com"; } }
        public int Port { get { return 587; } }
        public string Mail { get { return "app.progvisual@gmail.com"; } }
        public string Password { get { return "progvisual2021"; } }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Destinatario { get; set; }


        public Email() { }


    }
}
