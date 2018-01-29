using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NHibernate.Type;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.ResourcesFiles;

namespace SCMProfitCore.Model.CustomerModule
{
    public class Customer
    {

        public virtual Guid CustomerId { get; set; }
        [Display(Name = "CompanyName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CompanyNameRequired")]
        public virtual string CompanyName { set; get; }
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FirstNameRequired")]
        public virtual string FirstName { set; get; }
        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LastNameRequired")]
        public virtual string LastName { set; get; }
        [Display(Name = "ContactPerson", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ContactFieldRequired")]
        public virtual long PrimaryContact { get; set; }
        [Display(Name = "Currency", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ContactFieldRequired")]
        public virtual CurrencyType Currency { get; set; }
        [Display(Name = "ShortName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "ShortNameFieldRequired")]
        public virtual string ShortName { set; get; }
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailFieldRequired")]
        public virtual string Email { set; get; }
        [Display(Name = "Role", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RoleFieldRequired")]
        public virtual string Role { get; set; }
        [Display(Name = "URL", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "UrlFieldRequired")]
        public virtual string WebsiteUrl { get; set; }
        public virtual int IsApproved { get; set; }


        [Required]
        public virtual ICollection<CustomerSubscriptionDetails> Subscriptions { set; get; }
        public virtual CustomerLoginDetails LoginDetails { set; get; }

        [Required]
        public virtual Partner Partner { set; get; }
        public virtual CustomerAddress CustomerAddress { get; set; }

        public Customer()
        {
            Subscriptions=new List<CustomerSubscriptionDetails>();
        }

        public Customer(Guid guid, string name, long contact, CurrencyType currency, string shortName, string email, string firstName, string lastName, string url,ICollection<CustomerSubscriptionDetails> subscription,CustomerLoginDetails loginDetails,Partner partner,CustomerAddress address,string role )
            : this()
        {
            CustomerId = guid;
            CompanyName = name;
            PrimaryContact = contact;
            Currency = currency;
            ShortName = shortName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            WebsiteUrl = url;
            Subscriptions = subscription;
            LoginDetails = loginDetails;
            Partner = partner;
            CustomerAddress = address;
            Role = role;
        }

        public static Customer Create(Guid guid, string name, long contact, CurrencyType currency, string shortName, string email, string firstName, string lastName, string url,ICollection<CustomerSubscriptionDetails> subscription,CustomerLoginDetails loginDetails,Partner partner,CustomerAddress address,string role )
        {
            return new Customer(guid, name, contact, currency, shortName, email, firstName, lastName, url,subscription,loginDetails,partner,address,role);
        }

        private static void Validate(string name, string address, long contact, CurrencyType currency, string shortName, string email, string firstName, string lastName, string url)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception();
            if (string.IsNullOrEmpty(contact.ToString()))
                throw new Exception();
            if (string.IsNullOrEmpty(currency.ToString()))
                throw new Exception();
            if (string.IsNullOrEmpty(shortName))
                throw new Exception();
            if (string.IsNullOrEmpty(firstName))
                throw new Exception();
            if (string.IsNullOrEmpty(lastName))
                throw new Exception();
            if (string.IsNullOrEmpty(url))
                throw new Exception();
            if (string.IsNullOrEmpty(email))
                throw new Exception();

        }
    }
}
