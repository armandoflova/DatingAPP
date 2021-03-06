using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddAplicationError(this HttpResponse response, string message){
            response.Headers.Add("Aplications-Error", message);
            response.Headers.Add("Acces-control-Expose-Headers","Aplication-Error" );
            response.Headers.Add("Acces-control-Allow-origin", "*");

        }

    }
}