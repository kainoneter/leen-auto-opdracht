using FRCovadis.Shared.Responses;

namespace FRCovadis.Responses;

public class AuthResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}