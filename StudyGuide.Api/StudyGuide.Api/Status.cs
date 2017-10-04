namespace StudyGuide.Api
{
    using System.Runtime.Serialization;

    [DataContract(Name = "status")]
    public class Status
    {
        [DataMember(Name = "messages")]
        public Message[] Messages { get; set; }
    }
}