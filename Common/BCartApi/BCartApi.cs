using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace BCartApi
{

    // コマンドパラメータ
    public class ApiCommandParam
    {
        public ApiCommandParam(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {   
            return $"{nameof(ApiCommandParam)}: {nameof(Key)} = {Key},{nameof(Value)} = {Value}";

        }

    }

    // 共通のレスポンス(Error)
    public class cResponseErr
    {
        cErrors[]? errors { get; set; }
    }

    public class cErrors
    {
        string? products { get; set; }
    }

    /// <summary>
    /// API共通
    /// </summary>
    public class HttpApiCommon : IDisposable
    {
        private string ApiUrl = "";
        private string ApiToken = "";

        public string Message { get; set; }
        public string jsonResult { get; set; }
        public string jsonRequest { get; set; }

        public HttpApiCommon()
        {
            this.Message = "";

            this.ApiUrl = ConfigurationManager.AppSettings["ApiUrl"]?? "";
            this.ApiToken = ConfigurationManager.AppSettings["ApiToken"] ?? "";
        }

        /// <summary>
        /// GETコマンド用パラメータUrl変換
        /// </summary>
        /// <param name="prm"></param>
        /// <returns></returns>
        protected string GetCommandParamUrl(ApiCommandParam[] prm)
        {
            List<string> ret = new List<string>();
            foreach (var p in prm)
            {
                ret.Add(string.Format("{0}={1}", p.Key, p.Value));
            }
            return "?" + string.Join("&", ret.ToArray());
        }


        /// <summary>
        /// GETコマンド（一覧）
        /// </summary>
        /// <typeparam name="T">ResponseType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="prm"></param>
        /// <returns></returns>
        public T? GetListCommand<T>(string commandUri, params ApiCommandParam[] prm)
        {
            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";

            //ログ
            Log.Write($"{nameof(GetListCommand)},{commandUri} 処理開始");
            foreach (var item in prm.ToList())
            {
                Log.Write(item.ToString());
            }
            try
            {   
                string url = this.ApiUrl + commandUri + GetCommandParamUrl(prm);

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);
                var response = req.GetAsync(url).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(jsonResult);      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T>(jsonResult, resOpts);

                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T);
        }

        /// <summary>
        /// GETコマンド（ID指定）
        /// </summary>
        /// <typeparam name="T">ResponseType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T? GetCommandId<T>(string commandUri, string id)
        {
            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";
            try
            {
                string url = this.ApiUrl + commandUri + "/" + id;

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);
                var response = req.GetAsync(url).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(jsonResult);      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T>(jsonResult, resOpts);

                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T);
        }

        /// <summary>
        /// GETコマンド（ID指定）
        /// </summary>
        /// <typeparam name="T">ResponseType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T? GetCommandCode<T>(string commandUri)
        {
            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";
            try
            {
                string url = this.ApiUrl + commandUri;

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);
                var response = req.GetAsync(url).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(jsonResult);      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T>(jsonResult, resOpts);

                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T);
        }

        /// <summary>
        /// PATCHコマンド（一覧）
        /// </summary>
        /// <typeparam name="T1">RequestType</typeparam>
        /// <typeparam name="T2">ResposeType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="prm"></param>
        /// <returns></returns>
        public T2? PatchListCommand<T1,T2>(string commandUri, T1 data)
        {
            //throw new Exception("※未確認のコマンドです。");

            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";
            try
            {
                string url = this.ApiUrl + commandUri;

                // jsonシリアライズ
                var reqOpts = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                jsonRequest = JsonSerializer.Serialize<T1>(data, reqOpts);
                Log.Write("RequestData:");
                Log.Write(Regex.Unescape(jsonRequest));      // ログにパラメータを出力

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);
                using StringContent jsonContent = new(
                    jsonRequest,
                    Encoding.UTF8,
                    "application/json");
                var response = req.PatchAsync(url, jsonContent).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(Regex.Unescape(jsonResult));      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T2>(jsonResult, resOpts);

                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T2);
        }

        /// <summary>
        /// PATCHコマンド（ID指定）
        /// </summary>
        /// <typeparam name="T1">RequestType</typeparam>
        /// <typeparam name="T2">ResposeType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public T2? PatchCommandId<T1,T2>(string commandUri, string id, T1 data)
        {
            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";

            try
            {
                string url = this.ApiUrl + commandUri + "/" + id;

                // jsonシリアライズ
                var reqOpts = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                jsonRequest = JsonSerializer.Serialize<T1>(data, reqOpts);
                Log.Write("RequestData:");
                Log.Write(Regex.Unescape(jsonRequest));      // ログにパラメータを出力

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);
                using StringContent jsonContent = new(
                    jsonRequest,
                    Encoding.UTF8,
                    "application/json");
                var response = req.PatchAsync(url, jsonContent).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(Regex.Unescape(jsonResult));      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T2>(jsonResult, resOpts);

                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T2);
        }

        /// <summary>
        /// Postコマンド
        /// </summary>
        /// <typeparam name="T1">RequestType</typeparam>
        /// <typeparam name="T2">ResposeType</typeparam>
        /// <param name="commandUri"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public T2? PostCommand<T1,T2>(string commandUri, T1 data)
        {
            this.Message = "";
            this.jsonRequest = "";
            this.jsonResult = "";
            try
            {
                string url = this.ApiUrl + commandUri + "/";

                HttpClient req = new HttpClient();
                req.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.ApiToken);

                // jsonシリアライズ
                var reqOpts = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                jsonRequest = JsonSerializer.Serialize<T1>(data, reqOpts);
                Log.Write("RequestData:");
                Log.Write(Regex.Unescape(jsonRequest));      // ログにパラメータを出力

                using StringContent jsonContent = new(
                    jsonRequest,
                    Encoding.UTF8,
                    "application/json");
                var response = req.PostAsync(url, jsonContent).Result;
                jsonResult = response.Content.ReadAsStringAsync().Result;
                Log.Write("ResponseData:");
                Log.Write(Regex.Unescape(jsonResult));      // ログに結果を出力

                // jsonデシリアライズ
                JsonSerializerOptions resOpts = new()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                    WriteIndented = true
                };
                var obj = JsonSerializer.Deserialize<T2>(jsonResult, resOpts);
 
                return obj;
            }
            catch (Exception ex)
            {
                Log.ErrWrite(MethodBase.GetCurrentMethod().Name, ex);
                this.Message = ex.Message;
            }
            return default(T2);
        }


        public void Dispose()
        {
            ;
        }
    }
}


