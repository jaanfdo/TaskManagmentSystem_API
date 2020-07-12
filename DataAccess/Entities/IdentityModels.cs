using System.Security.Claims;
using System.Threading.Tasks;

namespace DataAccessDataAccess
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    #region MyRegion
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }

    //    public virtual DbSet<tbl_genCompanyBranchMaster> tbl_genCompanyBranchMaster { get; set; }
    //    public virtual DbSet<tbl_genCompanyInfo> tbl_genCompanyInfo { get; set; }
    //    public virtual DbSet<tbl_genCustomerMaster> tbl_genCustomerMaster { get; set; }
    //    public virtual DbSet<tbl_genMasFunction> tbl_genMasFunction { get; set; }
    //    public virtual DbSet<tbl_genMasModule> tbl_genMasModule { get; set; }
    //    public virtual DbSet<tbl_genMasPriority> tbl_genMasPriority { get; set; }
    //    public virtual DbSet<tbl_genMasProduct> tbl_genMasProduct { get; set; }
    //    public virtual DbSet<tbl_genMasStatus> tbl_genMasStatus { get; set; }
    //    public virtual DbSet<tbl_genMasSubTask> tbl_genMasSubTask { get; set; }
    //    public virtual DbSet<tbl_genMasTaskType> tbl_genMasTaskType { get; set; }
    //    public virtual DbSet<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }
    //    public virtual DbSet<tbl_pmsTxTaskEstimation> tbl_pmsTxTaskEstimation { get; set; }
    //    public virtual DbSet<tbl_pmsTxTaskEstimation_Detail> tbl_pmsTxTaskEstimation_Detail { get; set; }
    //    public virtual DbSet<tbl_pmsTxTimeSheet> tbl_pmsTxTimeSheet { get; set; }
    //    public virtual DbSet<tbl_pmsTxTimeSheet_Detail> tbl_pmsTxTimeSheet_Detail { get; set; }
    //    public virtual DbSet<tbl_sasAttachments> tbl_sasAttachments { get; set; }
    //    public virtual DbSet<tbl_securityGroup> tbl_securityGroup { get; set; }
    //    public virtual DbSet<tbl_securityGroupPermission> tbl_securityGroupPermission { get; set; }
    //    public virtual DbSet<tbl_securityUserMaster> tbl_securityUserMaster { get; set; }
    //    public virtual DbSet<tbl_securityUserPermission> tbl_securityUserPermission { get; set; }

    //    public virtual DbSet<tbl_securityFunctionMaster> tbl_securityFunctionMaster { get; set; }
    //} 
    #endregion
}