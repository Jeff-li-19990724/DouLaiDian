using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DouLaiDian
{
    public class MDF_DouLaiDian : DbContext
    {
        /// <summary>
        /// 数据库连接核心类（数据库上下文类）
        /// </summary>
        public MDF_DouLaiDian()
            : base("name=MDF_DouLaiDian")   //数据库上下文实体——和数据库名字相同
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; }
    }
    public class User
    {
        public int MyID { get; set; }
        public string UserName { get; set; }
        public string PassWod { get; set; }
        public string Sex { get; set; }
        public DateTime Birth { get; set; }
        public int UserID { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }
        public Role Roles { get; set; }

    }

}
