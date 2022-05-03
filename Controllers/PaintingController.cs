#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanGoghAPI.Models;

namespace VanGoghAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        private readonly VanGoghDBContext _context;

        public PaintingController(VanGoghDBContext context)
        {
            _context = context;
        }

        // GET: api/Painting
        [HttpGet]
        public async Task<ActionResult<Response>> GetPaintings()
        {
            // Declare response
            var response = new Response();
            try 
            {
                var paint_list = await _context.Painting.ToListAsync();
                var paint_info_list = await _context.PaintingInfo.ToListAsync();

                // Success
                response.statusCode = 200;
                response.statusDescription = "Successful GET on all paintings!";
                response.paintings = paint_list;

                return response;
            }
            catch(Exception)
            {
                // Failed GET
                response.statusCode = 404;
                response.statusDescription = "No paintings found.";

                return response;
            }
            
        }

        // GET: api/Painting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetPainting(int id)
        {
            // Declare response
            var response = new Response();
            try
            {
                var painting = await _context.Painting.FindAsync(id);
                var paint_info_list = await _context.PaintingInfo.ToListAsync();

                // If painting does not exist
                if (painting == null)
                {
                    throw new Exception();
                }

                // Success
                response.statusCode = 200;
                response.statusDescription = "Successful GET on painting #" + id + "!";
                response.paintings = new List<Painting>();
                response.paintings.Add(painting);

                return response;
            }
            catch (Exception)
            {
                // Failed attempt
                response.statusCode = 404;
                response.statusDescription = "Painting #" + id + " not found.";

                return response;
            }
        }

        // PUT: api/Painting/5
        // Update painting
        [HttpPut("{id}")]
        public async Task<Response> PutPainting(int id, Painting painting)
        {
            // Declare response
            var response = new Response();

            // Failed, provided ID's do not match
            if (id != painting.PaintingId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad request. Parameter painting ID does not match PaintingID.";
                return response;
            }

            _context.Entry(painting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                //Success
                response.statusCode = 200;
                response.statusDescription = "Update successful on painting #" + id + "!";
                response.paintings = new List<Painting>();
                response.paintings.Add(painting);

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Painting with provided ID does not exist
                if (!PaintingExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Painting ID not found.";
                    return response;
                }
                // Misc. failure
                else
                {
                    response.statusCode = 400;
                    response.statusDescription = "Bad request. Try again.";
                    return response;
                }
            }
        }

        // POST: api/Painting
        // Create painting object
        [HttpPost]
        public async Task<ActionResult<Response>> PostPainting(Painting painting)
        {
            // Declare response
            var response = new Response();

            try
            {
                _context.Painting.Add(painting);
                await _context.SaveChangesAsync();

                CreatedAtAction("GetPainting", new { id = painting.PaintingId }, painting);

                // Success
                response.statusCode = 200;
                response.statusDescription = "POST successful for painting #" + painting.PaintingId + "!";
                return response;
            }
            catch (Exception)
            {
                // Failed, unable to create new painting
                response.statusCode = 400;
                response.statusDescription = "POST unsuccessful.";
                return response;
            }

            
        }

        // DELETE: api/Painting/5
        [HttpDelete("{id}")]
        public async Task<Response> DeletePainting(int id)
        {
            // Declare response
            var response = new Response();
            try
            {
                var painting = await _context.Painting.FindAsync(id);

                // If painting does not exist
                if (painting == null)
                {
                    response.statusCode = 404;
                    response.statusDescription = "Painting #" + id + " not found.";

                    return response;
                }

                _context.Painting.Remove(painting);
                await _context.SaveChangesAsync();


                // Success
                response.statusCode = 200;
                response.statusDescription = "Successfully deleted painting #" + id;

                return response;
            }
            catch (Exception)
            {
                // Failure
                response.statusCode = 400;
                response.statusDescription = "Something went wrong. Did you delete the PaintingInfo yet?";
                return response;

            }
        }

        private bool PaintingExists(int id)
        {
            return _context.Painting.Any(e => e.PaintingId == id);
        }
    }
}
