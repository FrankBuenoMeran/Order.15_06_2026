using Orders.Backend2.UnitsOfWork.Interfaces;
using Orders.Shared.Response;

namespace Orders.Backend2.UnitsOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericUnitOfWork<T> _repositoriy;

    public GenericUnitOfWork(IGenericUnitOfWork<T> Repositoriy)
    {
        _repositoriy = Repositoriy;
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity) => await
        _repositoriy.AddAsync(entity);

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await
        _repositoriy.DeleteAsync(id);

    public virtual async Task<ActionResponse<T>> GetAsync(int id) => await
        _repositoriy.GetAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await
        _repositoriy.GetAsync();

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity) => await
        _repositoriy.UpdateAsync(entity);
}