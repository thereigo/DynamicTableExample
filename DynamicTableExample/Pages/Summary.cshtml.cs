// Pages/Summary.cshtml.cs
using DynamicTableExample.Models;
using DynamicTableExample.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DynamicTableExample.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly TableService _tableService;

        public SummaryModel(TableService tableService)
        {
            _tableService = tableService;
        }

        public List<TableItem> Items { get; set; }
        public string CurrentFilter { get; set; }
        public string SortColumn { get; set; }
        public bool Ascending { get; set; }

        public void OnGet(string filter, string sortColumn, bool ascending = true)
        {
            CurrentFilter = filter;
            SortColumn = sortColumn ?? "Name";
            Ascending = ascending;

            Items = _tableService.GetItems(filter, SortColumn, Ascending);
        }
    }
}
