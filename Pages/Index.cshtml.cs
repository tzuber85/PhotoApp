using PhotoApp.Data;
using PhotoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace PhotoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PhotoDbContext Context;

        public IndexModel(PhotoDbContext context)
        {
            Context = context;
        }

        public ImmutableArray<Photo> Photos { get; private set; }

        public async Task<IActionResult> OnGet()
        {
            Photos = (await Context.Photos.AsNoTracking()
                .ToArrayAsync())
                .ToImmutableArray();

            return Page();
        }
    }
}
