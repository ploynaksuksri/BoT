using BoT.Business;
using BoT.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BoT.Test
{
    public class FileTest
    {


        [Fact]
        public void GetMainFile()
        {
            string filePath = @"C:\central\MMTSA39_20191231_MTD.txt";
            var manager = new MainFileManager(new CodeConversionManager());

            List<Transaction> reports = manager.ReadReport(filePath);

            var expected = 30492;

            Assert.Equal(expected, reports.Count);
        }

        [Fact]
        public void GetStatusFile()
        {
            string filePath = @"C:\central\report2.csv";
            var manager = new StatusFileManager();

            List<StatusFile> statusFiles = manager.ReadReport(filePath);

            var expected = 5225;

            Assert.Equal(expected, statusFiles.Count);
        }

    }
}
