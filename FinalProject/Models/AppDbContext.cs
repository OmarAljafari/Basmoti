using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class AppDbContext:IdentityDbContext<MyUserProject>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        

        public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; } = null!;
        public virtual DbSet<MasterContactUsInformation> MasterContactUsInformations { get; set; } = null!;
        public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; } = null!;
        public virtual DbSet<MasterMenu> MasterMenus { get; set; } = null!;
        public virtual DbSet<MasterOffer> MasterOffers { get; set; } = null!;
        public virtual DbSet<MasterPartner> MasterPartners { get; set; } = null!;
        public virtual DbSet<MasterService> MasterServices { get; set; } = null!;
        public virtual DbSet<MasterSlider> MasterSliders { get; set; } = null!;
        public virtual DbSet<MasterSocialMedia> MasterSocialMedia { get; set; } = null!;
        public virtual DbSet<MasterWorkingHour> MasterWorkingHours { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;
        public virtual DbSet<TransactionBookTable> TransactionBookTables { get; set; } = null!;
        public virtual DbSet<TransactionContactUs> TransactionContactUs { get; set; } = null!;
        public virtual DbSet<TransactionNewsletter> TransactionNewsletters { get; set; } = null!;
        public virtual DbSet<WhatPeopleSay> WhatPeopleSay { get; set; } = null!;
        public virtual DbSet<MyUserProject> MyUserProject { get; set; } = null!;
    }
}
