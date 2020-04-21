using Newtonsoft.Json;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class ResponseConfig
    {
        public ResponseConfig(SandboxTaskResults taskResults, SandboxCheckReports sandboxCheckReports)
        {
            TaskResults = taskResults;
            SandboxCheckReports = sandboxCheckReports;
        }

        [JsonProperty(PropertyName = "task_results")]
        public SandboxTaskResults TaskResults { get; }

        [JsonProperty(PropertyName = "check_reports")]
        public SandboxCheckReports SandboxCheckReports { get; }
    }
}