using LocExpressApi.Shared;
using LocExpressApi.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Collections.Generic;

namespace LocExpressApi.Endpoints
{
    public static class RentalAdsEndpoints
    {
        public static RouteGroupBuilder MapRentalAdsEndpoints(this RouteGroupBuilder group)
        {

            // ------------------------------------ GET endpoints ------------------------------------

            /// <summary>
            /// GET endpoint <c>/api/ads/</c> returns all rental ads
            /// </summary>
            group.MapGet("/", async (MyDbContext context) =>
            {
                List<RentalAd> list = await context.RentalAds.ToListAsync();
                return list is not null ? Results.Ok(list) : Results.NotFound();
            });


            ///<summary>
            /// GET endpoint <c>/api/ads/id</c> returns the rental ad with the provided id
            /// </summary>
            group.MapGet("/{id:int}", async (MyDbContext context, int id) =>
            {
                RentalAd ad = await context.RentalAds.FindAsync(id);
                return ad is not null ? Results.Ok(ad) : Results.NotFound();
            });


            ///<summary>
            /// GET endpoint <c>/api/ads/byowner/id</c> returns all the rental ads owned by the user with the specified id
            /// </summary>
            group.MapGet("/byowner/{id:int}", async (MyDbContext context, int id) =>
            {
                List<RentalAd> list = await context.RentalAds.Where(ad => ad.OwnerId == id).ToListAsync();
                return list is not null ? Results.Ok(list) : Results.NotFound();
            });

            ///<summary>
            /// GET endpoint <c>/api/ads/pictures</c> returns all the pictures
            /// </summary>
            group.MapGet("/pictures", async (MyDbContext context) =>
            {
                List<Picture> pictures = await context.Pictures.ToListAsync();
                return pictures is not null ? Results.Ok(pictures) : Results.NotFound();
            });


            ///<summary>
            /// GET endpoint <c>/api/ads/id/pictures</c> returns all the pictures belonging to the rental ad with the specified id
            /// </summary>
            group.MapGet("/{id:int}/pictures", async (MyDbContext context, int id) =>
            {
                List<Picture> pictures = await context.Pictures.Where(pic => pic.RentalAdId == id).ToListAsync();
                return pictures is not null ? Results.Ok(pictures) : Results.NotFound();
            });


            ///<summary>
            /// GET endpoint <c>/api/ads/id/views</c>
            /// </summary>
            //group.MapGet("/{id:int}/views", async (MyDbContext context, int id) =>
            //{
            //    RentalAd ad = await context.RentalAds.FindAsync(id);
            //    if (ad != null)
            //    {
            //        if (!ad.ViewsCounter.HasValue)
            //            return 0;
            //        else
            //            return (int)ad.ViewsCounter;
            //    }
            //    else
            //    {
            //        throw new Exception("Erreur annonce introuvable");
            //    }
            //});


            ///<summary>
            /// GET endpoint <c>/api/ads/id/owner</c> return the User who owns the rental ad with the specified id
            /// </summary>
            group.MapGet("/{id:int}/owner", async (MyDbContext context, int id) =>
            {
                RentalAd ad = await context.RentalAds.FindAsync(id);
                if (ad == null)
                {
                    return Results.NotFound();
                }

                User? owner = await context.Users.FindAsync(ad.OwnerId);
                if (owner == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    if (owner.FirstName == null)
                        owner.FirstName = "";

                    if (owner.Name == null)
                        owner.Name = "";

                    owner.OwnedRentalAds = null;
                }

                    return Results.Ok(owner);
            });

            


            // ------------------------------------ POST Endpoints ------------------------------------
            
            ///<summary>
            /// POST endpoint <c>api/ads/</c> creates a new rental ad in the database
            /// </summary>
            group.MapPost("/", async (MyDbContext context, RentalAd ad) =>
            {
                if (ad == null)
                {
                    return Results.BadRequest("");
                }

                await context.RentalAds.AddAsync(ad);
                await context.SaveChangesAsync();

                return Results.Ok(context.RentalAds.OrderBy(ad => ad.Id).Last());

            });


            // ------------------------------------ PUT / PATCH Endpoints ------------------------------------
            ///<summary>
            /// PUT endpoint <c>api/ads/</c> updates an existing rental ad
            /// </summary>
            group.MapPut("/", async (MyDbContext context, RentalAd updatedAd) =>
            {
                try
                {
                    context.RentalAds.Update(updatedAd);
                    await context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

                return Results.Ok(updatedAd);
            });



            // ------------------------------------ DELETE Endpoints ------------------------------------
            ///<summary>
            /// DELETE Endpoint <c>/api/ads/id</c> deletes the rental ad with the specified id if it exists, as well as its pictures 
            /// </summary>
            group.MapDelete("/{id:int}", async (MyDbContext context, int id) =>
            {
                RentalAd ad = await context.RentalAds.FindAsync(id);
                string sourceDir = Directory.GetCurrentDirectory() + "/Medias";
                if (ad != null)
                {
                    context.RentalAds.Remove(ad); // Supprime l'annonce si elle existe
                    await context.SaveChangesAsync();

                    string picturesDirectory = $"{sourceDir}/images/ad_{id}_pictures";
                    try
                    {
                        Directory.Delete(picturesDirectory, true);
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine("Directory not found");
                    }
                    await context.SaveChangesAsync(); // Sauvegarde les changements
                }

                return Results.Ok("Rental ad deleted");
            });




            return group;
        }
    }
}
