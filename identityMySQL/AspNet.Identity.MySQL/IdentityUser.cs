﻿using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.MySQL
{

    public class IdentityUser : IUser
    {

        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public string Id { get; set; }


        public string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }


        public virtual string PasswordHash { get; set; }

  
        public virtual string SecurityStamp { get; set; }

   
        public virtual string PhoneNumber { get; set; }

  
        public virtual bool PhoneNumberConfirmed { get; set; }


        public virtual bool TwoFactorEnabled { get; set; }

   
        public virtual DateTime? LockoutEndDateUtc { get; set; }


        public virtual bool LockoutEnabled { get; set; }

    
        public virtual int AccessFailedCount { get; set; }
    }
}
