using System;
using System.Net;
using ApiPlayLists.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayLists.Utils;

public class ApiResponseUtils: ControllerBase
{

    public IActionResult OK(string? message, Object? content)
    {
        var response = new ApiResponseDto
        {
            Status = ((int)HttpStatusCode.OK),
            Content = content,
            Error = null,
            Message = message,
            Success = true,
        };
        return StatusCode(((int)HttpStatusCode.OK), response);
    }
    
    public IActionResult ERR(string? error, Object? content)
    {
        var response = new ApiResponseDto
        {
            Status = ((int)HttpStatusCode.InternalServerError),
            Content = content,
            Error = error,
            Message = null,
            Success = false,
        };
        return StatusCode(((int)HttpStatusCode.InternalServerError), response);
    }

    public IActionResult WhitCodeStatus(HttpStatusCode code, Object? content, string? error, string? message, bool success)
    {
        var response = new ApiResponseDto
        {
            Status = ((int)code),
            Content = content,
            Error = error,
            Message = message,
            Success = success,
        };
        return StatusCode(((int)code), response);
    }

}
