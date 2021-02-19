using Rest.Data.VO;
using Rest.models;

namespace Rest.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}