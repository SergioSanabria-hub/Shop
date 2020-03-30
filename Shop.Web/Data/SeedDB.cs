namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.UserHelper = userHelper;
            this.random = new Random();
        }

        public IUserHelper UserHelper { get; }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.UserHelper.GetUserByEmailAsync("se_sanabria@hotmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Sergio",
                    LastName = "Sanabria",
                    Email = "se_sanabria@hotmail.com",
                    UserName = "se_sanabria@hotmail.com",
                    PhoneNumber = "3777490493"
                };

                var result = await this.UserHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone10", user);
                this.AddProduct("Samsung Galaxy", user);
                this.AddProduct("Motorola GP", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
