// Pages/Summary.cshtml.cs
using DynamicTableExample.Models;
using DynamicTableExample.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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
        public string SelectedName { get; set; }
        public string SortColumn { get; set; }
        public bool Ascending { get; set; }
        public List<SelectListItem> NameOptions { get; set; }

        public void OnGet(string filter, string selectedName, string sortColumn, bool ascending = true)
        {
            CurrentFilter = filter;
            SelectedName = selectedName;
            SortColumn = sortColumn ?? "Name";
            Ascending = ascending;

            Items = _tableService.GetItems(filter, sortColumn, ascending);

            NameOptions = _tableService.GetItems()
                                        .Select(x => x.Name)
                                        .Distinct()
                                        .Select(x => new SelectListItem { Value = x, Text = x })
                                        .ToList();

            if (!string.IsNullOrEmpty(selectedName))
            {
                Items = Items.Where(x => x.Name == selectedName).ToList();
            }
        }
    }
}
