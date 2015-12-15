using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem_EX02
{
    public class ParkingSpace
    {
        public delegate void RefreshFunction(int cur,int total);
        RefreshFunction Refresh;
        private int curSlot;
        private int totalSlot;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">车位总数</param>
        /// <param name="refresh">更新各进程显示车位的函数</param>
        public ParkingSpace(int n, RefreshFunction refresh)
        {
            totalSlot = n;
            curSlot = n;
            Refresh = refresh;
        }
        /// <summary>
        /// 检查是否有空位
        /// </summary>
        /// <returns>true:有车位; false:无车位</returns>
        public bool CheckSlot()
        {
            if (curSlot > 0) return true;
            else return false;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <returns>true:成功 false:错误操作</returns>
        public bool CarIn()
        {
            if (curSlot > 0)
            {
                curSlot--;
                Refresh(curSlot, totalSlot);
                return true;
            }
            else return false;
            
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <returns>true:成功 false:错误操作</returns>
        public bool CarOut()
        {
            if (curSlot < totalSlot)
            {
                curSlot++;
                Refresh(curSlot, totalSlot);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 获取当前车库状况
        /// </summary>
        /// <param name="cur">当前剩余车位</param>
        /// <param name="total">车位总数</param>
        public void GetState(out int cur, out int total)
        {
            cur = curSlot;
            total = totalSlot;
        }
    }
}
