public class CounterService: ICounterService
{
    public int Count { get; set; } = 0;
}

public interface ICounterService
{
    public int Count { get; set; }
}