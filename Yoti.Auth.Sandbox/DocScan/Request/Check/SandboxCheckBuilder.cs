using System.Collections.Generic;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public abstract class SandboxCheckBuilder<TBuilder, TCheck>
        where TBuilder : SandboxCheckBuilder<TBuilder, TCheck>
        where TCheck : SandboxCheck
    {
        protected SandboxRecommendation Recommendation { get; private set; }
        protected List<SandboxBreakdown> Breakdown { get; private set; } = new List<SandboxBreakdown>();

        public TBuilder WithRecommendation(SandboxRecommendation recommendation)
        {
            Recommendation = recommendation;
            return (TBuilder)this;
        }

        public TBuilder WithBreakdown(SandboxBreakdown breakdown)
        {
            Breakdown.Add(breakdown);
            return (TBuilder)this;
        }

        public TBuilder WithBreakdowns(List<SandboxBreakdown> breakdowns)
        {
            Breakdown = breakdowns;
            return (TBuilder)this;
        }

        public abstract TCheck Build();
    }
}