using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace XYH.Tools.HttpTool
{
    /// <summary>
    /// http请求相关的操作帮助类
    /// </summary>
    public partial class HttpTool : HttpToolBase
    {
        #region 无参

        /// <summary>
        /// POST请求，无参 （返回一个泛型实体）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static TReturn HttpPost<TReturn>(string url, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个字符串）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static string HttpPost(string url, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个泛型实体）
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encodType">编码方式，默认为utf-8</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static TReturn HttpPost<TReturn>(string url, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost<TReturn>(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个字符串）
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encodType">编码方式，默认为utf-8</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static string HttpPost(string url, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个泛型实体）
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static TReturn HttpPost<TReturn>(string url, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost<TReturn>(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个字符串）
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static string HttpPost(string url, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个泛型实体）
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encodType">编码方式，默认为utf-8</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static TReturn HttpPost<TReturn>(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost<TReturn>(url, encodType, timeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// POST请求，无参 （返回一个字符串）
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encodType">编码方式，默认为utf-8</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果</returns>
        public static string HttpPost(string url, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            //获得接口返回值
            return GetResponseResultForPost(url, encodType, timeout, headerKeyValue: headerKeyValue);
        }

        #endregion

        #region 参数字典 (键值对参数 path?kay1=value1&kay12=value2...)

        /// <summary>
        /// http请求，并带有请求参数字典 (键值对参数 path?kay1=value1&kay12=value2...)(返回一个字符串)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="isAcceptForm">参数是否来自Form， true:代表来自Form false:来自url 默认为false</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpPostDic(string url, Dictionary<string, string> parameters, bool isAcceptForm = false, List<MHeadParamet> headerKeyValue = null)
        {
            if (!isAcceptForm)
            {
                // 构建请求参数
                url = GetRequestPath(url, parameters);

                // 发起请求
                return GetResponseResultForPost(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
            }
            else
            {
                return GetResponseResultForPost<Dictionary<string, string>>(url, defaultEncodType, defaultTimeout, parameters, headerKeyValue: headerKeyValue);
            }
        }

        /// <summary>
        /// http请求，并带有请求参数字典(键值对参数 path?kay1=value1&kay12=value2...)（返回一个泛型实体）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">请求参数字典</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpPostDic<TReturn>(string url, Dictionary<string, string> parameters, bool isAcceptForm = false, List<MHeadParamet>  headerKeyValue = null)
        {
            if (!isAcceptForm)
            {
                // 构建请求参数 multipart/form-data
                url = GetRequestPath(url, parameters);

                // 发起请求
                return GetResponseResultForPost<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
            }
            else
            {
                return GetResponseResultForPost<TReturn>(url, defaultEncodType, defaultTimeout, GetRequestData(parameters), "application/x-www-form-urlencoded;charset=utf-8", headerKeyValue: headerKeyValue);
            }
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
        public static string HttpPostDic(string url, Dictionary<string, string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostDic<TReturn>(string url, Dictionary<string, string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
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
        public static string HttpPostDic(string url, Dictionary<string, string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostDic<TReturn>(string url, Dictionary<string, string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
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
        public static string HttpPostDic(string url, Dictionary<string, string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, encodType, timeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostDic<TReturn>(string url, Dictionary<string, string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, encodType, timeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostRout<TReturn>(string url, List<string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// http请求，并带有list集合请求参数（rout路由参数）(返回一个字符串)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">list集合请求参数</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpPostRout(string url, List<string> parameters, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, defaultEncodType, defaultTimeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostRout<TReturn>(string url, List<string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
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
        public static string HttpPostRout(string url, List<string> parameters, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, encodType, defaultTimeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostRout<TReturn>(string url, List<string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
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
        public static string HttpPostRout(string url, List<string> parameters, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, defaultEncodType, timeout, headerKeyValue: headerKeyValue);
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
        public static TReturn HttpPostRout<TReturn>(string url, List<string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost<TReturn>(url, encodType, timeout, headerKeyValue: headerKeyValue);
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
        public static string HttpPostRout(string url, List<string> parameters, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 构建请求参数
            url = GetRequestPath(url, parameters);

            // 发起请求
            return GetResponseResultForPost(url, encodType, timeout, headerKeyValue: headerKeyValue);
        }

        #endregion

        #region json参数

        /// <summary>
        /// http请求，参数为实体对象 (返回一个泛型实体)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="inputParamet">请求参数模型</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpPostModel<TReturn, TInput>(string url, TInput inputParamet, bool isAcceptForm = false, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForPost<TReturn, TInput>(url, defaultEncodType, defaultTimeout, inputParamet, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// http请求，参数为实体对象 (返回一个字符串)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="inputParamet">请求参数模型</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpPostModel<TInput>(string url, TInput inputParamet, List<MHeadParamet> headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForPost<TInput>(url, defaultEncodType, defaultTimeout, inputParamet, headerKeyValue);
        }

        /// <summary>
        /// http请求，参数为实体对象(返回一个泛型实体)
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="inputParamet">请求参数模型</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpPostModel<TReturn, TInput>(string url, TInput inputParamet, Encoding encodType, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForPost<TReturn, TInput>(url, encodType, defaultTimeout, inputParamet, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// http请求，参数为实体对象(返回一个泛型实体)
        /// 自定义编码方式
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="inputParamet">请求参数模型</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static TReturn HttpPostModel<TReturn, TInput>(string url, TInput inputParamet, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForPost<TReturn, TInput>(url, encodType, timeout, inputParamet, headerKeyValue: headerKeyValue);
        }

        /// <summary>
        /// http请求，参数为实体对象(返回一个泛型实体)
        /// 自定义编码方式
        /// 自定义超时时间 单位毫秒 默认为1分钟
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="inputParamet">请求参数模型</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求处理结果</returns>
        public static string HttpPostModel<TInput>(string url, TInput inputParamet, Encoding encodType, int timeout, List<MHeadParamet>  headerKeyValue = null)
        {
            // 发起请求
            return GetResponseResultForPost<TInput>(url, encodType, timeout, inputParamet, headerKeyValue);
        }

        #endregion

        #region 帮助方法

        /// <summary>
        /// 获取请求结果（返回一个泛型实体）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="contentType">请求参数传递方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static T GetResponseResultForPost<T>(string url, Encoding encodType, int timeout, string requestData = "",
            string contentType = "", List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult<T>(url, requestData, "post", contentType, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// 获取请求结果（返回一个字符串）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="contentType">请求参数传递方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static string GetResponseResultForPost(string url, Encoding encodType, int timeout,
            string requestData = "", string contentType = "", List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult(url, requestData, "post", contentType, encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// 获取请求结果（返回一个泛型实体）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="contentType">请求参数传递方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static TReturn GetResponseResultForPost<TReturn, TInput>(string url, Encoding encodType, int timeout, TInput inputParamet,
            bool isAcceptForm = false, List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult<TReturn>(url, JsonConvert.SerializeObject(inputParamet), "post", isAcceptForm ? "application/x-www-form-urlencoded;charset=utf-8" : "application/json", encodType, timeout, headerKeyValue);
        }

        /// <summary>
        /// 获取请求结果（返回一个字符串）
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encodType">编码方式</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="requestData">请求参数</param>
        /// <param name="contentType">请求参数传递方式</param>
        /// <param name="headerKeyValue">头部键值对参数</param>
        /// <returns>请求结果返回值</returns>
        private static string GetResponseResultForPost<TInput>(string url, Encoding encodType, int timeout, TInput requestData,
            List<MHeadParamet>  headerKeyValue = null)
        {
            return GetResponseResult(url, JsonConvert.SerializeObject(requestData), "post", "application/json", encodType, timeout, headerKeyValue);
        }

        #endregion
    }
}