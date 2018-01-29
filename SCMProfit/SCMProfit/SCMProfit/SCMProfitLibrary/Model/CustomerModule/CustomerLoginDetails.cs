using System;
using System.ComponentModel.DataAnnotations;
using SCMProfitCore.ResourcesFiles;

namespace SCMProfitCore.Model.CustomerModule
{
    public class CustomerLoginDetails
    {
        public virtual Guid LoginId { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "UserNameRequired")]
        public virtual string UserName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordFieldRequired")]
        public virtual string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resource))]
        public virtual bool RememberMe { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public CustomerLoginDetails()
        {
            Customer = new Customer();
        }

        public CustomerLoginDetails(Guid id, string userName, string password)
            : this()
        {
            LoginId = id;
            UserName = userName;
            Password = password;
        }

        public static CustomerLoginDetails Create(Guid guid, string userName, string password)
        {
            return new CustomerLoginDetails(guid, userName, password);
        }
    }
}
