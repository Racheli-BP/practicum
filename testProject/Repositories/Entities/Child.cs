using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;

public partial class Child
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Tz { get; set; }

    public DateTime? BirthDate { get; set; }

    [ForeignKey("Parent")]
    public int? ParentId { get; set; }

    public virtual Person? Parent { get; set; }
}
