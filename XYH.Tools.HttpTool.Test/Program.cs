using System;
using System.Collections.Generic;
using XYH.Tools.HttpTool.TestModel;

namespace XYH.Tools.HttpTool.Test
{
    class Program
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        static string path = "http://localhost:9090/api/";

        // 请求结果
        static MReturnResult result = null;

        // 字典入参(适合于键值对)
        static Dictionary<string, string> paramDictionary = new Dictionary<string, string>();

        // list入参（适合于路由参数）
        static List<string> paramList = new List<string>();

        // 模型入参（适用于json格式参数）
        static MInputInfor inputParam = null;

        // head参数
        static List<MHeadParamet> headDictionary = new List<MHeadParamet>();

        /// <summary>
        /// 主函数入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 初始化 字典入参(适合于键值对)
            paramDictionary.Add("name", "XYH");
            paramDictionary.Add("age", "31");

            // 初始化 list入参（适合于路由参数）
            paramList.Add("XYH");

            // 初始化 模型入参（适用于json格式参数）
            inputParam = new MInputInfor()
            {
                name = "XYH",
                age = 31
            };

            headDictionary.Add(new MHeadParamet()
            {
                key = "token",
                value = "2019092018397298379827392739729"
            });

            // 模拟get请求
            httpGetTest();

            // 模拟get请求
            httpPostTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 模拟httpget请求
        /// </summary>
        static void httpGetTest()
        {
            Console.WriteLine("\n开始模拟get请求操作：........\n");

            Console.WriteLine("模拟无参get请求，返回一个字符串:");
            Console.WriteLine(HttpTool.HttpGet($"{ path}TestGetAPI/GetNoParamReturnString", headDictionary));
            Console.WriteLine();

            Console.WriteLine("模拟无参get请求，返回一个实体模型:");
            result = HttpTool.HttpGet<MReturnResult>($"{ path}TestGetAPI/GetNoParamReturnModel");
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求，返回一个字符串:");
            Console.WriteLine(HttpTool.HttpGetDic($"{ path}TestGetAPI/GetHasParamReturnString", paramDictionary));
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求，返回一个实体模型:");
            result = HttpTool.HttpGetDic<MReturnResult>($"{ path}TestGetAPI/GetHasParamReturnModel", paramDictionary);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求，返回一个字符串（路由参数）:");
            Console.WriteLine(HttpTool.HttpGetRout($"{ path}TestGetAPI/GetHasParamRoutReturnString", paramList));
            Console.WriteLine();

            Console.WriteLine("模拟有参post请求(参数也是一个实体)，返回一个实体模型:");
            result = HttpTool.HttpGetDic<MReturnResult>($"{ path}TestGetAPI/GetModelReturnModel", paramDictionary);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();
        }

        /// <summary>
        /// 模拟httppost请求
        /// </summary>
        static void httpPostTest()
        {
            Console.WriteLine("\n开始模拟post请求操作：........\n");

            Console.WriteLine("模拟无参post请求，返回一个字符串:");
            Console.WriteLine(HttpTool.HttpPost($"{ path}TestPostAPI/PostNoParamReturnString"));
            Console.WriteLine();

            Console.WriteLine("模拟无参post请求，返回一个实体模型:");
            MReturnResult result = HttpTool.HttpPost<MReturnResult>($"{ path}TestPostAPI/PostNoParamReturnModel");
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参post请求，返回一个字符串:");
            Console.WriteLine(HttpTool.HttpPostDic($"{ path}TestPostAPI/PostHasParamReturnString", paramDictionary));
            Console.WriteLine();

            Console.WriteLine("模拟有参post请求，返回一个实体模型:");
            result = HttpTool.HttpPostDic<MReturnResult>($"{ path}TestPostAPI/PostHasParamReturnModel", paramDictionary);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参post请求，返回一个字符串（路由参数）:");
            Console.WriteLine(HttpTool.HttpPostRout($"{ path}TestPostAPI/PostHasParamRoutReturnString", paramList));
            Console.WriteLine();

            Console.WriteLine("模拟有参post请求(参数也是一个实体)，返回一个实体模型:");
            result = HttpTool.HttpPostModel<MReturnResult, MInputInfor>($"{ path}TestPostAPI/PostModelReturnModel", inputParam);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromBody)，返回一个实体模型：");
            result = HttpTool.HttpPostModel<MReturnResult, MInputInfor>($"{ path}TestPostAPI/GetHasParamReturnModelFromBody", inputParam);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromForm)，返回一个实体模型：");
            result = HttpTool.HttpPostDic<MReturnResult>($"{ path}TestPostAPI/GetHasParamReturnModelFromForm1", paramDictionary, true);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromForm)，返回一个实体模型：");
            result = HttpTool.HttpPostDic<MReturnResult>($"{ path}TestPostAPI/GetHasParamReturnModelFromForm2", paramDictionary, true);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromForm)，返回一个实体模型：");
            result = HttpTool.HttpPostDic<MReturnResult>($"{path}TestPostAPI/GetHasParamReturnModelFromForm3", paramDictionary, true);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromQuery)，返回一个实体模型：");
            result = HttpTool.HttpPostDic<MReturnResult>($"{path}TestPostAPI/GetHasParamReturnModelFromQuery", paramDictionary);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();

            Console.WriteLine("模拟有参get请求(参数来自FromQuery)，返回一个实体模型：");
            result = HttpTool.HttpPostDic<MReturnResult>($"{path}TestPostAPI/GetHasParamReturnModelFromQuery2", paramDictionary);
            Console.WriteLine($"ret={result.ret}\nmsg={result.msg}");
            Console.WriteLine();
        }
    }
}
