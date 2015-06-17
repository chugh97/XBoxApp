using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using XboxMusicQueryPCL;

namespace UnitTestXboxMusicQueryPortable
{
    
    [TestClass]
    public class XboxMusicServiceClientTests
    {
        private const string CLIENT_ID = "TestMe123";
        private const string CLIENT_SECRET = "7b9gmRqo8rdV2vl0hf91rlGn7eJPE3LhxBwFMiYGk/o=";

        [TestMethod]
        public void TestConstructor ()
        {
            // arrange
            string expected = CLIENT_ID;

            // act
            XBoxMusicServicePCLClient client = new XBoxMusicServicePCLClient(CLIENT_ID, CLIENT_SECRET);
            
            // assert
            Assert.AreEqual(expected, client.ClientID);
        }


        [TestMethod]
        public void TestConnect()
        {
            // arrange
            bool expected = true;

            //action
            XBoxMusicServicePCLClient client = new XBoxMusicServicePCLClient(CLIENT_ID, CLIENT_SECRET);
            bool actual = client.Connect ();
            
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFind()
        {

        }
    }
}
