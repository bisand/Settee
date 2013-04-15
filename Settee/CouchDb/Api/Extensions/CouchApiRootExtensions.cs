﻿using System;
using System.Web;
using Biseth.Net.Settee.CouchDb.Api.Elements;
using Biseth.Net.Settee.Http;

namespace Biseth.Net.Settee.CouchDb.Api.Extensions
{
    public static class CouchApiRootExtensions
    {
        public static CouchApiRootCommand ActiveTasks(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_active_tasks/"
            };
            return result;
        }

        public static CouchApiRootCommand AllDbs(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_all_dbs/"
            };
            return result;
        }

        public static CouchApiRootCommand Log(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_log/"
            };
            return result;
        }

        public static CouchApiRootCommand Replicate(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_replicate/"
            };
            return result;
        }

        public static CouchApiRootCommand Restart(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_restart/"
            };
            return result;
        }

        public static CouchApiRootCommand Stats(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_stats/"
            };
            return result;
        }

        public static CouchApiRootCommand Utils(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_utils/"
            };
            return result;
        }

        public static CouchApiRootCommand UuIds(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_uuids/"
            };
            return result;
        }

        public static CouchApiRootCommand Favicon(this CouchApiRoot element)
        {
            var result = new CouchApiRootCommand(element.RequestClient) {
                PathElement = element.PathElement + "_favicon.ico/"
            };
            return result;
        }

        public static ResponseData<T> Get<T>(this CouchApiRoot element)
        {
            var responseData = element.RequestClient.Get<T>(element.PathElement);
            return responseData;
        }

        public static ResponseData<TOut> Put<TIn, TOut>(this CouchApiRoot element, TIn obj = default(TIn))
        {
            var requestData = new RequestData<TIn>(element.PathElement, obj, "application/json");
            var responseData = element.RequestClient.Put<TIn, TOut>(requestData);
            return responseData;
        }

        public static ResponseData<TOut> Post<TIn, TOut>(this CouchApiRoot element, TIn obj = default(TIn))
        {
            var requestData = new RequestData<TIn>(element.PathElement, obj, "application/json");
            var responseData = element.RequestClient.Post<TIn, TOut>(requestData);
            return responseData;
        }
    }
}