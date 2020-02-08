using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Business.Managers
{
    public interface IReportManager<T> where T : class
    {
        List<T> ReadReport(string filePath);
    }
}
