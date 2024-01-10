using Cocona;
using CoconaDemo;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

/*
    Co je to Cocona?
        - framework pro tvorbu CLI aplikací
        - distribuován ve formě NuGet balíčku
        - Cocona Lite vs. Full

    K čemu nám bude?
        - řeší problematiku předávání argumentů do konzolových aplikací
        - zobrazování nápovědy pro příkazy v konzolové aplikaci
        - umožňuje pomocí Microsoft.Extensions.DependencyInjection implementovat v konzolové aplikaci DependencyInjection
        - umožňuje konfiguraci logování
        - umožňuje parsování konfifuračního souboru (appsettings.json)
        - umožňuje lokalizování popisků příkazů konzolové aplikace
*/

// BASIC EXAMPLE 1

// CoconaApp.Run((string name, string path) =>
// {
//     Console.WriteLine(name);
//         Console.WriteLine(path);

// });







// BASIC EXAMPLE 2

// CoconaApp.Run(([Argument]string projectName, [Option(Description = "This is very required!!")]string requiredOption, [Option]string? nullableOption) =>
// {
//     Console.WriteLine(projectName);
//     Console.WriteLine(requiredOption);
//     Console.WriteLine(nullableOption);
// });








// ADVANCED EXAMPLE 1

var builder = CoconaApp.CreateBuilder(args, (options) =>
{
    //options.EnableConvertArgumentNameToLowerCase = true;
});

//builder.Configuration.AddJsonFile() // Ani není tento řádek potřeba, pokud se json nejmenuje nějak nestandardně
// builder.Logging.AddFilter(); // Opět může být klasicky konfigurováno přes appsettings.json
builder.Services.AddSingleton<IProcgenService, ProcgenService>();

var app = builder.Build();

// // BASIC COMMAND
// app.AddCommand("procgen", async ([Option] string path, IProcgenService procgenService)
//     => await procgenService.GenereteSourceCodeAsync(path));

// // BASIC COMMAND WITH VALIDATION
// app.AddCommand("procgen", async ([Option][Range(0, 2)] int numberOfSometing, IProcgenService procgenService)
//     => await procgenService.GenereteSourceCodeAsync(numberOfSometing.ToString()));

// COMMANDER CLASS - ZMÍNIT RETUNR KÓDY
app.AddCommands<ProcgenCommander>();

await app.RunAsync();