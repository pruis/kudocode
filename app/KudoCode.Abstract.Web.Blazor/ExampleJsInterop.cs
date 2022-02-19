using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace RazorClassLibrary_CSharp
{
    public class ExampleJsInterop
    {
        public static async Task<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            // Implemented in exampleJsInterop.js
            return await jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                message);
        }
    }
}