﻿using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Pokemons.Any())
        {
            var pokemons = new List<Pokemon>
            {
                new Pokemon
                {
                    PokedexNumber = 1,
                    Name = "Bulbasaur",
                    Weight = 69,
                    Height = 7,
                    Types = new List<string> { "Grass", "Poison" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/1.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 45 },
                        new PokemonStat { Name = "ATK", Value = 49 },
                        new PokemonStat { Name = "DEF", Value = 49 },
                        new PokemonStat { Name = "SAT", Value = 65 },
                        new PokemonStat { Name = "SDF", Value = 65 },
                        new PokemonStat { Name = "SPD", Value = 45 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 4,
                    Name = "Charmander",
                    Weight = 85,
                    Height = 6,
                    Types = new List<string> { "Fire" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/4.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 39 },
                        new PokemonStat { Name = "ATK", Value = 52 },
                        new PokemonStat { Name = "DEF", Value = 43 },
                        new PokemonStat { Name = "SAT", Value = 60 },
                        new PokemonStat { Name = "SDF", Value = 50 },
                        new PokemonStat { Name = "SPD", Value = 65 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 7,
                    Name = "Squirtle",
                    Weight = 90,
                    Height = 5,
                    Types = new List<string> { "Water" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/7.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 44 },
                        new PokemonStat { Name = "ATK", Value = 48 },
                        new PokemonStat { Name = "DEF", Value = 65 },
                        new PokemonStat { Name = "SAT", Value = 50 },
                        new PokemonStat { Name = "SDF", Value = 64 },
                        new PokemonStat { Name = "SPD", Value = 43 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 25,
                    Name = "Pikachu",
                    Weight = 60,
                    Height = 4,
                    Types = new List<string> { "Electric" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/25.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 35 },
                        new PokemonStat { Name = "ATK", Value = 55 },
                        new PokemonStat { Name = "DEF", Value = 40 },
                        new PokemonStat { Name = "SAT", Value = 50 },
                        new PokemonStat { Name = "SDF", Value = 50 },
                        new PokemonStat { Name = "SPD", Value = 90 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 39,
                    Name = "Jigglypuff",
                    Weight = 55,
                    Height = 5,
                    Types = new List<string> { "Normal", "Fairy" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/39.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 115 },
                        new PokemonStat { Name = "ATK", Value = 45 },
                        new PokemonStat { Name = "DEF", Value = 20 },
                        new PokemonStat { Name = "SAT", Value = 45 },
                        new PokemonStat { Name = "SDF", Value = 25 },
                        new PokemonStat { Name = "SPD", Value = 20 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 52,
                    Name = "Meowth",
                    Weight = 40,
                    Height = 4,
                    Types = new List<string> { "Normal" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/52.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 40 },
                        new PokemonStat { Name = "ATK", Value = 45 },
                        new PokemonStat { Name = "DEF", Value = 35 },
                        new PokemonStat { Name = "SAT", Value = 40 },
                        new PokemonStat { Name = "SDF", Value = 40 },
                        new PokemonStat { Name = "SPD", Value = 90 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 63,
                    Name = "Abra",
                    Weight = 25,
                    Height = 9,
                    Types = new List<string> { "Psychic" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/63.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 25 },
                        new PokemonStat { Name = "ATK", Value = 20 },
                        new PokemonStat { Name = "DEF", Value = 15 },
                        new PokemonStat { Name = "SAT", Value = 105 },
                        new PokemonStat { Name = "SDF", Value = 55 },
                        new PokemonStat { Name = "SPD", Value = 90 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 74,
                    Name = "Geodude",
                    Weight = 200,
                    Height = 10,
                    Types = new List<string> { "Rock", "Ground" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/74.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 40 },
                        new PokemonStat { Name = "ATK", Value = 80 },
                        new PokemonStat { Name = "DEF", Value = 100 },
                        new PokemonStat { Name = "SAT", Value = 30 },
                        new PokemonStat { Name = "SDF", Value = 30 },
                        new PokemonStat { Name = "SPD", Value = 20 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 77,
                    Name = "Ponyta",
                    Weight = 300,
                    Height = 10,
                    Types = new List<string> { "Fire" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/77.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 50 },
                        new PokemonStat { Name = "ATK", Value = 85 },
                        new PokemonStat { Name = "DEF", Value = 55 },
                        new PokemonStat { Name = "SAT", Value = 65 },
                        new PokemonStat { Name = "SDF", Value = 65 },
                        new PokemonStat { Name = "SPD", Value = 90 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 81,
                    Name = "Magnemite",
                    Weight = 60,
                    Height = 3,
                    Types = new List<string> { "Electric", "Steel" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/81.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 25 },
                        new PokemonStat { Name = "ATK", Value = 35 },
                        new PokemonStat { Name = "DEF", Value = 70 },
                        new PokemonStat { Name = "SAT", Value = 95 },
                        new PokemonStat { Name = "SDF", Value = 55 },
                        new PokemonStat { Name = "SPD", Value = 45 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 92,
                    Name = "Gastly",
                    Weight = 1,
                    Height = 13,
                    Types = new List<string> { "Ghost", "Poison" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/92.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 30 },
                        new PokemonStat { Name = "ATK", Value = 35 },
                        new PokemonStat { Name = "DEF", Value = 30 },
                        new PokemonStat { Name = "SAT", Value = 100 },
                        new PokemonStat { Name = "SDF", Value = 35 },
                        new PokemonStat { Name = "SPD", Value = 80 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 95,
                    Name = "Onix",
                    Weight = 2100,
                    Height = 88,
                    Types = new List<string> { "Rock", "Ground" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/95.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 35 },
                        new PokemonStat { Name = "ATK", Value = 45 },
                        new PokemonStat { Name = "DEF", Value = 160 },
                        new PokemonStat { Name = "SAT", Value = 30 },
                        new PokemonStat { Name = "SDF", Value = 45 },
                        new PokemonStat { Name = "SPD", Value = 70 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 104,
                    Name = "Cubone",
                    Weight = 65,
                    Height = 4,
                    Types = new List<string> { "Ground" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/104.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 50 },
                        new PokemonStat { Name = "ATK", Value = 50 },
                        new PokemonStat { Name = "DEF", Value = 95 },
                        new PokemonStat { Name = "SAT", Value = 40 },
                        new PokemonStat { Name = "SDF", Value = 50 },
                        new PokemonStat { Name = "SPD", Value = 35 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 116,
                    Name = "Horsea",
                    Weight = 80,
                    Height = 4,
                    Types = new List<string> { "Water" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/116.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 30 },
                        new PokemonStat { Name = "ATK", Value = 40 },
                        new PokemonStat { Name = "DEF", Value = 70 },
                        new PokemonStat { Name = "SAT", Value = 70 },
                        new PokemonStat { Name = "SDF", Value = 25 },
                        new PokemonStat { Name = "SPD", Value = 60 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 123,
                    Name = "Scyther",
                    Weight = 560,
                    Height = 15,
                    Types = new List<string> { "Bug", "Flying" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/123.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 70 },
                        new PokemonStat { Name = "ATK", Value = 110 },
                        new PokemonStat { Name = "DEF", Value = 80 },
                        new PokemonStat { Name = "SAT", Value = 55 },
                        new PokemonStat { Name = "SDF", Value = 80 },
                        new PokemonStat { Name = "SPD", Value = 105 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 129,
                    Name = "Magikarp",
                    Weight = 100,
                    Height = 9,
                    Types = new List<string> { "Water" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/129.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 20 },
                        new PokemonStat { Name = "ATK", Value = 10 },
                        new PokemonStat { Name = "DEF", Value = 55 },
                        new PokemonStat { Name = "SAT", Value = 15 },
                        new PokemonStat { Name = "SDF", Value = 20 },
                        new PokemonStat { Name = "SPD", Value = 80 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 133,
                    Name = "Eevee",
                    Weight = 65,
                    Height = 3,
                    Types = new List<string> { "Normal" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/133.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 55 },
                        new PokemonStat { Name = "ATK", Value = 55 },
                        new PokemonStat { Name = "DEF", Value = 50 },
                        new PokemonStat { Name = "SAT", Value = 45 },
                        new PokemonStat { Name = "SDF", Value = 65 },
                        new PokemonStat { Name = "SPD", Value = 55 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 143,
                    Name = "Snorlax",
                    Weight = 4600,
                    Height = 21,
                    Types = new List<string> { "Normal" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/143.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 160 },
                        new PokemonStat { Name = "ATK", Value = 110 },
                        new PokemonStat { Name = "DEF", Value = 65 },
                        new PokemonStat { Name = "SAT", Value = 65 },
                        new PokemonStat { Name = "SDF", Value = 110 },
                        new PokemonStat { Name = "SPD", Value = 30 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 147,
                    Name = "Dratini",
                    Weight = 33,
                    Height = 18,
                    Types = new List<string> { "Dragon" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/147.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 41 },
                        new PokemonStat { Name = "ATK", Value = 64 },
                        new PokemonStat { Name = "DEF", Value = 45 },
                        new PokemonStat { Name = "SAT", Value = 50 },
                        new PokemonStat { Name = "SDF", Value = 50 },
                        new PokemonStat { Name = "SPD", Value = 50 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 150,
                    Name = "Mewtwo",
                    Weight = 1220,
                    Height = 20,
                    Types = new List<string> { "Psychic" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/150.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 106 },
                        new PokemonStat { Name = "ATK", Value = 110 },
                        new PokemonStat { Name = "DEF", Value = 90 },
                        new PokemonStat { Name = "SAT", Value = 154 },
                        new PokemonStat { Name = "SDF", Value = 90 },
                        new PokemonStat { Name = "SPD", Value = 130 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 151,
                    Name = "Mew",
                    Weight = 40,
                    Height = 4,
                    Types = new List<string> { "Psychic" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/151.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 100 },
                        new PokemonStat { Name = "ATK", Value = 100 },
                        new PokemonStat { Name = "DEF", Value = 100 },
                        new PokemonStat { Name = "SAT", Value = 100 },
                        new PokemonStat { Name = "SDF", Value = 100 },
                        new PokemonStat { Name = "SPD", Value = 100 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 248,
                    Name = "Tyranitar",
                    Weight = 2020,
                    Height = 20,
                    Types = new List<string> { "Rock", "Dark" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/248.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 100 },
                        new PokemonStat { Name = "ATK", Value = 134 },
                        new PokemonStat { Name = "DEF", Value = 110 },
                        new PokemonStat { Name = "SAT", Value = 95 },
                        new PokemonStat { Name = "SDF", Value = 100 },
                        new PokemonStat { Name = "SPD", Value = 61 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 384,
                    Name = "Rayquaza",
                    Weight = 2065,
                    Height = 70,
                    Types = new List<string> { "Dragon", "Flying" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/384.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 105 },
                        new PokemonStat { Name = "ATK", Value = 150 },
                        new PokemonStat { Name = "DEF", Value = 90 },
                        new PokemonStat { Name = "SAT", Value = 150 },
                        new PokemonStat { Name = "SDF", Value = 90 },
                        new PokemonStat { Name = "SPD", Value = 95 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 212,
                    Name = "Scizor",
                    Weight = 1180,
                    Height = 18,
                    Types = new List<string> { "Bug", "Steel" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/212.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 70 },
                        new PokemonStat { Name = "ATK", Value = 130 },
                        new PokemonStat { Name = "DEF", Value = 100 },
                        new PokemonStat { Name = "SAT", Value = 55 },
                        new PokemonStat { Name = "SDF", Value = 80 },
                        new PokemonStat { Name = "SPD", Value = 65 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 330,
                    Name = "Flygon",
                    Weight = 820,
                    Height = 20,
                    Types = new List<string> { "Ground", "Dragon" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/330.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 80 },
                        new PokemonStat { Name = "ATK", Value = 100 },
                        new PokemonStat { Name = "DEF", Value = 80 },
                        new PokemonStat { Name = "SAT", Value = 80 },
                        new PokemonStat { Name = "SDF", Value = 80 },
                        new PokemonStat { Name = "SPD", Value = 100 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 445,
                    Name = "Garchomp",
                    Weight = 950,
                    Height = 19,
                    Types = new List<string> { "Dragon", "Ground" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/445.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 108 },
                        new PokemonStat { Name = "ATK", Value = 130 },
                        new PokemonStat { Name = "DEF", Value = 95 },
                        new PokemonStat { Name = "SAT", Value = 80 },
                        new PokemonStat { Name = "SDF", Value = 85 },
                        new PokemonStat { Name = "SPD", Value = 102 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 479,
                    Name = "Rotom",
                    Weight = 3,
                    Height = 3,
                    Types = new List<string> { "Electric", "Ghost" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/479.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 50 },
                        new PokemonStat { Name = "ATK", Value = 50 },
                        new PokemonStat { Name = "DEF", Value = 77 },
                        new PokemonStat { Name = "SAT", Value = 95 },
                        new PokemonStat { Name = "SDF", Value = 77 },
                        new PokemonStat { Name = "SPD", Value = 91 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 609,
                    Name = "Chandelure",
                    Weight = 343,
                    Height = 10,
                    Types = new List<string> { "Ghost", "Fire" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/609.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 60 },
                        new PokemonStat { Name = "ATK", Value = 55 },
                        new PokemonStat { Name = "DEF", Value = 90 },
                        new PokemonStat { Name = "SAT", Value = 145 },
                        new PokemonStat { Name = "SDF", Value = 90 },
                        new PokemonStat { Name = "SPD", Value = 80 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 257,
                    Name = "Blaziken",
                    Weight = 520,
                    Height = 19,
                    Types = new List<string> { "Fire", "Fighting" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/257.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 80 },
                        new PokemonStat { Name = "ATK", Value = 120 },
                        new PokemonStat { Name = "DEF", Value = 70 },
                        new PokemonStat { Name = "SAT", Value = 110 },
                        new PokemonStat { Name = "SDF", Value = 70 },
                        new PokemonStat { Name = "SPD", Value = 80 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 282,
                    Name = "Gardevoir",
                    Weight = 484,
                    Height = 16,
                    Types = new List<string> { "Psychic", "Fairy" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/282.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 68 },
                        new PokemonStat { Name = "ATK", Value = 65 },
                        new PokemonStat { Name = "DEF", Value = 65 },
                        new PokemonStat { Name = "SAT", Value = 125 },
                        new PokemonStat { Name = "SDF", Value = 115 },
                        new PokemonStat { Name = "SPD", Value = 80 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 350,
                    Name = "Milotic",
                    Weight = 1620,
                    Height = 62,
                    Types = new List<string> { "Water" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/350.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 95 },
                        new PokemonStat { Name = "ATK", Value = 60 },
                        new PokemonStat { Name = "DEF", Value = 79 },
                        new PokemonStat { Name = "SAT", Value = 100 },
                        new PokemonStat { Name = "SDF", Value = 125 },
                        new PokemonStat { Name = "SPD", Value = 81 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 448,
                    Name = "Lucario",
                    Weight = 540,
                    Height = 12,
                    Types = new List<string> { "Fighting", "Steel" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/448.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 70 },
                        new PokemonStat { Name = "ATK", Value = 110 },
                        new PokemonStat { Name = "DEF", Value = 70 },
                        new PokemonStat { Name = "SAT", Value = 115 },
                        new PokemonStat { Name = "SDF", Value = 70 },
                        new PokemonStat { Name = "SPD", Value = 90 }
                    }
                },
                new Pokemon
                {
                    PokedexNumber = 635,
                    Name = "Hydreigon",
                    Weight = 1600,
                    Height = 18,
                    Types = new List<string> { "Dark", "Dragon" },
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/dream-world/635.svg",
                    Stats = new List<PokemonStat>
                    {
                        new PokemonStat { Name = "HP", Value = 92 },
                        new PokemonStat { Name = "ATK", Value = 105 },
                        new PokemonStat { Name = "DEF", Value = 90 },
                        new PokemonStat { Name = "SAT", Value = 125 },
                        new PokemonStat { Name = "SDF", Value = 90 },
                        new PokemonStat { Name = "SPD", Value = 98 }
                    }
                },
            };

            _context.Pokemons.AddRange(pokemons);

            await _context.SaveChangesAsync();
        }
    }
}
