public class CounterService: ICounterService
{
    public int Count { get; set; }
}

public interface ICounterService
{
    public int Count { get; set; }
}