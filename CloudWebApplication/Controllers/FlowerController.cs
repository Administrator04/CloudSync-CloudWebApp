using CloudWebApplication.Models; // for class collect data to object
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // for database linkage
using CloudWebApplication.Data;
using SQLitePCL;
using System.Runtime.CompilerServices; // for database location
namespace CloudWebApplication.Controllers
{
    public class FlowerController : Controller
    {

        private readonly CloudWebApplicationContext context; // create a member to link with DB

        // use constructor
        public FlowerController(CloudWebApplicationContext context) //setup the DB connections
        {
            this.context = context;
        }
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "Customer")]
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            List<Flower> flowers = new List<Flower>();
            flowers = await context.Flower.ToListAsync();
            return View(flowers); // return back to frontend for display
        }

        public IActionResult AddData() //loading the form but not receiving
        {
            return View();
        }

        [HttpPost] // recive values from input form
        [AutoValidateAntiforgeryToken] //cross site attack
        public async Task<IActionResult> AddData(Flower flower)
        {
            if (ModelState.IsValid)
            {
                context.Add(flower); // put into the object of DB
                await context.SaveChangesAsync(); // commit sentence
                return RedirectToAction(nameof(Index)); // if form no isse, direct inset and trasnfer to index page
            }
            return View(flower);
        }
        public async Task<IActionResult> DeleteData (int ? fid)
        {
            if (fid == null)
            {
                return BadRequest("Error in retreiveing flower ID");
            }
            var flower = await context.Flower.FindAsync(fid);

            if (flower == null)
            {
                return BadRequest("Error: Data not found!");
            }

            // delete the item from localhost db
            context.Flower.Remove(flower);
            await context.SaveChangesAsync();

            // return to the table
            return RedirectToAction("Index", "Flower");
        }

        public async Task<IActionResult> EditData (int ? fid)
        { 
        if (fid == null)
            {
                return BadRequest("Error in retreiveing flower ID");
            }
            var flower = await context.Flower.FindAsync(fid);

            if (flower == null)
            {
                return BadRequest("Error: Data not found!");
            }
            return View(flower);
        }
    }
}
