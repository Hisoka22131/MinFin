﻿using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MinFin.DB.Domain;
using MinFin.DB.Enums;

namespace MinFin.DB.Context.Seed;

public static class UserSeeder
{
    internal static void SeedUsers(this ModelBuilder modelBuilder)
    {
        using var hmac = new HMACSHA512();
        var passwordKey = hmac.Key;
        var passwordHash = hmac.ComputeHash("1234"u8.ToArray());

        var users = new List<User>()
        {
            new()
            {
                Id = 1,
                FirstName = "Dmitry",
                Surname = "Kambur",
                MiddleName = "Sergeevich",
                Email = "dima.Kambur.2001@mail.ru",
                PassportSeries = "12321312321",
                PassportType = PassportType.Domestic,
                PassportNumber = "123123123",
                SignType = SignType.Resident,
                Password = passwordHash,
                PasswordKey = passwordKey,
                CreateDt = DateTime.Now,
                UpdateDt = DateTime.Now
            },
            new()
            {
                Id = 2,
                FirstName = "Vladislav",
                Surname = "Kirilenko",
                MiddleName = "",
                Email = "what.is.love.kirilenko@mail.ru",
                PassportSeries = "12321312321",
                PassportType = PassportType.InternationalPassport,
                PassportNumber = "123123123",
                SignType = SignType.NotResident,
                Password = passwordHash,
                PasswordKey = passwordKey,
                CreateDt = DateTime.Now,
                UpdateDt = DateTime.Now
            }
        };

        modelBuilder.Entity<User>().HasData(users);
    }
}