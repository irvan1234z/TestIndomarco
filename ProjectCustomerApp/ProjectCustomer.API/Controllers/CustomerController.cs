using Microsoft.AspNetCore.Mvc;
using ProjectCustomer.Application.Models;
using ProjectCustomer.Application.Interfaces;
using ProjectCustomer.Domain.Entities;

namespace ProjectCustomer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    #region GetRows

    [HttpGet("GetRows")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(new ApiResponse<IEnumerable<Customer>>(result, "Data customer berhasil diambil"));
    }
    
    #endregion

    #region GetRowByID
    [HttpGet("GetRowByID")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<string>(null, "Customer tidak ditemukan"));
        }   

        return Ok(new ApiResponse<Customer>(result, "Data customer ditemukan"));
    }
    #endregion

    #region Insert
    [HttpPost("Insert")]
    public async Task<IActionResult> Create(CustomerModel model)
    {
        var result = await _service.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = result.CustomerId }, new ApiResponse<Customer>(result, "Customer berhasil ditambahkan"));
    }
    #endregion

    #region UpdateByID
    [HttpPut("UpdateByID")]
    public async Task<IActionResult> Update(int id, [FromBody] CustomerModel model, [FromQuery] int modifiedBy)
    {
        var success = await _service.UpdateAsync(id, model, modifiedBy);
        if (!success)
            return NotFound(new ApiResponse<string>(null, "Customer tidak ditemukan"));

        return Ok(new ApiResponse<string>(null, "Customer berhasil diupdate"));
    }
    #endregion

    #region DeleteByID
    [HttpDelete("DeleteByID")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success)
            return NotFound(new ApiResponse<string>(null, "Customer tidak ditemukan"));

        return Ok(new ApiResponse<string>(null, "Customer berhasil dihapus"));
    }
    #endregion
}