


using Diet.Domain.Case;
using Diet.Domain.disease;
using Diet.Domain.food.Entities;
using Diet.Domain.lifeCourse;
using Diet.Domain.Recommendation.Entities;
using Diet.Domain.sport;
using Diet.Domain.supplement.Entities;
using Diet.Domain.ticket.Entities;
using Diet.Domain.transactions;
using Diet.Domain.user;
using Diet.Domain.user.Entities;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Order.Persistence.EF.Context;

public class DietDbContext : ApplicationDbContext
{
    public DietDbContext(DbContextOptions<DietDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
    #region Entity  
    public DbSet<Case> Case { get; set; }
    public DbSet<CaseSupplement> CaseSupplement { get; set; }
    public DbSet<CaseDisease> CaseDisease { get; set; }
    public DbSet<CaseDrug> CaseDrug { get; set; }
    public DbSet<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; set; }

    public DbSet<Disease> Disease { get; set; }
    public DbSet<Drug> Drug { get; set; }
    public DbSet<Diet.Domain.food.Entities.Food> Food { get; set; }
    public DbSet<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }
    public DbSet<Food_Food_Intraction> Food_Food_Intraction { get; set; }
    public DbSet<Diet.Domain.food.Entities.FoodGroup> FoodGroup { get; set; }
    public DbSet<Diet. Domain.food.Entities.FoodStuff> FoodStuff { get; set; }
    public DbSet<LifeCourse> LifeCourse { get; set; }
    public DbSet<DurationAge> DurationAge { get; set; }
    public DbSet<Recommendation> Recommendation { get; set; }
    public DbSet<RecommendationDisease_WhiteList> RecommendationDisease_WhiteList { get; set; }
    public DbSet<RecommendationDurationAge> RecommendationDurationAge { get; set; }
    public DbSet<RecommendationLifeCourse> RecommendationLifeCourse { get; set; }
    public DbSet<Sport> Sport { get; set; }
    public DbSet<Supplement> Supplement { get; set; }
    public DbSet<SupplementDisease_WhiteList> SupplementDisease_WhiteList { get; set; }
    public DbSet<SupplementDurationAge> SupplementDurationAge { get; set; }
    public DbSet<SupplementGroup> SupplementGroup { get; set; }
    public DbSet<SupplementLifeCourse> SupplementLifeCourse { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<TicketMessage> TicketMessage { get; set; }
    public DbSet<Transactions> Transactions { get; set; }


    public DbSet<User> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }

    #endregion


}
