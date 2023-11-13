using TddXunit;
using Xunit;

namespace TestTddXunit
{
    public class UnitTest1
    {
        public Calculadora construirClasse()
        {
            string data = new DateTime().ToString();
            Calculadora calc = new Calculadora(data);

            return calc;
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(8, 5, 13)]
        public void TestSomar(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.Somar(num1, num2);
            
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 3, -1)]
        [InlineData(8, 5, 3)]
        public void TestSubtrair(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.Subtrair(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(8, 5, 40)]
        public void TestMultiplicar(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.Multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(9, 3, 3)]
        public void TestDividir(int num1, int num2, int resultado)
        {
            Calculadora calc = construirClasse();
            int resultadoCalculadora = calc.Dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TesteDividisaoPorZero()
        {
            Calculadora calc = construirClasse();
            Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
        }

        [Fact]
        public void TesteHistorico()
        {
            Calculadora calc = construirClasse();

            calc.Somar(1, 2);
            calc.Somar(2, 8);
            calc.Somar(3, 7);
            calc.Somar(4, 1);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3,lista.Count);
        }
    }
}