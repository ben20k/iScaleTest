using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using Rainfall_API.Models;
using Rainfall_API.Services;
using System.ComponentModel.DataAnnotations;

namespace Rainfall_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {

        private readonly RainfallService _rainfallService;

        public RainfallController(RainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        /// <summary>
        /// Get rainfall readings by station ID
        /// </summary>
        /// <remarks>Retrieve the latest readings for the specified station ID</remarks>
        /// <param name="stationId">The ID of the reading station</param>
        /// <param name="count"></param>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified station ID</response>
        /// <response code="500">Internal server error</response>
        /// 
        //[ProducesResponseType(typeof(List<RainfallReading>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [HttpGet(Name = "GetRainfall")]
        [Route("/rainfall/id/{stationId}/readings")]
        public async Task<ActionResult<RainfallReadingResponse>> GetRainfall(string stationId, [FromQuery] int count)
        {
            try
            {
                // Call the GetRainfallData method of the injected RainfallService
                var rainfall = await _rainfallService.GetRainfallData(stationId, count);

                // Return the rainfall data as a ActionResult
                return Ok(rainfall);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
