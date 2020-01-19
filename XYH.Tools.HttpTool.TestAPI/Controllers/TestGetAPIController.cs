using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYH.Tools.HttpTool.TestModel;

namespace XYH.Tools.HttpTool.TestAPI.Controllers
{
    /// <summary>
    /// 测试接口 API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestGetAPIController : ControllerBase
    {

        #region 模拟get 方式请求接口
        /// <summary>
        /// 模拟无参get请求，返回一个字符串
        /// </summary>
        /// <returns>返回结果</returns>
        [HttpGet("GetNoParamReturnString")]
        public string GetNoParamReturnString()
        {
           string token = Request.Headers["token"];//获取http头参数
            return $"token={token};hello,my name is GetNoParamReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟无参get请求，返回一个实体模型
        /// </summary>
        /// <returns>返回结果</returns>
        [HttpGet("GetNoParamReturnModel")]
        public MReturnResult GetNoParamReturnModel()
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello,my name is GetNoParamReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个字符串
        /// </summary>
        /// <returns>返回结果</returns>
        [HttpGet("GetHasParamReturnString")]
        public string GetHasParamReturnString(string name)
        {
            return $"hello {name},my name is GetHasParamReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpGet("GetHasParamReturnModel")]
        public MReturnResult GetHasParamReturnModel(string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is GetHasParamReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个字符串（路由参数，相关与是直接把参数当着路由处理）
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpGet("GetHasParamRoutReturnString/{name}")]
        public string GetHasParamRoutReturnString(string name)
        {
            return $"hello {name},my name is GetHasParamRoutReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpGet("GetHasParamRoutReturnMode/{name}")]
        public MReturnResult GetHasParamRoutReturnMode(string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is GetHasParamRoutReturnMode.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参post请求(参数也是一个实体)，返回一个实体模型
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>返回结果</returns>
        [Route("GetModelReturnModel")]
        [HttpGet]
        public MReturnResult GetModelReturnModel([FromQuery]MInputInfor model)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {model.name}+{model.age},my name is PostModelReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        #endregion
    }
}