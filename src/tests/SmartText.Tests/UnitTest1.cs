using SmartText.Builder;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartText.Tests
{
    public class UnitTest1
    {
        private readonly HeaderTest _header = new HeaderTest()
        {
            CodigoRegistro = "A",
            CodigoRemessa = "1",
            CodigoConvenio = "sdfsdfsd            ",
            NomeEmpresaConveniada = "CARTAO DE TODOS     ",
            NomeEmpresaPrestadora = "sdfsfd              ",
            DataGerecaoArquivo = DateTime.Now.Date.ToString("yyyyMMdd"),
            NumeroSequencialArquivo = 1,
            VersaoLayout = 5,
            TamanhoLinha = 166,
            IdentificacaoServico = "MENSALIDADE      "
        };

        private SmartText _smartText;

        private readonly string _headerLine = @"A1sdfsdfsd            CARTAO DE TODOS        sdfsfd              2020052800000105MENSALIDADE      166                                                                 ";

        public UnitTest1()
        {
            var configuration = ConfigurationBuilder.Create()
                .UseFileReader(new MyFileReader())
                .AutoLoadFile(false)
                .AddSection<HeaderTest>(config =>
                    config
                    .WithProperty(p => p.CodigoRegistro, 1, 1, 1, Padding.Right)
                    .WithProperty(p => p.CodigoRemessa, 2, 2, 2, Padding.Right)
                    .WithProperty(p => p.CodigoConvenio, 3, 22, 3, Padding.Right)
                    .WithProperty(p => p.NomeEmpresaConveniada, 23, 42, 4, Padding.Right)
                    .WithProperty(new Property(43, 45, 5))
                    .WithProperty(p => p.NomeEmpresaPrestadora, 46, 65, 6, Padding.Right)
                    .WithProperty(p => p.DataGerecaoArquivo, 66, 73, 7, Padding.Right)
                    .WithProperty(p => p.NumeroSequencialArquivo, 74, 79, 8, Padding.Left, '0')
                    .WithProperty(p => p.VersaoLayout, 80, 81, 9, Padding.Left, '0')
                    .WithProperty(p => p.IdentificacaoServico, 82, 98, 10, Padding.Right)
                    .WithProperty(p => p.TamanhoLinha, 99, 102, 11, Padding.Right)
                    .WithProperty(new Property(103, 150, 11))
                    .WithProperty(new Property(151, 151, 12))
                    .WithProperty(new Property(152, 166, 13))
               ).Build();

            _smartText = new SmartText(configuration);
        }

        [Fact]
        public void WriterTest()
        {
            var resultSection = _smartText.Writer<HeaderTest>().WriteToString(new HeaderTest[] { _header });

            Assert.Equal(_headerLine, resultSection);
        }

        [Fact]
        public void ReaderTest()
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.Default.GetBytes(_headerLine));
            MyFileReader.SetStream(memoryStream);

            var headerResult = _smartText.Reader<HeaderTest>().ReadSection();

            Assert.Equal(_header, headerResult.ElementAt(0));
        }
    }

    class HeaderTest
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as HeaderTest;
            return string.Equals(CodigoRegistro, other.CodigoRegistro)
                && string.Equals(CodigoRemessa, other.CodigoRemessa)
                && string.Equals(NomeEmpresaConveniada, other.NomeEmpresaConveniada)
                && string.Equals(NomeEmpresaPrestadora, other.NomeEmpresaPrestadora)
                && string.Equals(DataGerecaoArquivo, other.DataGerecaoArquivo)
                && int.Equals(NumeroSequencialArquivo, other.NumeroSequencialArquivo)
                && int.Equals(VersaoLayout, other.VersaoLayout)
                && string.Equals(IdentificacaoServico, other.IdentificacaoServico)
                && int.Equals(TamanhoLinha, other.TamanhoLinha);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class MyFileReader : IContentReader
    {
        private static MemoryStream _stream;

        private string[] ReadFromMemoryStream()
        {
            _stream.TryGetBuffer(out var buffer);
            var arquivo = Encoding.Default.GetString(buffer);
            var resultado = new string[] { };
            if (arquivo.Contains("\r\n"))
            {
                resultado = arquivo.Split("\r\n");
            }
            else
            {
                resultado = arquivo.Split("\n");
            }
            return resultado;
        }

        public string[] ReadAllLines()
        {
            return ReadFromMemoryStream();
        }

        public Task<string[]> ReadAllLinesAsync()
        {
            return new Task<string[]>(() => ReadFromMemoryStream());
        }

        public static void SetStream(MemoryStream newStream)
        {
            _stream = newStream;
        }
    }

}
