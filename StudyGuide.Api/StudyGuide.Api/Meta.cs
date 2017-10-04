namespace StudyGuide.Api
{
    using System.Runtime.Serialization;

    [DataContract(Name = "meta")]
    public class Meta
    {
        [DataMember(Name = "transaction_id")]
        public string TransactionId { get; set; }
    }
}