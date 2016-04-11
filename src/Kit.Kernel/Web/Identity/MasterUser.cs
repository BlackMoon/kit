using System;
using Microsoft.AspNet.Identity;

namespace Kit.Kernel.Web.Identity
{
    public class User : IUser<DateTime>
    {
        /// <summary>
        /// Время входа
        /// </summary>
        public DateTime Id { get; set; }

        public string DataSource { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
