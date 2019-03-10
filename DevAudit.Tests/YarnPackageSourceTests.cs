﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using DevAudit.AuditLibrary;

namespace DevAudit.Tests
{
    public class Yarn : PackageSourceTests 
    {
        protected override PackageSource s { get; } = 
            new YarnPackageSource(new Dictionary<string, object>(){ {"File", @".\Examples\package.json.2" } }, EnvironmentMessageHandler);
			
        public override Task CanGetVulnerabilities()
        {
            throw new NotImplementedException();
        }

        public override void CanComparePackageVersions()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CanTestVulnerabilityVersionInPackageVersionRange()
        {
            Assert.True(s.IsVulnerabilityVersionInPackageVersionRange(">1.2", "<1.5.2"));
            Assert.True(s.IsVulnerabilityVersionInPackageVersionRange("<=4.3", "<4.2"));
            Assert.True(s.IsVulnerabilityVersionInPackageVersionRange(">=1.2.2", ">1.2.0-alpha.0"));
            Assert.True(s.IsVulnerabilityVersionInPackageVersionRange(">12.2.2", "<=20.0.0"));
        }

        [Fact]
        public void CanGetMinimumPackageVersion()
        {
            string version = "^6.26.0";
            Assert.Equal("6.26.0", YarnPackageSource.GetMinimumPackageVersion(version));
        }
    }
}
