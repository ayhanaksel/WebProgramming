using MVCProject.Models;
using System.Collections.Generic;

namespace MVCProject.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }
}