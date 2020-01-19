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
    public class TestPostAPIController : ControllerBase
    {
        #region 模拟post方式请求接口
        /// <summary>
        /// 模拟无参post请求，返回一个字符串
        /// </summary>
        /// <returns>返回结果</returns>
        [Route("PostNoParamReturnString")]
        [HttpPost]
        public string PostNoParamReturnString()
        {
            return $"hello,my name is PostNoParamReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟无参post请求，返回一个实体模型
        /// </summary>
        /// <returns>返回结果</returns>
        [Route("PostNoParamReturnModel")]
        [HttpPost]
        public MReturnResult PostNoParamReturnModel()
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello,my name is PostNoParamReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参post请求，返回一个字符串
        /// </summary>
        /// <returns>返回结果</returns>
        [Route("PostHasParamReturnString")]
        [HttpPost]
        public string PostHasParamReturnString(string name)
        {
            return $"hello {name},my name is PostHasParamReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟有参post请求，返回一个字符串
        /// 路由参数，相关与是直接把参数当着路由处理
        /// </summary>
        /// <returns>返回结果</returns>
        [Route("PostHasParamRoutReturnString/{name}")]
        [HttpPost]
        public string PostHasParamRoutReturnString(string name)
        {
            return $"hello {name},my name is PostHasParamRoutReturnString.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";
        }

        /// <summary>
        /// 模拟有参post请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [Route("PostHasParamReturnModel")]
        [HttpPost]
        public MReturnResult PostHasParamReturnModel(string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is PostHasParamReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参post请求(参数也是一个实体)，返回一个实体模型
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>返回结果</returns>
        [Route("PostModelReturnModel")]
        [HttpPost]
        public MReturnResult PostModelReturnModel(MInputInfor model)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {model.name}+{model.age},my name is PostModelReturnModel.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求(参数来自FromBody)，返回一个实体模型
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromBody")]
        public MReturnResult GetHasParamReturnModelFromBody([FromBody]MInputInfor model)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {model.name}+{model.age},my name is GetHasParamReturnModelFromBody.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromForm1")]
        public MReturnResult GetHasParamReturnModelFromForm1([FromForm]string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is GetHasParamReturnModelFromForm1.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="age">age</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromForm2")]
        public MReturnResult GetHasParamReturnModelFromForm2([FromForm]string name, [FromForm]string age)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name}+{age},my name is GetHasParamReturnModelFromForm2.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求(参数来自FromForm)，返回一个实体模型
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromForm3")]
        public MReturnResult GetHasParamReturnModelFromForm3([FromForm]MInputInfor model)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {model.name}+{model.age},my name is GetHasParamReturnModelFromForm3.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromQuery")]
        public MReturnResult GetHasParamReturnModelFromQuery([FromQuery]string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is GetHasParamReturnModelFromQuery.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModelFromQuery2")]
        public MReturnResult GetHasParamReturnModelFromQuery2([FromQuery]MInputInfor model)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello  {model.name}+{model.age},my name is GetHasParamReturnModelFromQuery2.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        /// <summary>
        /// 模拟有参get请求，返回一个实体模型
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>返回结果</returns>
        [HttpPost("GetHasParamReturnModel22FromRoute/{name}")]
        public MReturnResult GetHasParamReturnModel22FromRoute([FromRoute]string name)
        {
            return new MReturnResult()
            {
                ret = 1,
                msg = $"hello {name},my name is GetHasParamReturnModel2.{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}"
            };
        }

        #endregion
    }
}