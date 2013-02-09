namespace Lemon.Common
{
    public interface ICriptoProvider
    {
        string ComputeHash(string str);

        string ComputeHash(string str, string salt);
    }
}