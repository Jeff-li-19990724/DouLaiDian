using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace Com.Api.Work.Unit
{
    public class CommonToken
    { 
        public CommonToken()
        {
            UserName = "j";
            Pwd = "123456";
        }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }

    public class TokenHelper
    {
        public static string SecretKey = "bqsid123k12s0h1d3uhf493fh02hdd102h9s3h38ff";//这个服务端加密秘钥 属于私钥
        private static JavaScriptSerializer myJson = new JavaScriptSerializer();
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static string GenToken(CommonToken M)
        {
            var payload = new Dictionary<string, dynamic>
            {
                {"UserName", M.UserName},//用于存放当前登录人账户信息
                {"UserPwd", M.Pwd}//用于存放当前登录人登录密码信息
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(payload, SecretKey);
        }
        /// <summary>
        /// 验证Token
        /// </summary>
        /// <returns></returns>
        public static string DecodeToken()
        {

            //HttpRequest result = new HttpRequest();
            //result.Headers.Add("Authorization", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VyTmFtZSI6IjEzNjc2Njg3OTgiLCJVc2VyUHdkIjoiVXNlciJ9.KlPLQQdKt3qyBRZ9g1FEEDEPexxJDUnJ-eGYW2Yx1Bs");
            //获取request中的token
            string token = HttpContext.Current.Request.Headers["Authorization"];
            //去掉前面的Bearer
            if (token != null && token.StartsWith("Bearer"))
                token = token.Substring("Bearer ".Length).Trim();
            try
            {
                var json = GetTokenJson(token);
                CommonToken info = myJson.Deserialize<CommonToken>(json);
                return "Token is true";
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return "Token has invalid signature";
            }
        }

        public static string GetTokenJson(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, SecretKey, verify: true);
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}