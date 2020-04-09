using System;
using Xunit;

namespace SmartText.Tests
{
    public class UnitTest1
    {
        HeaderNeoEnergia header = new HeaderNeoEnergia()
        {
            CodigoRegistro = "A",
            CodigoRemessa = "1",
            CodigoConvenio = "sdfsdfsd",
            NomeEmpresaConveniada = "CARTAO DE TODOS",
            NomeEmpresaPrestadora = "sdfsfd",
            DataGerecaoArquivo = DateTime.Now.Date.ToString("yyyyMMdd"),
            NumeroSequencialArquivo = 1,
            VersaoLayout = 5,
            TamanhoLinha = 166,
            IdentificacaoServico = "MENSALIDADE"
        };

        [Fact]
        public void Test1()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddProperty(new Property("CodigoRegistro", 1, 1, 1, Padding.Right))
                .AddProperty(new Property("CodigoRemessa", 2, 2, 2, Padding.Right))
                .AddProperty(new Property("CodigoConvenio", 3, 22, 3, Padding.Right))
                .AddProperty(new Property("NomeEmpresaConveniada", 23, 42, 4, Padding.Right))
                .AddProperty(new Property(43, 45, 5))
                .AddProperty(new Property("NomeEmpresaPrestadora", 46, 65, 6, Padding.Right))
                .AddProperty(new Property("DataGerecaoArquivo", 66, 73, 7, Padding.Right))
                .AddProperty(new Property("NumeroSequencialArquivo", 74, 79, 8, Padding.Left, '0'))
                .AddProperty(new Property("VersaoLayout", 80, 81, 9, Padding.Left, '0'))
                .AddProperty(new Property("IdentificacaoServico", 82, 98, 10, Padding.Right))
                .AddProperty(new Property(99, 150, 11))
                .AddProperty(new Property(151, 151, 12))
                .AddProperty(new Property(152, 166, 13));


            var smartText = new SmartText();

            var result = smartText.Reader.ReadContent<HeaderNeoEnergia>("fsdf sdfsdsd");

            smartText.Writer.CreateLine(header);
            smartText.Writer.CreateLine(header);
            smartText.Writer.CreateLine();
            smartText.Writer.CreateLine();

        }
    }


    class HeaderNeoEnergia
    {
        public string CodigoRegistro { get; set; }
        public string CodigoRemessa { get; set; }
        public string CodigoConvenio { get; set; }
        public string NomeEmpresaConveniada { get; set; }
        public string NomeEmpresaPrestadora { get; set; }
        public string DataGerecaoArquivo { get; set; }
        public int NumeroSequencialArquivo { get; set; }
        public int VersaoLayout { get; set; }
        public string IdentificacaoServico { get; set; }
        public int TamanhoLinha { get; internal set; }
    }

}
