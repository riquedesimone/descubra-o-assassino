namespace DescubraOAssassino.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
