namespace BlogAppAPI.Middlewares
{
    public class MdCheckRoute
    {
        private RequestDelegate _next;
        public MdCheckRoute(RequestDelegate next) { _next = next; }
        public async Task Invoke(HttpContext context)
        {
            bool stt = false;
            switch (context.Request.Path)
            {
                case "/get-all-admin":
                    stt = true;
                    break;
                case "/login":
                    break;
                default:
                    break;
            }
            if(stt)
            {
                await context.Response.WriteAsync("deny");
                return;
            }
            await _next(context);
        }


    }
}
