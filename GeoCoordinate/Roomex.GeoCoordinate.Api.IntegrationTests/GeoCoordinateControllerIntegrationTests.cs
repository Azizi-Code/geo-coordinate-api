using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Roomex.GeoCoordinate.Api.Features.DTOs;
using Roomex.GeoCoordinate.Api.Features.Requests;
using Roomex.GeoCoordinate.Api.Features.Responses;
using Xunit;

namespace Roomex.GeoCoordinate.Api.IntegrationTests;

public class GeoCoordinateControllerIntegrationTests_GetDistance(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task ValidRequest_ReturnsOkResult()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}";

        var httpResponse = await client.GetAsync(url);

        var distanceResponse = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(distanceResponse);
    }

    [Fact]
    public async Task ValidRequestWithoutCulture_ReturnsResultInKilometerUnit()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}";

        var httpResponse = await client.GetAsync(url);

        var result = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("Kilometers (km)", result.Unit);
    }

    [Fact]
    public async Task ValidRequestWithCultureThatUnitIsInMile_ReturnsResultInMileUnit()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}" +
                  $"&Culture=en-US";

        var httpResponse = await client.GetAsync(url);

        var result = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("Mile", result.Unit);
    }

    [Fact]
    public async Task ValidRequestWithCultureThatUnitIsInKM_ReturnsResultInKMUnit()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}" +
                  $"&Culture=fr-FR";

        var httpResponse = await client.GetAsync(url);

        var result = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("Kilometers (km)", result.Unit);
    }

    [Fact]
    public async Task ValidRequestWithCultureThatDecimalSeparatorIsPoint_ReturnsResultWithPointDecimalSeparator()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}" +
                  $"&Culture=en-US";

        var httpResponse = await client.GetAsync(url);

        var result = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("2390.81", result.Distance);
    }

    [Fact]
    public async Task ValidRequestWithCultureThatDecimalSeparatorIsComma_ReturnsResultWithCommaDecimalSeparator()
    {
        var request = new GetDistanceRequest(new CoordinateDTO(39, -75), new CoordinateDTO(34, -118));
        var client = factory.CreateClient();
        var url = $"api/v1/geocoordinate/distance?" +
                  $"CoordinateA.Latitude={request.CoordinateA.Latitude}&CoordinateA.Longitude={request.CoordinateA.Longitude}" +
                  $"&CoordinateB.Latitude={request.CoordinateB.Latitude}&CoordinateB.Longitude={request.CoordinateB.Longitude}" +
                  $"&Culture=fr-FR";

        var httpResponse = await client.GetAsync(url);

        var result = await httpResponse.Content.ReadFromJsonAsync<DistanceResponse>();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
        Assert.Equal("3847,64", result.Distance);
    }
}