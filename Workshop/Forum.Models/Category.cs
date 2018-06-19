using System.Collections;
using System.Collections.Generic;

public class Category
{
    public Category(int id, string name, IEnumerable<int> posts)
    {
        Id = id;
        Name = name;
        PostIds = new List<int>(posts);
    }

    public int Id { get; set; }

    public string  Name { get; set; }

    public ICollection<int> PostIds { get; set; }

}
