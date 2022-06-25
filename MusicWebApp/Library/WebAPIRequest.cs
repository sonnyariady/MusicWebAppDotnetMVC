using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;


namespace MusicWebApp.Library
{
    public class WebAPIRequest
    {
        public string BaseURL = ConfigurationManager.AppSettings["BasePath"];
        public string APIKey = ConfigurationManager.AppSettings["APIKey"];

        public ResponseGetViewModel RequestPost(String namamethod, String datakirim)
        {
            String str = "";
            String alamatrequest = BaseURL + "/" + namamethod;
            ResponseGetViewModel objresp = new ResponseGetViewModel();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(alamatrequest);
                request.Headers.Add("APIKey", APIKey);
                request.Method = "POST";

                byte[] byteArray = Encoding.UTF8.GetBytes(datakirim);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                request.Timeout = 999999;
                //request.Credentials = CredentialCache.DefaultNetworkCredentials;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                str = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                objresp.ErrorMessage = ex.Message;// +", Detail: " + ex.StackTrace;
                str = "0";
            }


            objresp.HasilRespon = str;
            return objresp;
        }


        public ResponseGetViewModel RequestPut(String namamethod, String datakirim)
        {
            String str = "";
            String alamatrequest = BaseURL + "/" + namamethod;
            ResponseGetViewModel objresp = new ResponseGetViewModel();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(alamatrequest);
                request.Headers.Add("APIKey", APIKey);
                request.Method = "PUT";

                byte[] byteArray = Encoding.UTF8.GetBytes(datakirim);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                request.Timeout = 999999;
                //request.Credentials = CredentialCache.DefaultNetworkCredentials;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                str = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                objresp.ErrorMessage = ex.Message;// +", Detail: " + ex.StackTrace;
                str = "0";
            }


            objresp.HasilRespon = str;
            return objresp;
        }



        public ResponseGetViewModel RequestGet(String namamethod, String datakirim)
        {
            ResponseGetViewModel objresp = new ResponseGetViewModel();
            String strRespon = "";
            String alamatrequest = BaseURL + "/" + namamethod + "?" + datakirim;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(alamatrequest);
            request.Headers.Add("APIKey", APIKey);
            //request.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    strRespon = reader.ReadToEnd();
                }
            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                strRespon = "0";
                objresp.ErrorMessage = ex.Message;// +", Detail: " + ex.StackTrace;
            }

            objresp.HasilRespon = strRespon;

            return objresp;
        }


        public ResponseGetViewModel RequestDelete(String namamethod, String datakirim)
        {
            ResponseGetViewModel objresp = new ResponseGetViewModel();
            String strRespon = "";
            String alamatrequest = BaseURL + "/" + namamethod + "?" + datakirim;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(alamatrequest);
            request.Headers.Add("APIKey", APIKey);
            request.Method = "DELETE";
            //request.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    strRespon = reader.ReadToEnd();
                }
            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                strRespon = "0";
                objresp.ErrorMessage = ex.Message;// +", Detail: " + ex.StackTrace;
            }

            objresp.HasilRespon = strRespon;

            return objresp;
        }


    }
}