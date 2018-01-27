using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DAL;
using GeneratorName;

namespace DMS
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemlyLaboratory al = new AssemlyLaboratory();
            //LaboratoryWoker lw = new LaboratoryWoker(2, "Jhon Smith", DAL.Gender.male);
            //lw.BirthDay = DateTime.Now.AddMonths(-350);
            //lw.LogIn = "JSmith_LW";
            //lw.Password = "LAB_1-@JS";

            //al.AddWorker(lw);
            LaboratoryWoker lw =
            al.LogOn(Console.ReadLine(), Console.ReadLine());
            if (lw != null)
                Console.WriteLine("Hello {0}", lw.Name);
            else Console.WriteLine("Access denyed");

            #region
            /*
            DGenerate del = sentMsg;
            Generator g = new Generator();
            g.RegisterHedler(del);
            g.Generate(Gender.man);



            sentMessage sm = sentMsg;
            sentMessage sm2 = sentMsgDirector;

            readeLaboratoryD rl = getLabAfterDe;


            AssemlyLaboratory al = new AssemlyLaboratory();
            Laboratory lab = new Laboratory();
            lab.Address = "Address";
            lab.LabId = 1;
            
            lab.PhoneNumber = "8777 000 00 00";

            al.UnRegisterDelegate(sm2);
            al.CreateLaboratory(lab);


            al.RegisterDelegate(sm, rl);
            Laboratory llab = al.ReadLaboratory(1);*/
            #endregion


        }

        static void sentMsg(string message)
        {
            Console.WriteLine(message);
        }

        static void sentMsgDirector(string message)
        {
            Console.WriteLine("sentMsgDirector secses");
        }

        static Laboratory getLabAfterDe(object lab)
        {
            return (Laboratory)lab;
        }
    }
}
