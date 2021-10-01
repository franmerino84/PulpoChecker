using CommandLine;
using Microsoft.Toolkit.Uwp.Notifications;
using PulpoChecker.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PulpoChecker
{
    public static class Program
    {
        private const string PulpoUrl = "https://api.pulpo.me/api/ufe/v1/public/groups/catalog?platform_ids=";
        private const string ApiClientIdHeaderValue = "AN5sdz5jKi2UnZe2fmJiDmBHRZgGVAUn3zN5jQj8dZkcjrFhY";
        private const string ApiClientIdHeaderName = "api-client-id";

        public static async Task Main(string[] args)
        {
            var arguments = GetArguments(args);
            var filters = GetFilters(arguments);
            var groups = await GetGroups(filters.Keys);
            var matchedGroups = GetMatchedGroups(groups, filters);
            var minMatchedGroups = matchedGroups.GroupBy(x => x.Platform, x => x.Price, (x, y) => new MatchedGroup() { Platform = x, Price = y.Min() });
            if (minMatchedGroups.Any())
            {
                var output = minMatchedGroups.Select(x => $"{(Platform)x.Platform} -> {x.Price}")
                    .Aggregate((x, y) => $"{x}; {y}");
                new ToastContentBuilder()
                    .AddText(output)
                    .Show();
            }
        }

        private static IEnumerable<MatchedGroup> GetMatchedGroups(IEnumerable<PulpoGroup> groups, Dictionary<int, float> filters) => 
            groups
                .Where(group => filters.Any(filter => group.Platform.Id == filter.Key && group.SlotToPayFloat <= filter.Value && group.SlotNumAvailable > 0))
                .Select(x => new MatchedGroup() { Platform = x.Platform.Id, Price = x.SlotToPayFloat });

        private static PulpoCheckerArguments GetArguments(string[] args) => 
            ((Parsed<PulpoCheckerArguments>)Parser.Default.ParseArguments<PulpoCheckerArguments>(args)).Value;

        private static Dictionary<int, float> GetFilters(PulpoCheckerArguments arguments) => 
            arguments.Platforms.Split(";")
                .Select(x =>
                {
                    var parts = x.Split('-');
                    return new KeyValuePair<int, float>(
                         (int)Enum.Parse(typeof(Platform), parts[0], true),
                         float.Parse(parts[1], CultureInfo.InvariantCulture));
                }).ToDictionary(x => x.Key, x => x.Value);

        private static async Task<IEnumerable<PulpoGroup>> GetGroups(IEnumerable<int> platforms)
        {
            var groups = new List<PulpoGroup>();
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            foreach (var platform in platforms)
            {
                var message = new HttpRequestMessage(HttpMethod.Get, new Uri($"{PulpoUrl}{platform}"));
                message.Headers.Add(ApiClientIdHeaderName, ApiClientIdHeaderValue);
                var response = await client.SendAsync(message);
                var content = await response.Content.ReadAsStringAsync();
                var pulpoResponseContent = JsonSerializer.Deserialize<PulpoResponseContent>(content);
                groups.AddRange(pulpoResponseContent.Data.Groups);
            }
            return groups;
        }
    }
}
