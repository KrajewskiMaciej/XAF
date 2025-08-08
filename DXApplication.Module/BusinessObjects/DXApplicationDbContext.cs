using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.DataAccess.Sql;
using DXApplication.Module.BusinessObjects;

namespace DXApplication.Module.BusinessObjects;


[TypesInfoInitializer(typeof(DbContextTypesInfoInitializer<DXApplicationEFCoreDbContext>))]
public class DXApplicationEFCoreDbContext : DbContext
{
    public DXApplicationEFCoreDbContext(DbContextOptions<DXApplicationEFCoreDbContext> options) : base(options)
    {
    }
    //public DbSet<ModuleInfo> ModulesInfo { get; set; }
    public DbSet<Mandant> Mandanci { get; set; }
    public DbSet<Zaklady> Zaklady { get; set; }
    public DbSet<AutoNumSchemat> AutoNumSchemats { get; set; }
    public DbSet<TypyZamowienia> TypyZamowienia { get; set; }
    public DbSet<Wydzialy> Wydzialy { get; set; }
    public DbSet<Jednostki> Jednostki { get; set; }
    public DbSet<SchematyAutokodowania> AutoKodSchemat { get; set; }
    public DbSet<PlanPracy> PlanyPracy { get; set; }
    public DbSet<KodyTransakcji> KodyTransakcji { get; set; }
    public DbSet<Waluty> Waluty { get; set; }
    public DbSet<KursyWalut> KursyWalut { get; set; }
    public DbSet<VatOpisy> VatOpisy { get; set; }
    public DbSet<VatPowiazania> VatPowiazania { get; set; }
    public DbSet<VatWartosci> VatWartosci { get; set; }
    public DbSet<VatSposoby> VatSposoby { get; set; }
    public DbSet<Kraje> Kraje { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VatPowiazania>()
        .HasKey(vp => new { vp.VatOpisyId, vp.VatSposobyId, vp.KrajeId });
    }
    
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetPrimaryKeys();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        SetPrimaryKeys();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void SetPrimaryKeys()
    {
        // Znajdź wszystkie nowe obiekty typu AutoNumSchemat, które są dodawane do bazy
        var newEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added && e.Entity is AutoNumSchemat)
            .Select(e => e.Entity as AutoNumSchemat);

        foreach (var entity in newEntities)
        {
            // Jeśli ID nie zostało jeszcze ustawione (jest domyślną wartością)
            if (entity.AUTO_NUM_SCHEMAT_ID == 0)
            {
                // Użyj surowego SQL, aby wywołać generator Firebird
                // 'Database.GetDbConnection()' daje dostęp do połączenia, aby wykonać polecenie
                using var command = Database.GetDbConnection().CreateCommand();
                command.CommandText = "SELECT GEN_ID(SET_AUTO_NUM_SCHEMAT_ID, 1) FROM RDB$DATABASE";
                Database.OpenConnection();
                // Pobierz wynik i przypisz go do właściwości ID
                entity.AUTO_NUM_SCHEMAT_ID = Convert.ToInt32(command.ExecuteScalar());
                Database.CloseConnection();
            }
        }

        var newPlanyPracy = ChangeTracker.Entries<PlanPracy>()
           .Where(e => e.State == EntityState.Added);

        if (newPlanyPracy.Any())
        {
            var maxId = this.PlanyPracy.Max(p => (int?)p.PLAN_PRACY_ID) ?? 0;
            foreach (var entityEntry in newPlanyPracy)
            {
                if (entityEntry.Entity.PLAN_PRACY_ID == 0)
                {
                    maxId++;
                    entityEntry.Entity.PLAN_PRACY_ID = maxId;
                }
            }
        }
        
         var newKodyTransakcji = ChangeTracker.Entries<KodyTransakcji>()
            .Where(e => e.State == EntityState.Added);

        if (newKodyTransakcji.Any())
        {
            var maxId = this.KodyTransakcji.Max(k => (int?)k.KODY_TRANSAKCJI_ID) ?? 0;
            foreach (var entityEntry in newKodyTransakcji)
            {
                if (entityEntry.Entity.KODY_TRANSAKCJI_ID == 0)
                {
                    maxId++;
                    entityEntry.Entity.KODY_TRANSAKCJI_ID = maxId;
                }
            }
        }
    }
}
