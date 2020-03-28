namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Animal> AnimalRepository { get; }

        int Save();
    }
}