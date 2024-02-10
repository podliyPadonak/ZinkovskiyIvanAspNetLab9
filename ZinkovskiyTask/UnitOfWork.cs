namespace ZinkovskiyTask
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(SchoolDbContext context)
        {
            Students = new StudentRepository(context);
        }

        public IStudentRepository Students { get; }

        public void Dispose()
        {
            //Students.Dispose();
        }

        public int SaveChanges()
        {
            return Students.SaveChanges();
        }
    }
}