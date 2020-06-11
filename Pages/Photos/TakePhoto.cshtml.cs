using PhotoApp.Data;
using PhotoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace PhotoApp.Pages.Photos
{
    public class TakePhotoModel : PageModel
    {
        private readonly PhotoDbContext Context;

        public TakePhotoModel(PhotoDbContext context)
        {
            Context = context;
        }

        [BindProperty]
        public Photo Photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var newPhoto = new Photo();

            if (await TryUpdateModelAsync(
                newPhoto,
                nameof(Photo),   // Prefix for form value.
                s => s.Title, s => s.Description, s => s.EncodedData))
            {
                Context.Photos.Add(newPhoto);
                await Context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}