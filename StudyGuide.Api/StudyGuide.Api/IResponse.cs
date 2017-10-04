namespace StudyGuide.Api
{
    using System.Runtime.Serialization;

    public interface IResponse<T> where T : class
    {
        [DataMember(Name = "meta")]
        Meta Meta { get; set; }

        [DataMember(Name = "resultmeta")]
        ResultMeta ResultMeta { get; set; }

        [DataMember(Name = "data")]
        T Data { get; set; }

        [DataMember(Name = "status")]
        Status Status { get; set; }
    }
}