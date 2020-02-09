using BoT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Business.Managers
{
    public class ObjectiveHelper
    {
        public static Dictionary<string, string> ObjectiveCodes = new Dictionary<string, string>()
        {
            {"01", "318059"},
            {"02", "318012"},
            {"03", "318013"},
            {"04", "318209"},
            {"05", "318132"}
        };

        public string GetObjectiveCode(Transaction t)
        {
            var code = ObjectiveCodes[t.Objective];
            return code;
        }
    }

       
    public class PaymentInstrumentCode
    {

    }
}
