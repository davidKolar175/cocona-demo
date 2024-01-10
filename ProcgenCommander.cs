using Cocona;

namespace CoconaDemo;

public class ProcgenCommander
{
    private readonly IProcgenService _procgenService;

    public ProcgenCommander(IProcgenService procgenService)
    {
        _procgenService = procgenService;
    }

    [Command("generate")]
    public async Task<int> GenerateCode(string path)
    {
        return await _procgenService.GenereteSourceCodeAsync(path);
    }

    [Command("validate")] // (--try-to-repair=<false>, pokud výchozí hodnota = true)...
    public async Task ValidateCode([Option(Description = "Path to the source code.")]string path, [Option(Description = "Indicates whether Procgen should try to repair found mistakes.")]bool tryToRepair = true) 
    {
        await _procgenService.ValidateSourceCodeAsync(path, tryToRepair);
    }
}