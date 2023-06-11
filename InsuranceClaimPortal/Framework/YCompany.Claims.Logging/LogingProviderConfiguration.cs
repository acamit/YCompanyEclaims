namespace YCompany.Claims.Logging
{
    public sealed class LogingProviderConfiguration
    {
        public string? AWSAccessKeyId { get; set; }
        public string? AWSSecretAccessKey { get; set; }
        public string? AWSRegionEndpoint { get; set; }
        public string? LogQueueUrl { get; set; }

    }
}