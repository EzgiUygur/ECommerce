namespace ECommerce.Api.Messaging
{
    public sealed class Response<T>
    {
        public Response(T body, int statusCode = 0)
        {
            this.Body = body;
            this.StatusCode = statusCode;
        }

        public int StatusCode { get; set; }

        public T Body { get; set; }

        public static Response<TBody> Success<TBody>(TBody body)
        {
            return new Response<TBody>(body, 200);
        }

        public static Response<TBody> Fail<TBody>(TBody body)
        {
            return new Response<TBody>(body, 0);
        }
    }
}