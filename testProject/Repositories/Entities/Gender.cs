using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Gender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();
}
