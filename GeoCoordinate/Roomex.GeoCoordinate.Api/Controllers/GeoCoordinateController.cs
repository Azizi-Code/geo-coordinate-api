using Microsoft.AspNetCore.Mvc;
using Roomex.GeoCoordinate.Api.Features.Requests;
using Roomex.GeoCoordinate.Api.Services;

namespace Roomex.GeoCoordinate.Api.Controllers;

[ApiController]
[Route("api/v1/geocoordinate")]
public class GeoCoordinateController(
    IGeoCoordinatorService geoCoordinatorService,
    ILogger<GeoCoordinateController> logger) : Controller
{
    [HttpGet("distance")]
    public IActionResult GetDistance([FromQuery] GetDistanceRequest request, string? culture = null)
    {
        //this try/catch block can be refactor with a middleware for handling exceptions and logging in a  proper way. 
        try
        {
            var result = geoCoordinatorService.GetDistance(request.LocationA, request.LocationB, culture);
            return Ok(result);
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e.Message);
            return BadRequest(e.Message);
        }
    }
}