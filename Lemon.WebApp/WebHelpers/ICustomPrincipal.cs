using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.WebApp.WebHelpers
{
    using System.Security.Principal;

    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }

        string Email { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string email)
        {
            Identity = new GenericIdentity(email);
        }

        public IIdentity Identity { get; private set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}
