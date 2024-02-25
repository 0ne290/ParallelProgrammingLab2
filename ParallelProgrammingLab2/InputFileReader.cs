namespace ParallelProgrammingLab2;

public class InputFileReader
{
    public static IEnumerable<TelephoneSubscriber> Read(string path, System.Text.Encoding encoding)
    {
        var reader = new StreamReader(path, encoding);

        var subscribers = new List<TelephoneSubscriber>();

        while (reader.ReadLine() is { } serializedSubscriber)
        {
            var lexemes = serializedSubscriber.Split("; ");

            var deserializedSubscriber = new TelephoneSubscriber
            {
                FirstName = lexemes[1], LastName = lexemes[0], Patronymic = lexemes[2], PhoneNumber = lexemes[3],
                Address = lexemes[4]
            };
            
            subscribers.Add(deserializedSubscriber);
        }
        
        reader.Dispose();

        return subscribers;
    }
}