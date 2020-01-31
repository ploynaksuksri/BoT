using BoT.Business;
using BoT.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BoT.Test
{
    public class MainFileTest
    {
        public string FilePath = @"C:\central\MMTSA39_20191231_MTD.txt";
        private MainFileManager _manager;
     
        public MainFileTest()
        {
            _manager = new MainFileManager();
        }

        [Fact]
        public void GetFile()
        {
            List<MainFile> reports = _manager.ReadReport(FilePath);

            var expected = 30492;

            Assert.Equal(expected, reports.Count);
        }
    }
}
