using System;
using System.Collections.Generic;

namespace PhamMinhTuan_231230946_Lan6.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
