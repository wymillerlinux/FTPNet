using System;
using System.Net;

namespace FTPNet
{
    public class Ftp
    {
        // fields
        private Uri _uri;
        private string _username;
        private string _password;
        private string _motd;
        
        // properties
        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Motd
        {
            get { return _motd; }
            set { _motd = value; }
        }

        // constructors

        public Ftp(string uri, string username, string password)
        {
            _uri = new Uri(uri);
            _username = username;
            _password = password;
        }

        // methods
        
        public bool DeleteFile()
        {
            if (_uri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(_uri);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("{0} deleted.", response.StatusDescription);
            response.Close();
            
            return true;
        }
        
        public bool UploadFile(string file)
        {
            if (_uri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(_uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("{0} uploaded.", response.StatusDescription);
            response.Close();
            
            return true;
        }
        
        public bool DownloadFile()
        {
            if (_uri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(_uri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("{0} deleted.", response.StatusDescription);
            response.Close();
            
            return true;
        }

        
        public bool DisplayFileFromServer()
        {
            if (_uri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            WebClient request = new WebClient();
    
            request.Credentials = new NetworkCredential ();
            try 
            {
                byte [] newFileData = request.DownloadData (_uri.ToString());
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }
    }
}