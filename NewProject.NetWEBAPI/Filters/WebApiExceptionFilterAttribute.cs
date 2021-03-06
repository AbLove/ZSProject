﻿using NewProject.NetWEBAPI.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
namespace NewProject.NetWEBAPI.Filters
{

    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1.记录异常信息
            actionExecutedContext.Exception.Log();
            //2.返回调用方具体的异常信息
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                var oResponse = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                oResponse.Content = new StringContent("方法不被支持");
                oResponse.ReasonPhrase = "This Func is Not Supported";
                actionExecutedContext.Response = oResponse;
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            //.....这里可以根据项目需要返回到客户端特定的状态码。如果找不到相应的异常，统一返回服务端错误500
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new HttpError("请检查参数是否正确" + actionExecutedContext.ActionContext.ControllerContext.Controller));
                //actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            base.OnException(actionExecutedContext);
        }
    }
}