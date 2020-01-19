using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYH.Tools.HttpTool.TestModel
{
    /// <summary>
    /// 处理结果model
    /// </summary>
    public class MReturnResult
    {
        /// <summary>
        /// 返回结果编码
        /// 0：代表处理成功
        /// -1：代表处理失败
        /// </summary>
        public int ret { get; set; }

        /// <summary>
        /// 主要记录处理结果描述信息.比如失败原因等等
        /// </summary>
        public string msg { get; set; }
    }
}
