using Roomex.GeoCoordinate.Api.Domain.Models;
using Roomex.GeoCoordinate.Api.Features.DTOs;

namespace Roomex.GeoCoordinate.Api.Features.Mappers;

public static class CoordinateMapper
{
    public static Domain.Models.GeoCoordinate ToModel(this CoordinateDTO coordinateDto) =>
        new(new Latitude(coordinateDto.Latitude), new Longitude(coordinateDto.Longitude));
}