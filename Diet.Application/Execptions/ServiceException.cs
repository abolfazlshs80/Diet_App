using Microsoft.AspNetCore.Http;

namespace Diet.Application.Execptions
{
    public class ServiceException : Exception
    {
        // سازنده خصوصی
        private ServiceException(string type, string title, string statusCode, IReadOnlyList<string>? errors)
            : base(message: "request failed")
        {
            Type = type;
            Title = title;
            StatusCode = statusCode;
            Errors = errors;
        }

        // خصوصیات فقط خواندنی
        public string Type { get; }
        public string Title { get; }
        public string StatusCode { get; }
        public IReadOnlyList<string>? Errors { get; }

        // متد استاتیک برای ایجاد نمونه
        public static ServiceException Create(
            string type,
            string title,
            string statusCode,
            IReadOnlyList<string>? errors = null)
        {
            return new ServiceException(type, title, statusCode, errors);
        }

        // متد برای نمایش اطلاعات خطا به صورت رشته
        public override string ToString()
        {
            return $"Type: {Type}\nTitle: {Title}\nDetails: {StatusCode}";
        }
    }
}
