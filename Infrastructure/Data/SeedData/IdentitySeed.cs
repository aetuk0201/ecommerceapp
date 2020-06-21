using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.SeedData
{
    public class IdentitySeed
    {
        public static async Task SeedUsersData(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {

                var user = new AppUser
                {
                    FirstName = "Truth",
                    LastName = "Unlimited",
                    DisplayName = "Truth",
                    UserName = "truth",
                    Email = "truth@test.com",
                    Addresses = new List<Address>()
                        {
                            new Address()
                            {
                                AddressLine1 = "10th Street",
                                City = "New York",
                                State = "NY",
                                ZipCode = "10002"
                            },
                            new Address()
                            {
                                AddressLine1 = "101 Houston Street",
                                City = "Houston",
                                State = "TX",
                                ZipCode = "77227"
                            }
                        }

                };

                await userManager.CreateAsync(user, "Umantom0520$");
            };
        }
    }
}