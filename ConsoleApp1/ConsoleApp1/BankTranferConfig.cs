using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BankTranferConfig
    {
        private List<string> methods;

        public bankconfig bank { get; set; }
        public BankTranferConfig()
        {
            try
            {
                ReadJson();
            }
            catch
            {
                setDefault();
                writeJson();
            }
        }

        public BankTranferConfig(bankconfig bank)
        {
            this.bank = bank;
        }
        public void ReadJson()
        {
            string hasil = File.ReadAllText(@"./bank_transfer_config.json");
            bank = JsonSerializer.Deserialize<bankconfig>(hasil);
        }

        public void setDefault()
        {
            List<String> list = new List<String> { "RTO(real-time)", "SKN", "RTGS","BI FAST"};
            bank = new bankconfig("en", 25000000, 6500, 15000, methods, "yes", "ya");
        }
        public void writeJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonstr = JsonSerializer.Serialize(bank, options);
            File.WriteAllText(@"./bank_tranfer_config.json",jsonstr);
        }

        public class bankconfig
        {
            public String lang { get; set; }
            public transfer transfer { get; set; }
            public List<String> methods { get; set; }
            public confirmation confirmation { get; set; }
            public bankconfig() { }
            public bankconfig(String lang, int treshold, int low_fee, int high_fee, List<String> methods, String en, String id)
            {
                this.lang = lang;
                transfer = new transfer(treshold,low_fee,high_fee);
                this.methods = methods;
                confirmation = new confirmation(en,id);
            }
        }
   
        public class transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
            public transfer(int treshold,int low_fee,int high_fee)
            {
                this.threshold = treshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
      
        }

        public class confirmation
        {
            public String en { get; set; }
            public String id { get; set; }

            public confirmation(String en, String id)
            {
                this.en = en;
                this.id = id;
            }
        }
    }
}
