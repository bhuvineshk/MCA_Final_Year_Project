

namespace InsuraNex.Models.ViewModels
{
    public  class AddPolicyData
    {
        public  required string PolicyName { get; set; }
        public required DateTime EffectiveDate { get; set; }
        public required string PlanType { get; set; }
        public required string ProductSummary { get; set; }
        public required string Frequency { get; set; }
        public required string FeaturedImageUrl { get; set; }
        public required string UrlHandle { get; set; }
        public required string Term { get; set; }
        public required string MinAge { get; set; }
        public required string MaxAge { get; set; }
        public required string SumAssured { get; set; }
        public required string KeyBenefits { get; set; }
        public required string Features { get; set; }
        public required string PolicyStatus { get;set; }
    }
}
