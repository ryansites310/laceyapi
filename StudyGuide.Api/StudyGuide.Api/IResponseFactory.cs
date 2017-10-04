namespace StudyGuide.Api
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IResponseFactory
    {
        Response<T> CreateSuccessResponse<T>(T data, Pagination pagination) where T : class;

        Response<T> CreateErrorResponse<T>(T data, Exception e) where T : class;

        Response<T> CreateValidationResponse<T>(T data, IEnumerable<string> validationMessages) where T : class;
    }
}
