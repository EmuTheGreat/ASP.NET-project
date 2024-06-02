using ExampleCore.TraceLogic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ExampleCore.TraceIdLogic;

public class WriteTraceIdMiddlware
{
    private readonly RequestDelegate _requestDelegate;

    public WriteTraceIdMiddlware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context, IEnumerable<ITraceWriter> traceWriterList)
    {
        foreach (var traceWriter in traceWriterList)
        {
            traceWriter.GetValue();
        }

        await _requestDelegate(context);
    }
}