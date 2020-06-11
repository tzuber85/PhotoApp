using PhotoApp.Data;
using PhotoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PhotoApp.Pages.Photos
{
    public class DetailsModel : PageModel
    {
        private readonly PhotoDbContext Context;

        public DetailsModel(PhotoDbContext context)
        {
            Context = context;
        }

        public Photo Photo { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Photo = await Context.Photos.AsNoTracking()
                .FirstOrDefaultAsync(photo => photo.PhotoId == id);

            if (Photo == null)
                return NotFound();
            return Page();
        }
    }
}
