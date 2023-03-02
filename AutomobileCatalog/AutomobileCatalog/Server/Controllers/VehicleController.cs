using AutomobileCatalog.Server.Infrastructure;
using AutomobileCatalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Azure.Messaging;
using System.Net;

namespace AutomobileCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepository _vehicleRepository;
		private readonly IWebHostEnvironment _environment;

		public VehicleController(VehicleRepository vehicleRepository, IWebHostEnvironment environment)
        {
            _vehicleRepository = vehicleRepository;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleReadDto>> GetListAsync()
        {
            return await _vehicleRepository.GetListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<VehicleReadDto> GetVehicleByIdAsync(int id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> AddAsync( VehicleCreateDto vehicleDto)
        {
            //         try
            //         {
            //	if (file == null || file.Length == 0)
            //		throw new Exception("Please select picture");

            //	var path = Path.Combine(_environment.WebRootPath, "Resources", file.FileName);

            //	using (FileStream stream = new FileStream(path, FileMode.Create))
            //	{
            //		await file.CopyToAsync(stream);
            //		stream.Close();
            //	}

            //	vehicleDto.ImageUrl = file.FileName;

            //	var newProduct = _vehicleRepository.AddAsync(vehicleDto);

            //             return newProduct.Id;
            //         }
            //         catch (Exception ex)
            //         {
            //             return 0;
            //}

           return await _vehicleRepository.AddAsync(vehicleDto);

		}

		[HttpPost, DisableRequestSizeLimit]
        [Route("uploadFile")]
		public async Task<ActionResult> UploadFile()
		{
			if (!Request.Form.Files.Any())
				return BadRequest("No files found in the request");

			if (Request.Form.Files.Count > 1)
				return BadRequest("Cannot upload more than one file at a time");

			if (Request.Form.Files[0].Length <= 0)
				return BadRequest("Invalid file length, seems to be empty");

			try
			{
				string webRootPath = _environment.WebRootPath;
				string uploadsDir = Path.Combine(webRootPath, "uploads");

				// wwwroot/uploads/
				if (!Directory.Exists(uploadsDir))
					Directory.CreateDirectory(uploadsDir);

				IFormFile file = Request.Form.Files[0];
				string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
				string fullPath = Path.Combine(uploadsDir, fileName);

				var buffer = 1024 * 1024;
				using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
				await file.CopyToAsync(stream);
				await stream.FlushAsync();

				string location = $"images/{fileName}";

				var result = new
				{
					message = "Upload successful",
					url = location
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Upload failed: " + ex.Message);
			}
		}

		[HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = _vehicleRepository.GetVehicleById(id);

            if (item is null)
                return NotFound();

            await _vehicleRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, VehicleCreateDto vehicleDto)
        {
            var item = _vehicleRepository.GetVehicleById(id);

            if (item is null)
                return NotFound();

            await _vehicleRepository.UpdateAsync(id, vehicleDto);

            return Ok();
        }
    }
}
