using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P230_Pronia.DAL;
using P230_Pronia.Entities;

namespace P230_Pronia.Controllers
{
    public class ShopController:Controller
    {
        private readonly ProniaDbContext _context;

        public ShopController(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Plant> plants = _context.Plants.Include(p=>p.PlantImages).ToList();
            return View(plants);
        }

        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Plant? plant =_context.Plants.Include(p=>p.PlantCategories).ThenInclude(pc=>pc.Category)
                .Include(p=>p.PlantTags).ThenInclude(pt=>pt.Tag)
                .Include(p=>p.PlantDeliveryInformation)
                .Include(p=>p.PlantImages)
                .SingleOrDefault(p=>p.Id==id);
            return View(plant);
        }
    }
}
