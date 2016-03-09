using LoanBazaar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LoanBazaar.Controllers.Api
{
    public class FileUploadController : ApiController
    {       

        [HttpPost()]
        public string UploadFiles()
        {
            try
            {
                int iUploadedCnt = 0;

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                //string sPath = "";
                //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/locker/");

                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        //if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                        //{
                        //    // SAVE THE FILES IN THE FOLDER.
                        //    hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));                            
                        //    iUploadedCnt = iUploadedCnt + 1;
                        //}

                        byte[] byteStream = new byte[hpf.ContentLength];
                        System.IO.Stream fileStream = hpf.InputStream;
                        // Read the file into the byte array.
                        fileStream.Read(byteStream, 0, hpf.ContentLength);

                        //WebRequest request = WebRequest.Create("ftp://loanraasta.com/wwwroot/Resumes/" + hpf.FileName);
                        //request.Method = WebRequestMethods.Ftp.UploadFile;
                        //request.Credentials = new NetworkCredential("lrws", "D#Kre%klzna");
                        //Stream reqStream = request.GetRequestStream();
                        //reqStream.Write(byteStream, 0, byteStream.Length);
                        //reqStream.Close();
                        
                        //using (WebClient client = new WebClient())
                        //{
                        //    client.Credentials = new NetworkCredential("lrws", "D#Kre%klzna");
                        //    client.UploadFile("ftp://loanraasta.com/wwwroot/Resumes/" + hpf.FileName, "STOR", localFilePath);
                        //}
                        FtpWebRequest FTPRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://loanraasta.com/wwwroot/Resumes/" + hpf.FileName);
                        FTPRequest.Credentials = new NetworkCredential("lrws", "D#Kre%klzna");
                        FTPRequest.KeepAlive = false;
                        FTPRequest.Method = WebRequestMethods.Ftp.UploadFile;
                        FTPRequest.UseBinary = true;
                        FTPRequest.ContentLength = hpf.ContentLength;
                        FTPRequest.Proxy = null;
                        using (Stream TempStream = FTPRequest.GetRequestStream())
                        {
                            //System.Text.ASCIIEncoding TempEncoding = new System.Text.ASCIIEncoding();
                            //byte[] TempBytes = TempEncoding.GetBytes(Content);
                            TempStream.Write(byteStream, 0, byteStream.Length);
                        }
                        FTPRequest.GetResponse();
                    }
                }

                // RETURN A MESSAGE (OPTIONAL).
                if (iUploadedCnt > 0)
                {
                    return iUploadedCnt + " Files Uploaded Successfully";
                }
                else
                {
                    return "Upload Failed";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
