﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual void SetPassword(string password)
        {
            PasswordHash = "IGNORE_ME";
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.UserName, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x =>
            {
                x.Column("Password_Hash");
                x.NotNullable(true);
            });
        }
    }
}