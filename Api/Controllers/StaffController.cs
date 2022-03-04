using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    public class StaffController : BaseApiController
    {
        private readonly StaffService _service;
        public StaffController(StaffService service)
        {
            _service = service;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create new Staff")]
        public async Task<ActionResult> Create(CreateStaffModel newStaff)
        {
            Staff staff = new Staff
            {
                CenterId = newStaff.CenterId,
                Gender = newStaff.Gender,
                Image = newStaff.Image,
                Name = newStaff.Name,
                Email = newStaff.Email
            };
            await _service.Create(staff);
            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
        }
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update Staff")]
        public async Task<ActionResult> Update(Guid id, ResponseStaffModel updateStaff)
        {
            if (id != updateStaff.Id)
            {
                return BadRequest();
            }
            Staff staff = new Staff
            {
                Id = updateStaff.Id,
                CenterId = updateStaff.CenterId,
                Gender = updateStaff.Gender,
                Image = updateStaff.Image,
                Name = updateStaff.Name,
                Email = updateStaff.Email,
            };
            bool check = await _service.Update(staff);
            if (!check)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Staff by Id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            Staff staff = await _service.GetById(id);
            if (staff == null)
            {
                return NotFound();
            }
            ResponseStaffModel responseStaffModel = new ResponseStaffModel
            {
                Id = staff.Id,
                CenterId = staff.CenterId,
                Gender = staff.Gender,
                Image = staff.Image,
                Name = staff.Name,
                Email = staff.Email,
            };
            return Ok(responseStaffModel);
        }
        [HttpGet("CenterId")]
        [SwaggerOperation(Summary = "Get Staff by Center Id")]
        public async Task<List<Staff>> GetByCenterId(Guid CenterId, int pageNumber, int pageSize)
        {
            if (CenterId == Guid.Empty)
            {
                return  _service.GetList( pageNumber, pageSize);
            }
            List<Staff> listStaffs = await _service.GetByCenterId(CenterId,pageNumber,pageSize);
            
            return listStaffs;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get list Staff")]
        public ActionResult GetList(int pageNumber, int pageSize)
        {
            List<Staff> listStaffs = _service.GetList(pageNumber, pageSize);

            return Ok(listStaffs);
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Staff by Id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool check = await _service.Delete(id);
            if (!check)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}