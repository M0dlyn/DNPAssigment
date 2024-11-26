using ApiContracts;

namespace ServicesContracts
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto request);
        Task<AuthResponseDto> RegisterAsync(RegisterDto request);
    }
}