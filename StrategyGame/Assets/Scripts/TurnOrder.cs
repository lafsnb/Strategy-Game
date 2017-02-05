using System.Collections.Generic;

public class TurnOrder  {
    private SortedList<int, Character> units;

    public TurnOrder(IList<Character> party, IList<Character> enemies)
    {
        int count = 0;
        units = new SortedList<int, Character>();
        foreach(Character c in party)
        {
            units.Add(count++, c);
        }
        foreach(Character c in enemies)
        {
            units.Add(count++, c);
        }
    }

    public Character getNext()
    {
        return units.Values[0];
    }

    public Character getNext(Character current)
    {
        return units[units.IndexOfValue(current) + 1];
    }

}
