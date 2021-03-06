﻿namespace Rest.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string createDate, string expiration, string acessToken, string refreshToken)
        {
            Authenticated = authenticated;
            CreateDate = createDate;
            Expiration = expiration;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }

        public bool Authenticated { get; set; }
        public string CreateDate { get; set; }
        public string Expiration { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}