using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiTemplate.Models;

namespace ApiTemplate.Infrastructure
{
    public class DbInitializer
    {
        public async void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
            {
                return; //DB already contains data
            }

            var Items = new Item[]
            {
                new Item() {Title = "Test Item 1", Description = "Description of Test Item 1"},
                new Item() {Title = "Test Item 2", Description = "Description of Test Item 2"},
                new Item() {Title = "Test Item 3", Description = "Description of Test Item 3"}
            };

            foreach (var item in Items)
            {
                context.Add(item);
            }

            await context.SaveChangesAsync();
        }
    }
}
