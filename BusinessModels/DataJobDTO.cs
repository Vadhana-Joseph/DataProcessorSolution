using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessorSolution.BusinessModels
{
    public class DataJobDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FilePathToProcess { get; set; }
        public DataJobStatus Status { get; set; } = DataJobStatus.New;
        public IEnumerable<string> Results { get; set; } = new List<string>();
        public IEnumerable<Link> Links { get; set; } = new List<Link>();
    }
    public enum DataJobStatus
    {
        New,
        Processing,
        Completed
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Action { get; set; }
        public string[] Types { get; set; }
    }
}
