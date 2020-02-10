using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BoT.Business.Managers
{
    public class BaseCodeManager<T> where T: class
    {
        public virtual List<T> ReadCodes(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var codes = JsonConvert.DeserializeObject<List<T>>(text);
            return codes;
        }
    }
}
