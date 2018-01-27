using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DMS.DAL
{
    public delegate void sentMessage(string message);
    public delegate Laboratory readeLaboratoryD(object lab);
    public class AssemlyLaboratory
    {
        private sentMessage sm;
        private readeLaboratoryD rl;
        public void RegisterDelegate(sentMessage del, readeLaboratoryD del2=null)
        {
            sm += del;
            rl = del2;
        }
        
        public void UnRegisterDelegate(sentMessage del)
        {
            sm -= del;
        }


        public void CreateLaboratory(Laboratory lab)
        {

            XmlSerializer formatter = 
                new XmlSerializer(typeof(Laboratory));

            using (FileStream fs =
                new FileStream("lab_" + lab.LabId + ".xml",
                FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, lab);
                    if(sm!=null)
                        sm.Invoke("Лаборатория успешно добавлена");
                }
                catch (Exception ex)
                {
                    if (sm != null)
                        sm.Invoke(ex.Message);
                }
            }



            
        }

        public Laboratory ReadLaboratory(int LabId)
        {
            XmlSerializer formatter = 
                new XmlSerializer(typeof(Laboratory));

            using (FileStream fs =
               new FileStream("lab_" + LabId + ".xml",
               FileMode.OpenOrCreate))
            {
                try
                {
                    if (rl != null)
                    {
                        return rl.Invoke(formatter.Deserialize(fs));
                    }
                    else
                        return null;
                       
                }
                catch (Exception ex)
                {
                    if (sm != null)
                       sm.Invoke(ex.Message);
                    return null;
                }
            }

        }

        public string WorkersURL { get
            {
                var work = ConfigurationManager.GetSection("Path") as NameValueCollection;
                return work["WorkersURL"];
            }
        }
        private List<LaboratoryWoker> GetWorkers()
        {
            List<LaboratoryWoker> LW = null;
            XmlSerializer formatter = new XmlSerializer(typeof(LaboratoryWoker[]));
            using (FileStream fs =
                new FileStream(WorkersURL, FileMode.OpenOrCreate))
            {
                try
                {
                    LW = ((LaboratoryWoker[])formatter.Deserialize(fs)).ToList();
                }
                catch (Exception err) { Console.WriteLine(err.Message); }
            }

            return LW;
        }
        public void AddWorker(LaboratoryWoker lw)
        {
            List<LaboratoryWoker> lws = GetWorkers();
            if (lws == null)
                lws = new List<LaboratoryWoker>();
            lws.Add(lw);
            XmlSerializer formatter = new XmlSerializer(typeof(LaboratoryWoker[]));
            using (FileStream fs =
                new FileStream(WorkersURL, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, lws.ToArray());
                }
                catch (Exception err) { Console.WriteLine(err.Message); }
            }
        }

        public LaboratoryWoker LogOn(string login, string password)
        {
            LaboratoryWoker lw = null;
            List<LaboratoryWoker> lws = GetWorkers();
            if(lws != null)
            {
                lw = lws.FirstOrDefault(w => w.LogIn == login && w.Password == password);

            }
            return lw;
        }
    }
}
