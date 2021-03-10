using System.Threading;
using System.Threading.Tasks;

namespace SGP.Shared.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Salva as altera��es feitas no banco de dados.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>O n�mero de entradas gravadas no banco de dados.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
