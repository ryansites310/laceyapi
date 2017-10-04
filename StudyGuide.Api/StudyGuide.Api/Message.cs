namespace StudyGuide.Api
{
    using System.Runtime.Serialization;

    [DataContract(Name = "message")]
    public class Message
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "severity")]
        public string Severity { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}