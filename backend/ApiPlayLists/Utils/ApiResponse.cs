using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayLists.Utils;

public class ApiResponse
{

    public static IActionResult WhitCodeStatus(HttpStatusCode code, Object? content, string? error, string? message, bool success)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(code, content, error, message, success);
    }

    public static IActionResult OK(string? message, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.OK(message, content);
    }

    public static IActionResult ERR(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.ERR(error, content);
    }

    public static IActionResult ServerError(string? error)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.ERR(error, null);
    }

    public static IActionResult Success(string? message, Object? data = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.OK(message, data);
    }

    public static IActionResult Error(HttpStatusCode code, string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(code, content, error, null, false);
    }

    public static IActionResult Created(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(HttpStatusCode.Created, content, error, null, false);
    }

    public static IActionResult BadRequest(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(HttpStatusCode.BadRequest, content, error, null, false);
    }

    public static IActionResult NotFound(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(HttpStatusCode.NotFound, content, error, null, false);
    }

    public static IActionResult NotContent(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.NoContent();
    }

    public static IActionResult Conflict(string? error, Object? content = null)
    {
        ApiResponseUtils responseUtils = new ApiResponseUtils();
        return responseUtils.WhitCodeStatus(HttpStatusCode.Conflict, content, error, null, false);
    }

}
