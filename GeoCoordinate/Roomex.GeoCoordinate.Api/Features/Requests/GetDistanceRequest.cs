using Roomex.GeoCoordinate.Api.Features.DTOs;

namespace Roomex.GeoCoordinate.Api.Features.Requests;

public record GetDistanceRequest(CoordinateDTO CoordinateA, CoordinateDTO CoordinateB);