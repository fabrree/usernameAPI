using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UsernameApi.Models;

public class SeedData
{
    public static async void Seeding(IApplicationBuilder app)
    {
        DbContext context = app.ApplicationServices.CreateScope()
            .ServiceProvider
            .GetRequiredService<DbContext>();

        context.Database.EnsureCreated();

        if (!context.ApiKeys.Any())
        {
            var api1 = new ApiKey
            {
                Code = 521204028
            };
            var api2 = new ApiKey
            {
                Code = 695979830
            };
            var api3 = new ApiKey
            {
                Code = 695979830
            };
            var api4 = new ApiKey
            {
                Code = 954974805
            };
            var api5 = new ApiKey
            {
                Code = 582630516
            };
            var api6 = new ApiKey
            {
                Code = 454146982
            };
            var api7 = new ApiKey
            {
                Code = 742378574
            };
            var api8 = new ApiKey
            {
                Code = 739415408
            };
            var api9 = new ApiKey
            {
                Code = 572964978
            };
            var api10 = new ApiKey
            {
                Code = 014000480
            };
            var api11 = new ApiKey
            {
                Code = 591886826
            };
            var api12 = new ApiKey
            {
                Code = 503638598
            };
            var api13 = new ApiKey
            {
                Code = 840960349
            };
            var api14 = new ApiKey
            {
                Code = 136969340
            };
            var api15 = new ApiKey
            {
                Code = 309637512
            };
            var api16 = new ApiKey
            {
                Code = 861516375
            };
            var api17 = new ApiKey
            {
                Code = 621736746
            };
            var api18 = new ApiKey
            {
                Code = 383147799
            };
            var api19 = new ApiKey
            {
                Code = 386004397
            };
            var api20 = new ApiKey
            {
                Code = 943743485
            };
            var api21 = new ApiKey
            {
                Code = 959757302
            };
            var api22 = new ApiKey
            {
                Code = 550836544
            };
            var api23 = new ApiKey
            {
                Code = 831408704
            };
            var api24 = new ApiKey
            {
                Code = 539591464
            };
            var api25 = new ApiKey
            {
                Code = 953151404
            };
            var api26 = new ApiKey
            {
                Code = 113208341
            };
            var api27 = new ApiKey
            {
                Code = 357626737
            };
            var api28 = new ApiKey
            {
                Code = 314469798
            };
            var api29 = new ApiKey
            {
                Code = 540812368
            };
            var api30 = new ApiKey
            {
                Code = 422530665
            };

            context.ApiKeys.AddRange(api1, api2, api3, api4, api5, api6, api7, api8, api9, api9, api10, api11, api12, api13, api14, api15, api16, api17, api18, api19, api20, api21, api22, api23, api24, api25, api26, api27, api28, api29, api30);
            await context.SaveChangesAsync();
            System.Console.WriteLine("Seeding data done...");
        }
    }
}