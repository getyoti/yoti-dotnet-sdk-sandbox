namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Liveness
{
    public class ZoomLivenessResourceBuilder
    {
        private string _source;

        public ZoomLivenessResourceBuilder WithSource(string source)
        {
            _source = source;
            return this;
        }

        public ZoomLivenessResource Build()
        {
            Validation.NotNullOrEmpty(_source, nameof(_source));

            return new ZoomLivenessResource(_source);
        }
    }
}