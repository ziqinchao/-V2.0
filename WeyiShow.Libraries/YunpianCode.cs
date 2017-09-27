using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeyiShow.MODELS;

namespace WeyiShow.Libraries
{
    public class YunpianCode
    {
        /// <summary>
        /// 用于生成随机的验证码
        /// </summary>
        /// <param name="codeLength">验证码的长度</param>
        /// <returns></returns>
        public string GetRandom(int codeLength)
        {
            string code = "";
            Random rnd = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                code += rnd.Next(10).ToString();
            }
            return code;

        }


        public string SingleSend(string phone, string code)
        {
            // apikey
            string apikey = "100a17dbd4ce590f711b6c422413c050";
            // 发送的手机号
            string mobile = phone;
            // 发送内容
            string text = "【唯艺网】您的验证码是" + code + "。如非本人操作，请忽略本短信";
            // 智能模板发送短信url
            string url_send_sms = "https://sms.yunpian.com/v2/sms/single_send.json";
            string data_send_sms = "apikey=" + apikey + "&mobile=" + mobile + "&text=" + text;
            // post方式请求
            string result= RequestData(url_send_sms, data_send_sms);
            YunResult yunpian = JsonConvert.DeserializeObject<YunResult>(result);
            return yunpian.code;
        }


        /// <summary>
        /// post请求方式
        /// </summary>
        /// <param name="POSTURL"></param>
        /// <param name="PostData"></param>
        /// <returns></returns>
        public static string RequestData(string POSTURL, string PostData)
        {
            //发送请求的数据
            WebRequest myHttpWebRequest = WebRequest.Create(POSTURL);
            myHttpWebRequest.Method = "POST";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byte1 = encoding.GetBytes(PostData);
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.ContentLength = byte1.Length;
            Stream newStream = myHttpWebRequest.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            //发送成功后接收返回的XML信息
            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            string lcHtml = string.Empty;
            Encoding enc = Encoding.GetEncoding("UTF-8");
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, enc);
            lcHtml = streamReader.ReadToEnd();
            return lcHtml;
        }
    }
}
