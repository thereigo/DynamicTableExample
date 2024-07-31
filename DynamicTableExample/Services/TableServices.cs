// Services/TableService.cs
using DynamicTableExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace DynamicTableExample.Services
{
    public class TableService
    {
        private static List<TableItem> _items = new List<TableItem>
        {
            new TableItem { Id = 1, Name = "Alice", Column2 = "Data1", Column3 = "Data2", Column4 = "Data3", Column5 = "Data4", Column6 = "Data5", Column7 = "Data6", Column8 = "Data7" },
            new TableItem { Id = 2, Name = "Bob", Column2 = "Data8", Column3 = "Data9", Column4 = "Data10", Column5 = "Data11", Column6 = "Data12", Column7 = "Data13", Column8 = "Data14" },
            new TableItem { Id = 3, Name = "Charlie", Column2 = "Data15", Column3 = "Data16", Column4 = "Data17", Column5 = "Data18", Column6 = "Data19", Column7 = "Data20", Column8 = "Data21" },
            new TableItem { Id = 4, Name = "David", Column2 = "Data22", Column3 = "Data23", Column4 = "Data24", Column5 = "Data25", Column6 = "Data26", Column7 = "Data27", Column8 = "Data28" },
            new TableItem { Id = 5, Name = "Eve", Column2 = "Data29", Column3 = "Data30", Column4 = "Data31", Column5 = "Data32", Column6 = "Data33", Column7 = "Data34", Column8 = "Data35" },
            new TableItem { Id = 6, Name = "Frank", Column2 = "Data36", Column3 = "Data37", Column4 = "Data38", Column5 = "Data39", Column6 = "Data40", Column7 = "Data41", Column8 = "Data42" },
            new TableItem { Id = 7, Name = "Grace", Column2 = "Data43", Column3 = "Data44", Column4 = "Data45", Column5 = "Data46", Column6 = "Data47", Column7 = "Data48", Column8 = "Data49" },
            new TableItem { Id = 8, Name = "Hank", Column2 = "Data50", Column3 = "Data51", Column4 = "Data52", Column5 = "Data53", Column6 = "Data54", Column7 = "Data55", Column8 = "Data56" },
            new TableItem { Id = 9, Name = "Ivy", Column2 = "Data57", Column3 = "Data58", Column4 = "Data59", Column5 = "Data60", Column6 = "Data61", Column7 = "Data62", Column8 = "Data63" },
            new TableItem { Id = 10, Name = "Jack", Column2 = "Data64", Column3 = "Data65", Column4 = "Data66", Column5 = "Data67", Column6 = "Data68", Column7 = "Data69", Column8 = "Data70" }
            // Add more items if needed
        };

        public List<TableItem> GetItems(string filter = "", string sortColumn = "Name", bool ascending = true)
        {
            var items = _items.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                items = items.Where(x => x.Name.Contains(filter));
            }

            items = sortColumn switch
            {
                "Name" => ascending ? items.OrderBy(x => x.Name) : items.OrderByDescending(x => x.Name),
                "Column2" => ascending ? items.OrderBy(x => x.Column2) : items.OrderByDescending(x => x.Column2),
                "Column3" => ascending ? items.OrderBy(x => x.Column3) : items.OrderByDescending(x => x.Column3),
                "Column4" => ascending ? items.OrderBy(x => x.Column4) : items.OrderByDescending(x => x.Column4),
                "Column5" => ascending ? items.OrderBy(x => x.Column5) : items.OrderByDescending(x => x.Column5),
                "Column6" => ascending ? items.OrderBy(x => x.Column6) : items.OrderByDescending(x => x.Column6),
                "Column7" => ascending ? items.OrderBy(x => x.Column7) : items.OrderByDescending(x => x.Column7),
                "Column8" => ascending ? items.OrderBy(x => x.Column8) : items.OrderByDescending(x => x.Column8),
                _ => items
            };

            return items.ToList();
        }
    }
}
