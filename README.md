# Distance Calculator Web API

A geodesic curve describes a line in a curved surface, this is ideal for calculating the distance
between cities knowing their coordinates. If we consider the earth as a sphere and not as an ellipsoid
we can apply the cosine law between the points:

![](https://github.com/Azizi-Code/geo-coordinate-api/blob/main/img.png) 

cos p = cos a cos b + sin a sin b cos φ
##

Given the coordinates in latitude and longitude of A and B we can calculate:
- a = 90Â° – lat(B)
- b = 90Â° – lat(A)
- φ = lon(A) – lon(B)

Given the coordinates of two cities:

- City A: \(53.297975, -6.372663\)
- City B: \(41.385101, -81.440440\)

Knowing that the radius of the earth is R = 6371 km create a c# web API .net core application
that receives as input the coordinates and returns its distance in Km.
While designing the solution consider that different approaches exist to calculate the distance, for
example ignoring the sphericity of the earth and applying Pythagoras can be a method by
approximation, or considering the earth as ellipsoid is another method. Also, different measuring
units could be required as output depending on the locale.
The goal is to provide a solution that applies SOLID principles and design patterns and has unit tests,
and possible integration tests. Not only the results will evaluated but also the code style.
The task isn’t expected to take long. We expect that it is shared on a repo such as GitHub and
close to a production-ready state.
