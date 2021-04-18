using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGP.Shared.UnitOfWork
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        private readonly ILogger<UnitOfWork<TDbContext>> _logger;

        public UnitOfWork(TDbContext context, ILogger<UnitOfWork<TDbContext>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Ocorreu um erro (concorrência) ao salvar as informações na base de dados.");
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao salvar as informações na base de dados.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao salvar as informações na base de dados.");
                throw;
            }
        }
    }
}
