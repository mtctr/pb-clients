namespace PB.Clients.API.Domain.Utils;

public static class RegexValidations
{    
    public static string Email => @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
}
