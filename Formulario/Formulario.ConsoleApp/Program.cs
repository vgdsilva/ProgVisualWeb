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
    public class Program
    {
        public static void Main(string[] args)
        {
            new EnvioDeEmail().EnviarEmail("testes", "testes <br/> teste");
        }
    }
}
