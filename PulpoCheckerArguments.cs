using CommandLine;

namespace PulpoChecker
{
    public class PulpoCheckerArguments
    {
        [Option('p', "platforms", Required = true)]
        public string Platforms { get; set; }        
        
    }
}
