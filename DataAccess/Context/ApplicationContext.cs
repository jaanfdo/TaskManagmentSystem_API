
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<tbl_genCompanyBranchMaster> tbl_genCompanyBranchMaster { get; set; }
        public virtual DbSet<tbl_genCompanyInfo> tbl_genCompanyInfo { get; set; }
        public virtual DbSet<tbl_genCustomerMaster> tbl_genCustomerMaster { get; set; }
        public virtual DbSet<tbl_genMasFunction> tbl_genMasFunction { get; set; }
        public virtual DbSet<tbl_genMasModule> tbl_genMasModule { get; set; }
        public virtual DbSet<tbl_genMasPriority> tbl_genMasPriority { get; set; }
        public virtual DbSet<tbl_genMasProduct> tbl_genMasProduct { get; set; }
        public virtual DbSet<tbl_genMasStatus> tbl_genMasStatus { get; set; }
        public virtual DbSet<tbl_genMasSubTask> tbl_genMasSubTask { get; set; }
        public virtual DbSet<tbl_genMasTaskType> tbl_genMasTaskType { get; set; }
        public virtual DbSet<tbl_pmsTxTask> tbl_pmsTxTask { get; set; }
        public virtual DbSet<tbl_pmsTxTaskEstimation> tbl_pmsTxTaskEstimation { get; set; }
        public virtual DbSet<tbl_pmsTxTaskEstimation_Detail> tbl_pmsTxTaskEstimation_Detail { get; set; }
        public virtual DbSet<tbl_pmsTxTimeSheet> tbl_pmsTxTimeSheet { get; set; }
        public virtual DbSet<tbl_pmsTxTimeSheet_Detail> tbl_pmsTxTimeSheet_Detail { get; set; }
        public virtual DbSet<tbl_sasAttachments> tbl_sasAttachments { get; set; }
        public virtual DbSet<tbl_securityGroup> tbl_securityGroup { get; set; }
        public virtual DbSet<tbl_securityGroupPermission> tbl_securityGroupPermission { get; set; }
        public virtual DbSet<tbl_securityUserMaster> tbl_securityUserMaster { get; set; }
        public virtual DbSet<tbl_securityUserPermission> tbl_securityUserPermission { get; set; }
        public virtual DbSet<tbl_securityFunctionMaster> tbl_securityFunctionMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_genCompanyBranchMaster>()
                .HasKey(c => new { c.company_ID, c.companyBranch_ID });

            modelBuilder.Entity<tbl_pmsTxTaskEstimation_Detail>()
                .HasKey(c => new { c.estimation_ID, c.subTask_ID, c.line_No });

            modelBuilder.Entity<tbl_pmsTxTimeSheet_Detail>()
                .HasKey(c => new { c.timeSheet_ID, c.task_ID, c.line_No });

            modelBuilder.Entity<tbl_sasAttachments>()
                .HasKey(c => new { c.transaction_ID, c.attachment_Index });
        }
    }
}
