using System;
using NUnit.Framework;

namespace FTPNet
{
    [TestFixture]
    public class FTPTest
    {
        [Test]
        public void TestFields()
        {
            Ftp ftp = new Ftp("ftp://192.168.88.253/", "wyatt", "wyatt");
            var username = ftp.Username;
            var pw = ftp.Password;
            var uri = ftp.Uri;
            Console.WriteLine(username);
            Console.WriteLine(pw);
            Console.WriteLine(uri);
        }

        [Test]
        public void TestUpload()
        {
            Ftp ftp = new Ftp("ftp://192.168.88.253/", "wyatt", "wyatt");
            ftp.UploadFile("test.txt");
            return;
        }
    }
}