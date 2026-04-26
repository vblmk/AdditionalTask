using System.Collections;

namespace AdditionalTask;
using System.Linq;

public class Inventory<T> : IEnumerable<T> 
    where T: Item
{
    private List<T> _inv = new List<T>();
    public double WeightLimit { get; set; }
    public double CurrentWeight { get; set; }

    public Inventory(double weightLimit)
    {
        WeightLimit = weightLimit;
    }

    public void Add(T item)
    {
        if (CurrentWeight + item.Weight <= WeightLimit)
        {
            _inv.Add(item);
            CurrentWeight += item.Weight;

            Console.WriteLine($"item {item.Name} added to inventory");
        }
        else
        {
            Console.WriteLine($"too much weight! remove {CurrentWeight + item.Weight - WeightLimit}kg");
        }
    }

    public void Remove(T item)
    {
        if (_inv.Contains(item))
        {
            _inv.Remove(item);
            CurrentWeight -= item.Weight;
        }
        
        else
            Console.WriteLine("no such item in inventory");
    }

    public Item? GetByName(string name)
    {
        return _inv.FirstOrDefault(n => n.Name == name);
    }

    public void SortByRarity()
    {
        _inv.Sort();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _inv.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    
}