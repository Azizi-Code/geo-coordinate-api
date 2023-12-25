using Roomex.GeoCoordinate.Api.Features.DTOs;

namespace Roomex.GeoCoordinate.Api.Features.Requests;

public record GetDistanceRequest(CoordinateDTO LocationA, CoordinateDTO LocationB);