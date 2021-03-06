﻿using MasterData.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MasterData.Core
{
    abstract public class AbstractConnector
    {
        internal string nodeAlias;
        internal string host;

    public AbstractConnector()
        {
            var Section = ConfigurationManager.GetSection("masterData");
            if (Section == null)
                throw new MasterDataConfigurationException("Section 'masterData' in App.config file is missing.");
            NameValueCollection masterDataSettings = Section as NameValueCollection;

            try
            {
                string sIsEnabled = masterDataSettings["IsEnabled"];
                if (!Convert.ToBoolean(sIsEnabled))
                    throw new MasterDataNotEnabledException("MasterData is not enabled.");
            }
            catch (MasterDataNotEnabledException) { }
            catch (Exception ex)
            {
                throw new MasterDataConfigurationException("Invalid value for 'IsEnabled' key. It must be 'true' or 'false'. Check, please, the App.config file" , ex);
            }

            host = masterDataSettings["Host"];
            if (string.IsNullOrEmpty(host))
                throw new MasterDataConfigurationException("The key 'host' not found. Check, please, the App.config file");

            nodeAlias = masterDataSettings["NodeAlias"];
            if (nodeAlias == null)
                throw new MasterDataConfigurationException("The key 'nodeAlias' not found. Check, please, the App.config file");
        }

        //internal void HttpPostDataAs<T>(string serverPath, T data)
        //{
        //    UriBuilder uriBuilder = new UriBuilder(host);
        //    uriBuilder.Path += serverPath;
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
        //    request.Method = "POST";
        //    request.ContentType = "application/json; charset=utf-8";

        //    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
        //    Stream dataStream = request.GetRequestStream();
        //    jsonFormatter.WriteObject(dataStream, data);
        //    dataStream.Close();

        //    HttpWebResponse httpRes;
        //    try
        //    {
        //        httpRes = (HttpWebResponse)request.GetResponse();
        //    }
        //    catch (WebException ex)
        //    {
        //        httpRes = (HttpWebResponse)ex.Response;
        //    }

        //    if (httpRes.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        dataStream = httpRes.GetResponseStream();
        //        DataContractJsonSerializer jsonStringFormatter = new DataContractJsonSerializer(typeof(string));
        //        string responseString = (string)jsonStringFormatter.ReadObject(dataStream);

        //        throw new MasterDataValidationException("Данные не прошли проверку\r\n" + responseString);
        //    }
        //    else if (httpRes.StatusCode != HttpStatusCode.OK)
        //    {
        //        throw new HttpRequestException(httpRes.StatusDescription);
        //    }

        //    httpRes.Close();
        //}

        internal void HttpPostDataAs<T>(string serverPath, T data)
        {
            UriBuilder uriBuilder = new UriBuilder(host);
            uriBuilder.Path += serverPath;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            Stream dataStream = request.GetRequestStream();
            jsonFormatter.WriteObject(dataStream, data);
            dataStream.Close();

            HttpWebResponse httpRes;
            try
            {
                httpRes = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                httpRes = (HttpWebResponse)ex.Response;
            }

            if (httpRes.StatusCode == HttpStatusCode.BadRequest)
            {
                dataStream = httpRes.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(dataStream, Encoding.UTF8);
                string jsonResult = responseStreamReader.ReadToEnd();
                var obj = new { Message = "", ModelState = new Dictionary<string, string[]>() };
                var badRequestResult = JsonConvert.DeserializeAnonymousType(jsonResult, obj);

                MasterDataValidationException ex = new MasterDataValidationException(string.Format("Данные не прошли проверку - {0}\r\n", badRequestResult.Message));
                if (badRequestResult.ModelState != null)
                {
                    var errors = badRequestResult.ModelState.Select(kvp => string.Join(". ", kvp.Value));
                    for (int i = 0; i < errors.Count(); i++)
                        ex.Data.Add(i, errors.ElementAt(i));
                }
                throw ex;
            }
            else if (httpRes.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(httpRes.StatusDescription);
            }

            httpRes.Close();
        }

        internal T HttpGetDataAs<T>(string serverPath)
        {
            UriBuilder uriBuilder = new UriBuilder(host);
            uriBuilder.Path += serverPath;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            T readObject = (T)jsonFormatter.ReadObject(dataStream);

            response.Close();
            return readObject;
        }

        abstract public AbstractSubject Get(int Id);
        abstract public List<AbstractSubject> GetMany();
        abstract public void Post(AbstractSubject subject);
    }
}
