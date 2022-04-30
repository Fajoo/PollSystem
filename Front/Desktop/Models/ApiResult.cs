using System.Net;

namespace Desktop.Models;

public class ApiResult<T>
{
    public T Obj { get; set; }
    public HttpStatusCode Code { get; set; }
}