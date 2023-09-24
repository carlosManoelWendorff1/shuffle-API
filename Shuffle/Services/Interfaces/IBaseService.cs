namespace Shuffle.Services.Interfaces;

public interface IBaseService<T>
{
    Task<T> FindById(Guid id);
    Task<IEnumerable<T>> FindAll();
    Task<IEnumerable<T>> Create(T request);
    Task<IEnumerable<T>>? Update(T request);
    Task<IEnumerable<T>>? Delete(Guid id);
}