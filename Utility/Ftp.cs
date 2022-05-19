using Domain.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace UtilitySpace
{
    public class Ftp
    {
        private FtpParametr GetFtp(string TypeFtp)
        {
            DataContext db = new DataContext();
            var q = db.TblServers.Where(a => a.Type == TypeFtp).ToList();
            int RndServer = new Random().Next(0, q.Count() - 1);

            FtpParametr f = new FtpParametr()
            {
                FtpAddress = q[RndServer].Ip + q[RndServer].Path,
                Password = q[RndServer].Password,
                UserName = q[RndServer].UserName,
                FtpID = q[RndServer].ID
            };

            return f;
        }

        private FtpParametr GetFtp(int ServerID)
        {
            DataContext db = new DataContext();
            var q = db.TblServers.Where(a => a.ID == ServerID).Single();

            FtpParametr f = new FtpParametr()
            {
                FtpAddress = q.Ip + q.Path,
                Password = q.Password,
                UserName = q.UserName
            };

            return f;
        }
        public int Upload(string TypeFtp, string FileName, Stream MyFile)
        {
            try
            {
                var qP = GetFtp(TypeFtp);

                /* Create an FTP Request */
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(qP.FtpAddress + FileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(qP.UserName, qP.Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                Stream ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                Stream localFileStream = MyFile;
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[2048];
                int bytesSent = localFileStream.Read(byteBuffer, 0, 2048);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */

                while (bytesSent != 0)
                {
                    ftpStream.Write(byteBuffer, 0, bytesSent);
                    bytesSent = localFileStream.Read(byteBuffer, 0, 2048);
                }


                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;

                #region Upload Text Files
                // Get the object used to communicate with the server.  
                //FtpWebRequest Myrequest = (FtpWebRequest)WebRequest.Create(qP.FtpAddress + FileName);
                //Myrequest.Method = WebRequestMethods.Ftp.UploadFile;

                //// This example assumes the FTP site uses anonymous logon.  
                //Myrequest.Credentials = new NetworkCredential(qP.UserName, qP.Password);

                //// Copy the contents of the file to the request stream.  
                //StreamReader sourceStream = new StreamReader(MyFile);
                //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                //sourceStream.Close();
                //Myrequest.ContentLength = fileContents.Length;

                //Stream requestStream = Myrequest.GetRequestStream();
                //requestStream.Write(fileContents, 0, fileContents.Length);
                //requestStream.Close();

                //FtpWebResponse response = (FtpWebResponse)Myrequest.GetResponse();

                ////Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                //response.Close();
                #endregion

                return qP.FtpID;
            }
            catch (Exception e)
            {

                return -1;
            }

        }

        public bool RemoveImage(int ImageID)
        {
            DataContext db = new DataContext();
            var qImage = db.TblImage.Where(a => a.ID == ImageID).Single();

            if (Remove(qImage.ServerID, qImage.FileName))
            {
                db.TblImage.Remove(qImage);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Remove(int ServerID, string FileName)
        {
            try
            {
                var qP = GetFtp(ServerID);

                /* Create an FTP Request */
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(qP.FtpAddress + FileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(qP.UserName, qP.Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }


    public class FtpParametr
    {
        public int FtpID { get; set; }
        public string FtpAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
