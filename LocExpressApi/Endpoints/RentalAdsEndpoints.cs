using Microsoft.EntityFrameworkCore;
using LocExpressApi.Shared;
using LocExpressApi.Shared.Models;

namespace LocExpressApi.Endpoints
{
    public static class RentalAdsEndpoints
    {
        public static RouteGroupBuilder MapRentalAdsEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (MyDbContext context) =>
                await context.RentalAds.ToListAsync());

            group.MapGet("/{id:int})", async (MyDbContext context, int id) =>
            {
                RentalAd ad = await context.RentalAds.FindAsync(id);
                return ad is not null ? Results.Ok(ad) : Results.NotFound();
            });

            return group;
        }
    }
}
