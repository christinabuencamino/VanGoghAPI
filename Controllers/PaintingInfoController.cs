#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanGoghAPI.Models;

namespace VanGoghAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingInfoController : ControllerBase
    {
        private readonly VanGoghDBContext _context;

        public PaintingInfoController(VanGoghDBContext context)
        {
            _context = context;
        }

        // Removed GET because it is redundant ; can get information from paintings controller

        // PUT: api/PaintingInfo/5
        [HttpPut("{id}")]
        public async Task<Response> PutPaintingInfo(int id, PaintingInfo paintingInfo)
        {
            // Declare response
            var response = new Response();

            // Check if the parameter ID matches the request body ID
            if (id != paintingInfo.PaintingInfoId)
            {
                response.statusCode = 400;
                response.statusDescription = "Bad request. Parameter painting ID does not match PaintingInfoID.";
                return response;
            }

            _context.Entry(paintingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Success
                response.statusCode = 200;
                response.statusDescription = "Update successful on painting #" + id + "!";
                response.paintings = new List<Painting>();
                var painting = await _context.Painting.FindAsync(id);
                response.paintings.Add(painting);

                return response;
            }
            catch (Exception)
            {
                // Failure: Painting with PaintingId = id does not exist
                if (!PaintingInfoExists(id))
                {
                    response.statusCode = 404;
                    response.statusDescription = "Painting ID not found.";
                    return response;
                }
                // Misc. client side issue
                else
                {
                    response.statusCode = 400;
                    response.statusDescription = "Bad request. Try again.";
                    return response;
                }
            }
        }

        // DELETE: api/PaintingInfo/5
        [HttpDelete("{id}")]
        public async Task<Response> DeletePaintingInfo(int id)
        {
            // Declare response
            var response = new Response();
            try
            {
                var paintingInfo = await _context.PaintingInfo.FindAsync(id);

                // If painting info with paintinginfoid = id does not exist
                if (paintingInfo == null)
                {
                    response.statusCode = 404;
                    response.statusDescription = "PaintingInfo #" + id + " not found.";

                    return response;
                }

                _context.PaintingInfo.Remove(paintingInfo);
                await _context.SaveChangesAsync();

                // Success
                response.statusCode = 200;
                response.statusDescription = "Successfully deleted PaintingInfo #" + id;

                return response;
            }
            catch (Exception)
            {
                // Failed attempt
                response.statusCode = 400;
                response.statusDescription = "Bad request.";
                return response;

            }
        }
            private bool PaintingInfoExists(int id)
        {
            return _context.PaintingInfo.Any(e => e.PaintingInfoId == id);
        }
    }
}
