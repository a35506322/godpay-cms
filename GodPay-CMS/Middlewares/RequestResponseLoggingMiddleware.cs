using GodPay_CMS.Repositories.Entity;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly IDiagnosticContext _diagnosticContext;
        private CMS_Logs cms_Logs;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
                                                ILogger<RequestResponseLoggingMiddleware> logger,
                                                IDiagnosticContext diagnosticContext)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
            _diagnosticContext = diagnosticContext;
            cms_Logs = new CMS_Logs();
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context) 
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            string controller = (context.Request.RouteValues["controller"] as string).ToLower();
            string action = (context.Request.RouteValues["action"] as string).ToLower();

            var claims = context.User.Claims;
            // SingIn 為第一頁面，所以一定沒有Claims
            if (claims.Count() > 0 && controller != "signin")
            {
                cms_Logs.Account = context.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).Value;
            }

            cms_Logs.TimeStamp = DateTime.Now;
            cms_Logs.RequestMethod = context.Request.Method;
            cms_Logs.RequestPath = context.Request.Path;

            if (context.Request.QueryString.HasValue)
            {
                cms_Logs.QueryString = context.Request.QueryString.Value;
            }

            cms_Logs.RequestHeader = FormatHeaders(context.Request.Headers);

            string requestPayLoad = ReadStreamInChunks(requestStream);
            if (controller != "signinapi" && action != "signin")
            {
                cms_Logs.RequestBody = context.Request.Path.Value.Contains("Files") && requestPayLoad.Length > 500
                ? requestPayLoad.Substring(0, 500) : requestPayLoad;
            }

            cms_Logs.Host = context.Request.Host.ToString();
            cms_Logs.Protocol = context.Request.Protocol;
            cms_Logs.Scheme = context.Request.Scheme;


            _diagnosticContext.Set("Account", cms_Logs.Account);
            _diagnosticContext.Set("RequestMethod", cms_Logs.RequestMethod);
            _diagnosticContext.Set("RequestPath", cms_Logs.RequestPath);
            _diagnosticContext.Set("QueryString", cms_Logs.QueryString);
            _diagnosticContext.Set("RequestHeader", cms_Logs.RequestHeader);
            _diagnosticContext.Set("RequestBody", cms_Logs.RequestBody);
            _diagnosticContext.Set("Host", cms_Logs.Host);
            _diagnosticContext.Set("Protocol", cms_Logs.Protocol);
            _diagnosticContext.Set("Scheme", cms_Logs.Scheme);

            context.Request.Body.Position = 0;
        }

        private async Task LogResponse(HttpContext context) 
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyPayload = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;
            
            cms_Logs.StatusCode = context.Response.StatusCode.ToString();
            cms_Logs.ResponseBody = context.Request.Path.Value.Contains("Files") && responseBodyPayload.Length > 500
                ? responseBodyPayload.Substring(0, 500) : responseBodyPayload;
            // ContentType = text/html為網頁格式，不需要紀錄
            var contentType = !String.IsNullOrEmpty(context.Response.ContentType) ? context.Response.ContentType : string.Empty;
            if (contentType.Contains("text/html"))
            {
                cms_Logs.ResponseBody = string.Empty;
            }
            cms_Logs.ContentType = contentType;

            var endpoint = context.GetEndpoint();
            if (endpoint is object) // endpoint != null
            {
                cms_Logs.EndpointName = endpoint.DisplayName;
            }

            _diagnosticContext.Set("StatusCode", cms_Logs.StatusCode);
            _diagnosticContext.Set("ResponseBody", cms_Logs.ResponseBody);
            _diagnosticContext.Set("ContentType", cms_Logs.ContentType);
            _diagnosticContext.Set("EndpointName", cms_Logs.EndpointName);

            if (ex == null)
            {
                string message = "Account:{Account} DateTime:{Now} RequestMethod:{RequestMethod} ";
                message += "RequestHeader:{RequestHeader} Path{Path} QueryString:{QueryString} ";
                message += "EndpointName:{EndpointName} RequestBody:{RequestBody} Host:{Host} Protocol:{Protocol} Scheme:{Scheme} ";
                message += "StatusCode:{StatusCode} ResponseBody:{ResponseBody} ContentType:{ContentType} EndpointName:{EndpointName}";

                _logger.LogInformation(message,
                        cms_Logs.Account,
                        cms_Logs.TimeStamp,
                        cms_Logs.RequestMethod,
                        cms_Logs.RequestHeader,
                        cms_Logs.RequestPath,
                        cms_Logs.QueryString,
                        cms_Logs.EndpointName,
                        cms_Logs.RequestBody,
                        cms_Logs.Host,
                        cms_Logs.Protocol,
                        cms_Logs.Scheme,
                        cms_Logs.StatusCode,
                        cms_Logs.ResponseBody,
                        cms_Logs.ContentType,
                        cms_Logs.EndpointName);
            }
            else
            {
                cms_Logs.Exception = ex.ToString();
                string message = "Account:{Account} DateTime:{Now} Exception:{Exception} RequestMethod:{RequestMethod} ";
                message += "RequestHeader:{RequestHeader} Path{Path} QueryString:{QueryString} ";
                message += "EndpointName:{EndpointName} RequestBody:{RequestBody} Host:{Host} Protocol:{Protocol} Scheme:{Scheme} ";
                message += "StatusCode:{StatusCode} ResponseBody:{ResponseBody} ContentType:{ContentType} EndpointName:{EndpointName}";
                _logger.LogError(message,
                       cms_Logs.Account,
                       cms_Logs.TimeStamp,
                       cms_Logs.Exception,
                       cms_Logs.RequestMethod,
                       cms_Logs.RequestHeader,
                       cms_Logs.RequestPath,
                       cms_Logs.QueryString,
                       cms_Logs.EndpointName,
                       cms_Logs.RequestBody,
                       cms_Logs.Host,
                       cms_Logs.Protocol,
                       cms_Logs.Scheme,
                       cms_Logs.StatusCode,
                       cms_Logs.ResponseBody,
                       cms_Logs.ContentType,
                       cms_Logs.EndpointName);
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ", headers.Select(kvp => $"{{{kvp.Key}: {string.Join(", ", kvp.Value)}}}"));
    }
}
