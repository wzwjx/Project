using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace PostDe
{
    public class Helper
    {
        #region try to get webapi token
        /// <summary>
        /// Try to get the token.
        /// </summary>
        /// <param name="uri">webapi adress</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetToken(Uri uri, string username, string password)
        {
            //post data.

            string postData = "{\"phonenumber\":\"" + username;
            postData += ("\",\"pwd\":\"" + password + "\"}");
            byte[] data = Encoding.UTF8.GetBytes(postData);

            try
            {
                //Create a heepwebrequest object.
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json;charset=UTF-8";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.ContentLength = data.Length;

                Stream newStream = httpWebRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                //Get the Response.
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                var token =Helper.GetJsonValue(streamReader.ReadToEnd(), "token").Replace("\"", "");
                return token;
            }
            catch
            {
                return string.Empty;
            }
            
        }
        #endregion

        #region try to get json matters data with token and Parse into list object
        /// <summary>
        /// try to get json matters data with token and Parse into list object
        /// </summary>
        /// <param name="token"></param>
        /// <returns>List<Matters></returns>
        public static List<Matters> tryGetMatters(string token)
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://daydayup.ink/api/Matter/GetMatters");


            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Headers.Add("Authorization", token);
            httpWebRequest.ContentLength = 0;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            var message = streamReader.ReadToEnd();
            JObject jobject = null;

            List<Matters> matters = new List<Matters>();
            try
            {
                jobject = JObject.Parse(message);
                JArray jlist = JArray.Parse(jobject["matters"].ToString());
                Matters matter = null;
                for (int i = 0; i < jlist.Count; i++)
                {
                    matter = new Matters();
                    JObject tempo = JObject.Parse(jlist[i].ToString());
                    matter.id = tempo["id"].ToString();
                    matter.lasttime = tempo["lasttime"].ToString();
                    matter.moduleid = tempo["moduleid"].ToString();
                    matter.name = tempo["name"].ToString();
                    matter.roletype = tempo["roletype"].ToString();
                    matter.@abstract = tempo["abstract"].ToString();
                    matter.createtime = tempo["createtime"].ToString();
                    matter.createuserid = tempo["createuserid"].ToString();
                    matter.createusername = tempo["createusername"].ToString();
                    matter.createuserimg = tempo["createuserimg"].ToString();
                    matters.Add(matter);
                }
            }
            catch
            {
                //do nothing
            }

            return matters;
        }

        #endregion

        #region List<T> to DataTable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        #endregion

        public static string GetJsonValue(string jsonStr, string key)
        {
            JObject attribute = (JObject)JsonConvert.DeserializeObject(jsonStr);
            return attribute[key].ToString();
        }
        
    }
}