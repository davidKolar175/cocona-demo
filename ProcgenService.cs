using Microsoft.Extensions.Configuration;

namespace CoconaDemo;

public class ProcgenService : IProcgenService
{
    private readonly string _cSharpVersion;

    public ProcgenService(IConfiguration configuration)
    {
        _cSharpVersion = configuration.GetValue<string>("CSharpVersion");
    }

    public async Task<int> GenereteSourceCodeAsync(string path)
    {
        Console.WriteLine($"Procgen is generating with C# version {_cSharpVersion}...");
        await Task.Delay(5000);
        Console.WriteLine($"Procgen in '{path}' finished!");

        return 2; // Cocona podporuje Return kódy
    }

    public async Task ValidateSourceCodeAsync(string path, bool tryToRepair)
    {
        Console.WriteLine($"Procgen is generating with C# version {_cSharpVersion}...");

        if (tryToRepair)
            Console.WriteLine($"Repairing source code...");

        await Task.Delay(5000);
        Console.WriteLine($"Procgen in '{path}' finished!");
    }
}