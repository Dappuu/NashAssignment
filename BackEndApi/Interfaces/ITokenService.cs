using BackEndApi.Models;

namespace BackEndApi.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(User user);
	}
}
