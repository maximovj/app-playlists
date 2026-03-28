using System;

namespace ApiPlayLists.Models;

public class ApiResponseDto
{

    public int Status { get; set; }

    public bool Success { get; set; } = false;

    public string? Message { get; set; } = "";

    public string? Error { get; set; } = "";

    public Object? Content { get; set; } = null;

}
