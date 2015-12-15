using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_EX02
{
    public class ProcMessage
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public int type;
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime time;
        /// <summary>
        /// 消息来源
        /// </summary>
        public int src;

        public static readonly int msgRelease = 0;
        public static readonly int msgRequest = 1;
        public static readonly int msgReply = 2;
    }
}
