﻿using GroupAssignment2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupAssignment2.DAL;

public static class DBInit
{
    public static void Seed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        HousingDbContext context = serviceScope.ServiceProvider.GetRequiredService<HousingDbContext>();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}
