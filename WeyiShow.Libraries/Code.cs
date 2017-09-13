using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;
using Yunpian.lib;
using Yunpian.model;

namespace WeyiShow.Libraries
{
    public class Code
    {
        private int codeLength = 6;
        private string code = "";

        /// <summary>
        /// 用于生成随机的验证码
        /// </summary>
        /// <param name="codeLength">验证码的长度</param>
        /// <returns></returns>
        public string GetRandom(int codeLength)
        {
            Random rnd = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                code += rnd.Next(10).ToString();
            }
            return code;
        }

        /// <summary>
        /// 用于发送短信验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        public bool sendSms(string phone, string code)
        {
            DateTime time = DateTime.Now;
            //设置apikey
            Config config = new Config("100a17dbd4ce590f711b6c422413c050");
            Dictionary<string, string> data = new Dictionary<string, string>();
            Result result = null;
            // 发送单条短信
            SmsOperator sms = new SmsOperator(config);
            data.Clear();
            data.Add("mobile", phone);
            data.Add("text", "【唯艺网】您的验证码是" + code + "。如非本人操作，请忽略本短信");
            result = sms.singleSend(data);
            return result.success;

        }
    }
}
