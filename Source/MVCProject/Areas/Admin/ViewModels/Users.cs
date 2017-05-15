using MVCProject.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }

    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class UsersEdit
    {
        [Required, MaxLength(128)]
        public string UserName { get; set; }
        [Required, MaxLength(256)]
        public string Email { get; set; }
    }

    public class UsersResetPassword
    {
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}