using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonDemo
{
    class TON
    {
        private bool m_InFlag = false;
        private long m_startTime = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IN">bool</param>
        /// <param name="PT">ms</param>
        /// <param name="Q">bool</param>
        /// <param name="ET">ms</param>
        public void Update(bool IN, long PT,ref bool Q,ref long ET)
        {
            if(IN)
            {
                if(!m_InFlag)
                {
                    long sysTime = 0;
                    if(!getSystime(ref sysTime))
                    {
                        m_startTime = 0;
                    }
                    else
                    {
                        m_startTime = sysTime;
                    }
                }
                if(!Q)
                {
                    // Timer is running 
                    long sysTime = 0;
                    getSystime(ref sysTime);

                    ET = (sysTime - m_startTime) / 10000;//获取毫秒

                    if (ET >= PT)
                    {
                        Q = true;
                        ET = PT;
                    }
                }               
            }
            else
            {
                Q = false;
                ET = 0;
            }
            m_InFlag = IN;
        }

        public bool getSystime(ref long time)
        {


            time = DateTime.Now.Ticks;

            return true;
        }
    }
}



/*
1510492154  352 0699
1510492155  355 1272
1510492156  355 1844
1510492157  355 2416
1510492158  355 2988
1510492159  355 3560
1510492160  355 4132
1510492161  355 4704
1510492162  355 5276
1510492163  355 5848
1510492164  355 6420
1510492165  355 6992
1510492166  355 7564
1510492167  355 8136
1510492168  355 8708
1510492169  355 9280
1510492170  355 9852
1510492171  356 0424
1510492172  358 0998
1510492173  358 1570
*/
