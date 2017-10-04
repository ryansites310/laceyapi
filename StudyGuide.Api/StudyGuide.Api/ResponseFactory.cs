namespace StudyGuide.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ResponseFactory: IResponseFactory
    {
        //private readonly IExceptionManager _exceptionManager;

        //public ResponseFactory(IExceptionManager exceptionManager)
        //{
        //    _exceptionManager = exceptionManager;
        //}

        public Response<T> CreateSuccessResponse<T>(T data, Pagination pagination) where T : class
        {
            var message = new Message { Code = "200", Severity = "normal", Description = "ok", Name = "ok" };
            var status = new Status {Messages = new[] {message}};
            var response = new Response<T>(data)
            {
                Meta = new Meta() {TransactionId = Guid.NewGuid().ToString()},
                ResultMeta = new ResultMeta {Pagination = pagination ?? new Pagination()},
                Status = status,
                Data = data
            };

            return response;
        }

        public Response<T> CreateErrorResponse<T>(T data, Exception e) where T : class
        {

            var message = new Message { Code = "500", Severity = "error", Description = e.Message, Name = "error" };
            var status = new Status {Messages = new[] {message}};
            var response = new Response<T>(null)
            {
                Meta = new Meta() {TransactionId = Guid.NewGuid().ToString()},
                Status = status
            };

            //_exceptionManager.HandleException(e);

            return response;
        }

        public Response<T> CreateValidationResponse<T>(T data, IEnumerable<string> validationMessages) where T : class
        {
            var status = new Status();

            var messages = new List<Message>();
            validationMessages.ToList().ForEach(m =>
            {
                var message = new Message { Code = "500", Severity = "validation", Description = m, Name = "error" };
                messages.Add(message);
            });
            status.Messages = messages.ToArray();

            var response = new Response<T>(null)
            {
                Meta = new Meta() {TransactionId = Guid.NewGuid().ToString()},
                Status = status
            };


            return response;
        }

    }
}