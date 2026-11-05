using DbApi.DTO;
using DbApi.Exceptions;

namespace DbApi.Middlewares
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next; 

        public ErrorMiddleware(RequestDelegate next)
        {
            _next  = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                
            }
            catch(NotFoundException ex)
            {
                context.Response.StatusCode = 400;
                var resposta = new ErrorDTO(ex.Message);
                await context.Response.WriteAsJsonAsync(resposta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao obter: {ex.Message}");
                context.Response.StatusCode = 500;

                var resposta = new ErrorDTO("Ocorreu um erro na chamada por favor tente novamente mais tarde");

                await context.Response.WriteAsJsonAsync(resposta);

            }
            
        }

    }
}