using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Business.Managers
{
    public interface IReportManager<T> : IDisposable where T : class
    {
        List<T> ReadReport(string filePath);
        T GetItem(string[] items);
        void TransformItem(T item);
    }
}
