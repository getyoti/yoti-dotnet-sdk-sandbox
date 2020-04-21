using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class ResponseConfigBuilder
    {
        private SandboxTaskResults _taskResults;
        private SandboxCheckReports _sandboxCheckReports;

        public ResponseConfigBuilder WithTaskResults(SandboxTaskResults taskContainer)
        {
            _taskResults = taskContainer;
            return this;
        }

        public ResponseConfigBuilder WithCheckReports(SandboxCheckReports sandboxCheckReports)
        {
            _sandboxCheckReports = sandboxCheckReports;
            return this;
        }

        public ResponseConfig Build()
        {
            return new ResponseConfig(_taskResults, _sandboxCheckReports);
        }
    }
}