namespace Backend.Api.GlobalExceptionHandling
{
    public class GlobalExceptions:Exception
    {
        public GlobalExceptions(ErrorResponsee res):base(res.Message) { }


    }
}
