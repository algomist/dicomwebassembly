using IntegrationClient;
using System.IO;
using Xunit;

namespace IntegrationClientTest
{
    public class ServiceClientTests
    {
        [Fact]
        public void Test1()
        {
            int dicomResult;
            int expectedResult;
            var serviceClient = new ServiceClient();
            var fb = File.ReadAllBytes(@".\TestData\CT.1.2.246.352.71.20.8.12.11.36.39.454586257.dcm");
            using var memoryStream = new MemoryStream(fb);
            dicomResult = serviceClient.HandleDICOMFile(memoryStream);
            expectedResult = (int)memoryStream.Length;
            
            Assert.True(dicomResult == expectedResult);
        }

        [Fact]
        public async void GetParseDicomData()
        {
            string dicomResult;
            var serviceClient = new ServiceClient();
            var fb = File.ReadAllBytes(@".\TestData\CT.1.2.246.352.71.20.8.12.11.36.39.454586257.dcm");
            dicomResult = await serviceClient.ParseDICOMFile(fb);

            Assert.True(dicomResult == "EC08");
        }

        [Fact]
        public async void AnonimizeDicom()
        {
            string dicomResult;
            var serviceClient = new ServiceClient();
            var fb = File.ReadAllBytes(@".\TestData\CT.1.2.246.352.71.20.8.12.11.36.39.454586257.dcm");
            dicomResult = await serviceClient.AnonymizeDICOM(fb);

            Assert.True(dicomResult == "AnonimizedGuy");
        }
    }
}