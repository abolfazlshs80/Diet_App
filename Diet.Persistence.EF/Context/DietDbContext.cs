


using Diet.Domain.Case;
using Diet.Domain.caseDisease;
using Diet.Domain.caseDrug;
using Diet.Domain.caseFoodStuffAllergy;
using Diet.Domain.casePleasantFood;
using Diet.Domain.caseSupplement;
using Diet.Domain.caseUnPleasantFood;
using Diet.Domain.disease;
using Diet.Domain.durationAge;
using Diet.Domain.food.Entities;
using Diet.Domain.lifeCourse.Entities;
using Diet.Domain.recommendation;
using Diet.Domain.recommendationDisease_WhiteList;
using Diet.Domain.recommendationDurationAge;
using Diet.Domain.recommendationLifeCourse;
using Diet.Domain.role;
using Diet.Domain.sport;
using Diet.Domain.supplement;
using Diet.Domain.supplementDisease_WhiteList;
using Diet.Domain.supplementDurationAge;
using Diet.Domain.supplementGroup;
using Diet.Domain.supplementLifeCourse;
using Diet.Domain.ticket;
using Diet.Domain.ticketMessage;
using Diet.Domain.transactions;
using Diet.Domain.user;
using Diet.Domain.userRole;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

using static Diet.Persistence.EF.Context.DietDbContextFactory;

namespace Diet.Persistence.EF.Context;
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

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    #region Entity  
    public DbSet<Case> Case { get; set; }
    public DbSet<CaseSupplement> CaseSupplement { get; set; }
    public DbSet<CaseDisease> CaseDisease { get; set; }
    public DbSet<CaseDrug> CaseDrug { get; set; }
    public DbSet<CaseFoodStuffAllergy> CaseFoodStuffAllergy { get; set; }
    public DbSet<CasePleasantFood> CasePleasantFood { get; set; }
    public DbSet<CaseUnPleasantFood> CaseUnPleasantFood { get; set; }

    public DbSet<Domain.disease.Disease> Disease { get; set; }
    public DbSet<Domain.drug.Drug> Drug { get; set; }
    public DbSet<Domain.food.Entities.Food> Food { get; set; }
    public DbSet<Food_Drug_Intraction> Food_Drug_Intraction { get; set; }
    public DbSet<Food_Food_Intraction> Food_Food_Intraction { get; set; }
    public DbSet<Domain.food.Entities.FoodGroup> FoodGroup { get; set; }
    public DbSet<Domain.food.Entities.FoodStuff> FoodStuff { get; set; }
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
