using Com.Api.Work.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Com.Api.Work.Controllers
{
    public class ValuesController : ApiController
    {
        private string password="User";
        private string tel="1367668798";

        // GET api/values
        public IEnumerable<string> Get()
        {
            //生成Token
            CommonToken tokenInfo = new CommonToken();
            //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VyTmFtZSI6IjEzNjc2Njg3OTgiLCJVc2VyUHdkIjoiVXNlciJ9.KlPLQQdKt3qyBRZ9g1FEEDEPexxJDUnJ-eGYW2Yx1Bs
            //eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VyTmFtZSI6IjEzNjc2Njg3OTgiLCJVc2VyUHdkIjoiVXNlciJ9.KlPLQQdKt3qyBRZ9g1FEEDEPexxJDUnJ-eGYW2Yx1Bs
            tokenInfo.Pwd = password;
            tokenInfo.UserName = tel;
            string token = TokenHelper.GenToken(tokenInfo);
           
            //token验证
           string tokenInfoForUser = TokenHelper.DecodeToken();
           
            return new string[] { "value1", token };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
