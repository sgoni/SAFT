using Customer.Domain.AggregatesModel.BankingAggregate;
using Customer.Domain.AggregatesModel.CustomerAggregate;
using Customer.Domain.AggregatesModel.GeographicalAggregate;
using Customer.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedKernel.SeedWork;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Infrastructure
{
    public class CustomerDBContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "SAFT";

        public DbSet<Bank> Banks { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PaymentMethod> Payments { get; set; }
        public DbSet<Geographical> Territories { get; set; }

        private IDbContextTransaction _currentTransaction;

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CardTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BankingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GeographicalEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseMySQL("server=localhost;user=phantom;password=Developer1;database=saft;");
                options.UseSqlServer("Data Source=DESKTOP-V3MI6SG;Initial Catalog=saft;Integrated Security=True;Pooling=False");
            }
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
