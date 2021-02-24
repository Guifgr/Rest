using Rest.Data.VO;
using Rest.models;

namespace Rest.Repository.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User RefreshUserInfo(User user);
        bool RevokeToken(string userName);
        User RefreshUserInfo(string userName);
    }
}