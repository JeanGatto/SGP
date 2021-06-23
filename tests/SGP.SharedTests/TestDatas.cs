using Xunit;

namespace SGP.SharedTests
{
    public static class TestDatas
    {
        /// <summary>
        /// T1 = Nome da região,
        /// T2 = Total de estados da região
        /// </summary>
        public class FiltrarEstadoPorRegiao : TheoryData<string, int>
        {
            public FiltrarEstadoPorRegiao()
            {
                Add("Nordeste", 9);
                Add("Sudeste", 4);
                Add("Sul", 3);
                Add("Centro-Oeste", 4);
                Add("Norte", 7);
            }
        }

        /// <summary>
        /// T1 = IBGE do município,
        /// T2 = Nome do município,
        /// T3 = Sigla do estado (UF),
        /// T4 = Região
        /// </summary>
        public class FiltrarPorIbge : TheoryData<int, string, string, string>
        {
            public FiltrarPorIbge()
            {
                Add(3550308, "São Paulo", "SP", "Sudeste");
                Add(3506003, "Bauru", "SP", "Sudeste");
                Add(3557105, "Votuporanga", "SP", "Sudeste");
                Add(3304557, "Rio de Janeiro", "RJ", "Sudeste");
                Add(4205407, "Florianópolis", "SC", "Sul");
            }
        }

        /// <summary>
        /// T1 = Sigla do estado (UF),
        /// T2 = Total de cidades pertencentes ao estado
        /// </summary>
        public class FiltrarPorUf : TheoryData<string, int>
        {
            public FiltrarPorUf()
            {
                Add("AC", 22);  // Acre
                Add("AL", 102); // Alagoas
                Add("AM", 62);  // Amazonas
                Add("AP", 16);  // Amapá
                Add("BA", 417); // Bahia
                Add("CE", 184); // Ceará
                Add("ES", 78);  // Espírito Santo
                Add("GO", 246); // Goiás
                Add("MA", 217); // Maranhão
                Add("MG", 853); // Minas Gerais
                Add("MS", 79);  // Mato Grosso do Sul
                Add("MT", 141); // Mato Grosso
                Add("PA", 144); // Pará
                Add("PB", 223); // Paraíba
                Add("PE", 185); // Pernambuco
                Add("PI", 224); // Piauí
                Add("PR", 399); // Paraná
                Add("RJ", 92);  // Rio de Janeiro
                Add("RN", 167); // Rio Grande do Norte
                Add("RO", 52);  // Rondônia
                Add("RR", 15);  // Roraima
                Add("RS", 497); // Rio Grande do Sul
                Add("SC", 295); // Santa Catarina
                Add("SE", 75);  // Sergipe
                Add("SP", 645); // São Paulo
                Add("TO", 139); // Tocantins
            }
        }
    }
}
