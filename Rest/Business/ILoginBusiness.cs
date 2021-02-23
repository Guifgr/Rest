using Rest.Data.VO;

namespace Rest.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredential(UserVO user);
        TokenVO RefreshCredential(TokenVO token);
    }
}