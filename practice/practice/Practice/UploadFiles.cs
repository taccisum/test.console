using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class UploadFiles : Test
    {
        private string _url;
        private IEnumerable<string> _paths = null;


        public UploadFiles(string url, IEnumerable<string> paths, string testName = "Post files test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
            _url = url;
            _paths = paths;
        }


        protected override void RealTestOutPut()
        {
            println(PostFiles(_url, _paths));
        }

        /// <summary>
        /// Post文件（可多个）
        /// </summary>
        /// <param name="url">目标API</param>
        /// <param name="paths">文件路径集合</param>
        /// <returns></returns>
        public string PostFiles(string url, IEnumerable<string> paths)
        {
            string result = "";
            var pathList = paths.Select(p => p.Trim()).ToList();
            var nameList = pathList.Select(p => p.Substring(p.LastIndexOf(@"\") + 1));
            string boundaryStr  = "--" + DateTime.Now.Ticks.ToString("x");      //边界符
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundaryStr );
            List<byte[]> contentDispositionList = nameList.Select(n =>
                Encoding.ASCII.GetBytes(String.Format("\r\nContent-Disposition: form-data; name=\"{0}\"filename=\"{1}\"\r\n" +
                                  "Content-Type: application/octet-stream\r\n\r\n", n, n))).ToList();       //content-disposition配置字符串列表

            var request = (HttpWebRequest)WebRequest.Create(url);
            //设置获得响应的超时时间（3秒）
            request.Timeout = 3000;
            request.Method = "POST";
            request.ContentType = "multipart/form-data; boundary=" + boundaryStr;
            FileStream fs = null;
            Stream rs = null;
            StreamReader sr = null;
            try
            {
                //提交http格式的报文
                rs = request.GetRequestStream();

                for (int i = 0; i < pathList.Count; i++)
                {
                    rs.Write(boundaryBytes, 0, boundaryBytes.Length); //写边界符
                    rs.Write(contentDispositionList[i], 0, contentDispositionList[i].Length); //写内容描述
                    fs = File.Open(pathList[i], FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = new byte[fs.Length];
                    br.Read(bytes, 0, Convert.ToInt32(fs.Length));
                    br.Close();
                    fs.Close();
                    br = null;
                    fs = null;

                    rs.Write(bytes, 0, bytes.Length); //写二进制文件流
                }

                rs.Write(boundaryBytes, 0, boundaryBytes.Length);
                rs.Flush();
                rs.Close();
                rs = null;

                

                sr = new StreamReader(request.GetResponse().GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();
                sr = null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                //关闭I/O流
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                }
                if (rs != null)
                {
                    rs.Flush();
                    rs.Close();
                }
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return result;
        }

    }
}
