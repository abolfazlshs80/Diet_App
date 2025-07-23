namespace Diet.Application.Execptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException (string message) : base(message)
        {
        }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }

    public class ServiceException : Exception
    {
//        {
//  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
//  "title": "Title => Please  Enter a customer name",
//  "status": 400,
//  "traceId": "00-bcb4ed792e5ab68755839bd26b7e4074-94d3a046d4a3d5d5-00"
//         }


        // سازنده خصوصی
        private ServiceException(string type, string title, string details, IReadOnlyList<string>? errors)
            : base(message: "request failed")
        {
            Type = type;
            Title = title;
            Details = details;
            Errors = errors;
        }

        // خصوصیات فقط خواندنی
        public string Type { get; }
        public string Title { get; }
        public string Details { get; }
        public IReadOnlyList<string>? Errors { get; }

        // متد استاتیک برای ایجاد نمونه
        public static ServiceException Create(
            string type,
            string title,
            string details,
            IReadOnlyList<string>? errors = null)
        {
            return new ServiceException(type, title, details, errors);
        }

        // متد برای نمایش اطلاعات خطا به صورت رشته
        public override string ToString()
        {
            return $"Type: {Type}\nTitle: {Title}\nDetails: {Details}";
        }
    }
}
