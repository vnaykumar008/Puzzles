using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerPassCount
{
    class Test1232DbContext : DbContext
    {
        public Test1232DbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
            
        }
    }



    [Table("Employee")]
    class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public DateTime dob { get; set; }
    }

    [Table("Order")]
    class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int Id { get; set; }
        public string Item { get; set; }
        //[ForeignKey("Id")]
        //public Employee EmployeeId { get; set; }
        
    }

    class GenericRepository<TEntity> where TEntity :class 
    {
        private Test1232DbContext _dbContext;
        private DbSet<TEntity> dbSetEntity;
        public GenericRepository(Test1232DbContext dbContext)
        {
            _dbContext = dbContext;
            dbSetEntity = _dbContext.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSetEntity;
            return query.ToList();
        }

        public virtual void Delete(int Id)
        {
            IQueryable<TEntity> query = dbSetEntity;
            TEntity entityToDelete= dbSetEntity.Find(Id);
            dbSetEntity.Remove(entityToDelete);

        }

        public virtual void Insert(TEntity entity)
        {
            dbSetEntity.Add(entity);         
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSetEntity.Attach(entityToDelete);
            }
            dbSetEntity.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSetEntity.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

    class UnitOfWork : IDisposable
    {
        Test1232DbContext _dbContext;


        public UnitOfWork(Test1232DbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public GenericRepository<TEntity> GetRepo<TEntity>() where TEntity : class  
        {
            return new GenericRepository<TEntity>(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
