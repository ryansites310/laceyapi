
namespace StudyGuide.Api
{
    public class Response<T> : IResponse<T> where T : class
    {
        public Response(T data)
        {
            Data = data;
        }
        
        public Meta Meta { get; set; }
        public ResultMeta ResultMeta { get; set; }
        public T Data { get; set; }
        public Status Status { get; set; }
    }
}