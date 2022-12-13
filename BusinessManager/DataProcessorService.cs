using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProcessorSolution.BusinessModels;

namespace DataProcessorSolution.BusinessManager
{
    public class DataProcessorService : IDataProcessorService
    {
        static List<DataJobDTO> dataJobs = new List<DataJobDTO>();
        public DataProcessorService()
        {
            InitializeData();
        }

        public static void InitializeData()
        {
            try
            {
                //Object 1 New
                string[] types = { "a", "b", "c" };
                List<Link> links = new List<Link>();
                Link link1 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types };
                Link link2 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types };
                links.Add(link1);
                links.Add(link2);
                dataJobs.Add(new DataJobDTO
                {
                    FilePathToProcess = "path1",
                    Id = new Guid(),
                    Name = "name1",
                    Links = links,
                    Results = new List<string>() { "result 1", "result2" },
                    Status = DataJobStatus.New
                });

                //Object 2 Processing
                string[] types1 = { "a", "b", "c" };
                IEnumerable<Link> links1 = new List<Link>();
                Link link2_1 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types1 };
                Link link2_2 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types1 };
                links1.ToList().Add(link2_1);
                links1.ToList().Add(link2_2);
                dataJobs.Add(new DataJobDTO
                {
                    FilePathToProcess = "path2",
                    Id = new Guid(),
                    Name = "name2",
                    Links = links1,
                    Results = new List<string>() { "result 1", "result2" },
                    Status = DataJobStatus.Processing
                });

                //Object 2 Completed
                string[] types2 = { "a", "b", "c" };
                IEnumerable<Link> links3 = new List<Link>();
                Link link3_1 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types2 };
                Link link3_2 = new Link { Action = "Action1", Href = "Href1", Rel = "Rel1", Types = types2 };
                links3.ToList().Add(link2_1);
                links3.ToList().Add(link2_2);
                dataJobs.Add(new DataJobDTO
                {
                    FilePathToProcess = "path2",
                    Id = new Guid(),
                    Name = "name2",
                    Links = links3,
                    Results = new List<string>() { "result 1", "result2" },
                    Status = DataJobStatus.Completed
                });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<DataJobDTO> GetAllDataJobs()
        {
            return dataJobs;
        }

        public IEnumerable<DataJobDTO> GetDataJobsByStatus(DataJobStatus status)
        {
            try
            {
                IEnumerable<DataJobDTO> datas = dataJobs.Where(t => t.Status == status);
                return datas;
            }
            catch
            {
                return null;
            }
        }

        public DataJobDTO GetDataJob(Guid id)
        {
            try
            {
                return dataJobs.Where(t => t.Id.Equals(id)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public DataJobDTO Create(DataJobDTO dataJob)
        {
            try
            {
                dataJobs.Add(dataJob);
                return dataJob;
            }
            catch
            {
                return null;
            }
        }

        public DataJobDTO Update(DataJobDTO dataJob)
        {
            try
            {
                DataJobDTO data = dataJobs.Where(t => t.Id.Equals(dataJob.Id)).FirstOrDefault();
                dataJobs.Remove(data);
                dataJobs.Add(dataJob);
                return dataJob;
            }
            catch
            {
                return null;
            }
        }

        public void Delete(Guid dataJobID)
        {
            try
            {
                var v = dataJobs.RemoveAll(t => t.Id.Equals(dataJobID));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
