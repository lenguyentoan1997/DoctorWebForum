using DoctorsWebForum.Models.Forum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoctorsWebForum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual Client Client { get; set; }
        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Emoticon> Emoticons { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<CommentChild> CommentChilds { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Expertise> Expertises { get; set; }

        public DbSet<Type> Types { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Emoticon> Emoticons { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentChild> CommentChilds { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Image> Images { get; set; }


    }
}