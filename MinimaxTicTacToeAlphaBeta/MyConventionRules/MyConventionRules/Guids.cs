// Guids.cs
// MUST match guids.h
using System;

namespace Company.MyConventionRules
{
    static class GuidList
    {
        public const string guidMyConventionRulesPkgString = "6bf18a23-27cf-4d03-9fb0-aae815f74cf6";
        public const string guidMyConventionRulesCmdSetString = "02d2cbd2-d7d2-4b37-8937-8aee96cfa485";

        public static readonly Guid guidMyConventionRulesCmdSet = new Guid(guidMyConventionRulesCmdSetString);
    };
}