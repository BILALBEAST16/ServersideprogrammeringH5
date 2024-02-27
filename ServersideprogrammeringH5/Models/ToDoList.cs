using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServersideprogrammeringH5.Models;

public partial class ToDoList
{
    [Key]
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Item { get; set; } = null!;
}
