using Microsoft.AspNetCore.Mvc;
using ProductManagement.Service.DTOs;

namespace CurrencySol.WebAPI.Helpers;
public static class ResponseHelper
{
    public static IActionResult CreateResourceResponse(object? data,
        string message = "Resource created successfully.")
    {
        ApiResponse response = new()
        {
            StatusCode = StatusCodes.Status201Created,
            Message = message,
            Data = data,
            Success = true
        };

        return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
    }

    public static IActionResult SuccessResponse(object? data,
        string message = "Success")
    {
        ApiResponse response = new()
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message,
            Data = data,
            Success = true
        };
        return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
    }

}
