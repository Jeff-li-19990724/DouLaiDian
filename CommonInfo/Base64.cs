using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonInfo
{
    /// <summary>
    /// 实现Base64加密解密
    /// </summary>
    public sealed class Base64
    {
        /// <summary> 
        /// Base64加密 
        /// </summary> 
        /// <param name="codeName">加密采用的编码方式</param> 
        /// <param name="source">待加密的明文</param> 
        /// <returns></returns> 
        //public static string EncodeBase64(Encoding encode, string source)
        //{
        //    byte[] bytes =(byte[]) encode.GetBytes(source);
        //    try
        //    {
        //        encode = Convert.ToBase64String(bytes);
        //    }
        //    catch
        //    {
        //        encode = source;
        //    }
        //    return "";
        //}
        /// <summary>
        /// BASE64解码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64Decode(string s, string encode)
        {
            return Encoding.GetEncoding(encode).GetString(Convert.FromBase64String(s));
        }
        /// <summary>
                /// BASE64编码
                /// </summary>
                /// <param name="s"></param>
                /// <returns></returns>
        public static string Base64Encode(string s, string encode)
        {
            return Convert.ToBase64String(Encoding.GetEncoding(encode).GetBytes(s));
        }
        /// <summary> 
        /// Base64加密，采用utf8编码方式加密 
        /// </summary> 
        /// <param name="source">待加密的明文</param> 
        /// <returns>加密后的字符串</returns> 
        //public static string EncodeBase64(string source)
        //{
        //    return EncodeBase64(Encoding.UTF8, source);
        //}

        ///// <summary> 
        ///// Base64解密 
        ///// </summary> 
        ///// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param> 
        ///// <param name="result">待解密的密文</param> 
        ///// <returns>解密后的字符串</returns> 
        //public static string DecodeBase64(Encoding encode, string result)
        //{
        //    string decode = "";
        //    byte[] bytes = Convert.FromBase64String(result);
        //    try
        //    {
        //        decode = encode.GetString(bytes);
        //    }
        //    catch
        //    {
        //        decode = result;
        //    }
        //    return decode;
        //}

        ///// <summary> 
        ///// Base64解密，采用utf8编码方式解密 
        ///// </summary> 
        ///// <param name="result">待解密的密文</param> 
        ///// <returns>解密后的字符串</returns> 
        //public static string DecodeBase64(string result)
        //{
        //    return DecodeBase64(Encoding.UTF8, result);
        //}
    }
}