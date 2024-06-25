using FRCovadis.Shared.Responses;

namespace FRCovadis.Responses;

public class UserResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
