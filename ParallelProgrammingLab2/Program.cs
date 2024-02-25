namespace ParallelProgrammingLab2;

internal static class Program
{
    private static void Main()
    {
        var subscribers = InputFileReader.Read("input.txt", System.Text.Encoding.UTF8);
        
        var phonebook = new Phonebook(subscribers.ToArray());
        
        
    }
}