namespace ParallelProgrammingLab2;

public class Phonebook
{
    public Phonebook(TelephoneSubscriber[] subscribers)
    {
        _subscribers = subscribers;
    }

    public IEnumerable<TelephoneSubscriber> FindSubscribersByLastName(string lastName)
    {
        var subscribers = new List<TelephoneSubscriber>();

        while (_subscriberIndex < _subscribers.Length)
        {
            var subscriber = GetSubscriber();
            
            if (subscriber.LastName.Contains(lastName))
                subscribers.Add(subscriber);
        }

        return subscribers;
    }

    private TelephoneSubscriber GetSubscriber()
    {
        lock (_subscriberBlocker)
        {
            var result = _subscribers[_subscriberIndex];
            
            _subscriberIndex++;
            
            return result;
        }
    }
    
    private readonly TelephoneSubscriber[] _subscribers;

    private int _subscriberIndex;

    private readonly object _subscriberBlocker = new();
}