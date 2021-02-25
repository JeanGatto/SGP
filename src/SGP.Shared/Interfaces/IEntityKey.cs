﻿namespace SGP.Shared.Interfaces
{
    /// <summary>
    ///  Chave da Entidade.
    /// </summary>
    /// <typeparam name="TKey">O tipo da chave.</typeparam>
    public interface IEntityKey<TKey>
    {
        /// <summary>
        /// Chave (ID)
        /// </summary>
        TKey Id { get; }
    }
}