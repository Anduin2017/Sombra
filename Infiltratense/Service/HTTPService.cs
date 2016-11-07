using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Infiltratense.Service
{
    public class HTTPService
    {
        public CookieContainer cc = new CookieContainer();
        public string Post(string Url, string postDataStr, string Decode = "utf-8")
        {
            HttpWebRequest request = WebRequest.Create(Url) as HttpWebRequest;
            if (cc.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cc = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cc;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var myRequestStream = request.GetRequestStream();
            var myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("GB2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Dispose();
            var response = request.GetResponse();
            var myResponseStream = response.GetResponseStream();
            var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(Decode));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Dispose();
            myResponseStream.Close();
            return retString;
        }
        public string Get(string Url, string Coding = "utf-8")
        {
            var request = WebRequest.Create(Url) as HttpWebRequest;
            if (cc.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cc = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cc;
            }
            request.Method = "GET";
            request.ContentType = "text/html;charset=" + Coding;
            var response = request.GetResponse();
            var myResponseStream = response.GetResponseStream();
            var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(Coding));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Dispose();
            myResponseStream.Close();
            return retString;
        }
        public string HttpDownloadFile(string url)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(CellFileInfo.CurrentPath + @"\InfiltratenseDownloaded.exe", FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return CellFileInfo.CurrentPath + @"\InfiltratenseDownloaded.exe";
        }
    }
}
