namespace Diet.Domain.Contract.DTOs.Authentication;

public record RegisterDto(
    string Firstname,
    string Lastname,
    string Password,
    string MobileNumber
    );

