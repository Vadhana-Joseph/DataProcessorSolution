using DataProcessorSolution.BusinessManager;
using DataProcessorSolution.BusinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessorSolution.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataProcessorController : ControllerBase
    {
        private readonly IDataProcessorService dataProcessorService;
        public DataProcessorController(IDataProcessorService _dataProcessorService)
        {
            dataProcessorService = _dataProcessorService;
        }

        /// <summary>
        /// API to all the DataJobs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DataJobDTO> GetAllDataJobs()
        {
            return dataProcessorService.GetAllDataJobs();
        }

        /// <summary>
        /// API to fetch the DataJobs for the given status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DataJobDTO> GetDataJobsByStatus(DataJobStatus status)
        {
            return dataProcessorService.GetDataJobsByStatus(status);
        }

        /// <summary>
        /// API to fetch the specific DataJob of given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public DataJobDTO GetDataJob(Guid id)
        {
            return dataProcessorService.GetDataJob(id);
        }

        /// <summary>
        /// Create a new DataJob
        /// </summary>
        /// <param name="dataJob"></param>
        /// <returns></returns>
        [HttpPost]
        public DataJobDTO Create([FromBody] DataJobDTO dataJob)
        {
            return dataProcessorService.Create(dataJob);
        }


        /// <summary>
        /// API to update the Datajob
        /// </summary>
        /// <param name="dataJob"></param>
        /// <returns></returns>
        [HttpPatch]
        public DataJobDTO Update([FromBody]DataJobDTO dataJob)
        {
            return dataProcessorService.Update(dataJob);
        }

        /// <summary>
        /// API to delete a datajob - given Id
        /// </summary>
        /// <param name="dataJobID"></param>
        [HttpDelete]
        public void Delete(Guid dataJobID)
        {
            dataProcessorService.Delete(dataJobID);
        }
    }
}
