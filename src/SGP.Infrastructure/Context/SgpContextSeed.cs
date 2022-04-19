using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using SGP.Domain.Entities;
using SGP.Shared.Extensions;

namespace SGP.Infrastructure.Context;

/// <summary>
/// Responsável por popular a base de dados.
/// </summary>
public static class SgpContextSeed
{
    /// <summary>
    /// Caminho da pasta raiz da aplicação.
    /// </summary>
    private static readonly string RootFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    /// <summary>
    /// Nome da pasta que contém os arquivos de seeds.
    /// </summary>
    private const string SeedFolderName = "Seeds";

    /// <summary>
    /// Caminho da pasta que contém os arquivos de seeds.
    /// </summary>
    private static readonly string FolderPath = Path.Combine(RootFolderPath, SeedFolderName);

    /// <summary>
    /// Popula a base de dados.
    /// </summary>
    /// <param name="context">Contexto da base de dados.</param>
    public static async Task EnsureSeedDataAsync(this SgpContext context)
    {
        Guard.Against.Null(context, nameof(context));

        // NOTE: desabilitando alguns recursos do EF Core em prol da performance (BulkInsert)
        context.ChangeTracker.AutoDetectChangesEnabled = false;
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        await AddEntitiesIfNotExistsAsync<Regiao>(context, "regioes.json");
        await AddEntitiesIfNotExistsAsync<Estado>(context, "estados.json");
        await AddEntitiesIfNotExistsAsync<Cidade>(context, "cidades.json");
        await context.SaveChangesAsync();

        // NOTE: habilitando novamente o comportamento padrão do EF Core
        context.ChangeTracker.AutoDetectChangesEnabled = true;
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    private static async Task AddEntitiesIfNotExistsAsync<TEntity>(DbContext context, string fileName)
        where TEntity : class
    {
        Guard.Against.NullOrWhiteSpace(fileName, nameof(fileName));

        if (!await context.Set<TEntity>().AsNoTracking().AnyAsync())
        {
            var filePath = Path.Combine(FolderPath, fileName);
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"O arquivo de seed '{filePath}' não foi encontrado.", fileName);

            var entitiesJson = await File.ReadAllTextAsync(filePath, Encoding.UTF8);
            context.AddRange(entitiesJson.FromJson<IEnumerable<TEntity>>());
        }
    }
}