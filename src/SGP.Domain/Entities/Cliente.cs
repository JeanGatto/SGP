﻿using SGP.Domain.Enums;
using SGP.Domain.ValueObjects;
using SGP.Shared.Entities;
using SGP.Shared.Interfaces;

namespace SGP.Domain.Entities
{
    public class Cliente : BaseEntity, IAggregateRoot
    {
        public Cliente(string nome, CadastroPessoaFisica cpf, Sexo sexo, DataNascimento dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            DataCadastro = DataCadastro.Agora();
        }

        private Cliente()
        {
        }

        public string Nome { get; private set; }
        public CadastroPessoaFisica CPF { get; private set; }
        public Sexo Sexo { get; private set; }
        public DataNascimento DataNascimento { get; private set; }
        public DataCadastro DataCadastro { get; private set; }
    }
}