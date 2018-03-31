using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Lake : IEnumerable<int>
{
    private List<int> data;

    public Lake(ICollection<int> data)
    {
        this.data = new List<int>(data);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.data[i];
            }
        }

        for (int i = this.data.Count-1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return this.data[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
