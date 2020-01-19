using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace XYH.Tools.HttpTool
{
    /// <summary>
    /// http get 请求相关的操作帮助类
    /// </summary>
    public partial class HttpTool : HttpToolBase
    {
        #region 无参

        /// <summary>
        /// http请求，不单独带有参数（返回一个泛型实体）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGet<TReturn>(string url, List<MHeadParamet> headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数（返回一个字符串）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGet(string url, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数 （返回一个泛型实体）
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGet<TReturn>(string url, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数（返回一个字符串）
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGet(string url, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数 （返回一个泛型实体）
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGet<TReturn>(string url, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数（返回一个字符串）
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGet(string url, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数 （返回一个泛型实体）
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGet<TReturn>(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，不单独带有参数（返回一个字符串）
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGet(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForGet(url, encodType, timeout, headerKeyValue);
        }

        #endregion

        #region 参数字典 (键值对参数 path?kay1=value1&kay12=value2...)

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)(返回一个字符串)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetDic(string url, Dictionary<string, string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典(键值对参数 path?kay1=value1&kay12=value2...)（返回一个泛型实体）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetDic<TReturn>(string url, Dictionary<string, string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)(返回一个字符串)
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetDic(string url, Dictionary<string, string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)（返回一个泛型实体）
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetDic<TReturn>(string url, Dictionary<string, string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)(返回一个字符串)
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetDic(string url, Dictionary<string, string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)（返回一个泛型实体）
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetDic<TReturn>(string url, Dictionary<string, string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)(返回一个字符串)
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetDic(string url, Dictionary<string, string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)（返回一个泛型实体）
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetDic<TReturn>(string url, Dictionary<string, string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, timeout, headerKeyValue);
        }

        #endregion

        #region rout路由参数

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个泛型实体)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetRout<TReturn>(string url, List<string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个字符串)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetRout(string url, List<string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个泛型实体)
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetRout<TReturn>(string url, List<string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个字符串)
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetRout(string url, List<string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, encodType, defaultTimeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个泛型实体)
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetRout<TReturn>(string url, List<string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个字符串)
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetRout(string url, List<string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, defaultEncodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个泛型实体)
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpGetRout<TReturn>(string url, List<string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet<TReturn>(url, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个字符串)
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpGetRout(string url, List<string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForGet(url, encodType, timeout, headerKeyValue);
        }

        #endregion

        /// <summary>
        /// 获取请求结果（返回一个泛型实体）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static TReturn GetResponseResultForGet<TReturn>(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult<TReturn>(url, string.Empty, "get", string.Empty, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// 获取请求结果（返回一个泛型实体）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static string GetResponseResultForGet(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult(url, string.Empty, "get", string.Empty, encodType, timeout, headerKeyValue);
        }
    }
}