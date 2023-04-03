namespace ECommerce.Core.Constants
{
    public static class Validations
    {
        public const string NameExpression = @"\A\S+\z";
        public const string PhoneNumberExpression = @"^[5]{1}[0-9]{9}$";
        public const string EmailExpression = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
