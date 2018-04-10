namespace SimpleSimulatorAccess
{
    using SimulatorDataModel;
    using SimulatorManager;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class SimulatorContext :  DbContext
    {
        // Your context has been configured to use a 'SimulatorContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SimpleSimulatorAccess.SimulatorContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SimulatorContext' 
        // connection string in the application configuration file.
        public SimulatorContext()
            : base("name=SimulatorContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<FootballerRole> FootballerRoles { get; set; }
        public virtual DbSet<Footballer> Footballers { get; set; }
        public virtual DbSet<FootballTeam> FootballTeams { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Championship> Championships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // fluent configuration can be done here 
        }
    }

 
}