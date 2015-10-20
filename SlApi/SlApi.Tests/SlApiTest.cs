using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlApi.Tests
{
    public class SlApiTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        public HttpRequestMocker HttpRequestMocker { get; set; }

        public SlApiTest()
        {
            HttpRequestMocker = new HttpRequestMocker();
        }

        public string GetSampleResponse(string relativePathToFile)
        {
            var pathToFile = Path.Combine(TestContext.DeploymentDirectory, relativePathToFile);
            if (!File.Exists(pathToFile))
            {
                throw new ArgumentException("given path: " + pathToFile + " does not exist");
            }
            return File.ReadAllText(pathToFile, Encoding.UTF8);
        }
    }
}