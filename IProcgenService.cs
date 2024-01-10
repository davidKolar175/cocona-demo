namespace CoconaDemo;

public interface IProcgenService
{
    public Task<int> GenereteSourceCodeAsync(string path);

    public Task ValidateSourceCodeAsync(string path, bool tryToRepair);
}