using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace XYH.Tools.HttpTool
{
    /// <summary>
    /// http操作基类
    /// </summary>
    public class HttpToolBase
    {
        /// <summary>
        /// 默认编码方式: UTF8
        /// </summary>
        protected static Encoding defaultEncodType = Encoding.UTF8;

        /// <summary>
        /// 超时时间，单位为毫秒，默认为1分钟
        /// </summary>
        protected static int defaultTimeout = 60000;

        /// <summary>
        /// 根据请求参数字典，构建请求字符串
        /// </summary>
        /// <param name="postParameters">请求参数字典</param>
        /// <returns>请求参数字符串</returns>
        protected static string GetRequestData(Dictionary<string, string> postParameters)
        {
            if (postParameters == null || postParameters.Count < 1)
            {
                return string.Empty;
            }

            StringBuilder paraStrBuilder = new StringBuilder();
            foreach (string key in postParameters.Keys)
            {
                paraStrBuilder.AppendFormat("{0}={1}&", key, postParameters[key]);
            }
            string para = paraStrBuilder.ToString();
            if (para.EndsWith("&"))
            {
                para = para.Remove(para.Length - 1, 1);
            }

            return para.ToString();
        }

        /// <summary>
        /// 获取构建请求地址
        /// </summary>
        /// <param name="path">域名地址</param>
        /// <param name="postParameters">参数</param>
        /// <returns></returns>
        protected static string GetRequestPath(string path, Dictionary<string, string> postParameters)
        {
            return $"{path.TrimEnd('?')}?{GetRequestData(postParameters)}";
        }

        /// <summary>
        /// 根据请求参数字典，构建请求字符串
        /// </summary>
        /// <param name="postParameters">请求参数字典</param>
        /// <returns>请求参数字符串</returns>
        protected static string GetRequestData(List<string> parametersList)
        {
            if (parametersList == null || parametersList.Count < 1)
            {
                return string.Empty;
            }

            StringBuilder paraStrBuilder = new StringBuilder();
            // 构建请求参数
            if (parametersList != null && parametersList.Count > 0)
            {
                foreach (var item in parametersList)
                {
                    paraStrBuilder.Append($"/{item}");
                }
            }

            return paraStrBuilder.ToString();
        }

        /// <summary>
        /// 获取构建请求地址
        /// </summary>
        /// <param name="path">域名地址</param>
        /// <param name="parametersList">参数</param>
        /// <returns></returns>
        protected static string GetRequestPath(string path, List<string> parametersList)
        {
            return $"{path.TrimEnd('/')}{GetRequestData(parametersList)}";
        }

        /// <summary>
        /// 获取请求结果（返回一个泛型实体）
        /// </summary>
        /// <param name="requestURI">地址</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="method">请求方式</param>
        /// <param name="contentType">ContentType</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        protected static T GetResponseResult<T>(string requestURI, string requestData, string method,
            string contentType, Encoding encodType, int timeout, List<MHeadParamet> headerKeyValue)
        {
            //获得接口返回值
            string result = GetResponseResult(requestURI, requestData, method,
             contentType, encodType, timeout, headerKeyValue);

            if (!string.IsNullOrEmpty(result))
            {
                // 转换字符串
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default(T);
        }

        /// <summary>
        /// 获取请求结果(返回一个字符串)
        /// </summary>
        /// <param name="requestURI">地址</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="method">请求方式</param>
        /// <param name="contentType">ContentType</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        protected static string GetResponseResult(string requestURI, string requestData, string method,
            string contentType, Encoding encodType, int timeout, List<MHeadParamet> headerKeyValue)
        {
            // http请求
            HttpWebRequest myRequest = GetHttpWebRequest(requestURI, requestData, method,
             contentType, encodType, timeout, headerKeyValue);

            //获得接口返回值
            string result = string.Empty;
            using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
            {
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), encodType))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取 HttpWebRequest
        /// </summary>
        /// <param name="requestURI">地址</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="method">请求方式</param>
        /// <param name="contentType">ContentType</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>HttpWebRequest</returns>
        protected static HttpWebRequest GetHttpWebRequest(string requestURI, string requestData, string method,
            string contentType, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue)
        {
            // http请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURI);

            // 请求方式
            request.Method = method;
            request.ReadWriteTimeout = timeout;
            request.Timeout = timeout;

            // 在头部插入参数（主要用于认证需要）
            if (headerKeyValue != null && headerKeyValue.Count > 0)
            {
                foreach (var item in headerKeyValue)
                {
                    request.Headers.Add(item.key, item.value);
                }
            }

            // contentType
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }

            // 请求参数
            if (!string.IsNullOrEmpty(requestData))
            {
                // 请求字符串
                byte[] buf = encodType.GetBytes(requestData);

                request.ContentLength = buf.Length;

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(buf, 0, buf.Length);
                    reqStream.Close();
                }
            }

            return request;
        }
    }
}
