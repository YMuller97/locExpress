using LocExpressApi.Shared;
using LocExpressApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LocExpressApi.Endpoints
{
    public static class UserEndpoints
    {
        public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
        {
            /// <summary>
            /// GET endpoint <c>/api/users/</c> returns all users
            /// </summary>
            group.MapGet("/", async (MyDbContext context) =>
            {
                List<User> users = await context.Users.ToListAsync();
                return users is not null ? Results.Ok(users) : Results.NotFound();
            });


            ///<summary>
            /// GET endpoint <c>/api/users/id</c> returns the user with the specified id
            /// </summary>
            group.MapGet("/{id:int}", async (MyDbContext context, int id) =>
            {
                User user = await context.Users.FindAsync(id);
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });

            ///<summary>
            /// GET endpoint <c>/api/users/</c> returns the user with the specified email
            /// </summary>
            group.MapGet("/byemail", async (MyDbContext context, string email) =>
            {
                User user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });

            return group;
        }
    }
}
