using DescubraOAssassino.Domain.Arguments.Jogo;
using DescubraOAssassino.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DescubraOAssassino.Domain.Tests
{
    [TestClass]
    public class JogoTests
    {
        [TestMethod]
        public void TestRespostaCertaDoJogo()
        {
            var teoriaRequest = new TeoriaRequest(arma: 1, local: 1, suspeito: 1);

            var jogo = CreateJogo();

            Assert.AreEqual(EnumSituacaoJogo.TeoriaCorreta, jogo.ChecarTeoria(teoriaRequest));
        }

        [TestMethod]
        public void TestRespostaErradaSuspeitoDoJogo()
        {
            var teoriaRequest = new TeoriaRequest(arma: 1, local: 1, suspeito: 2);

            var jogo = CreateJogo();

            Assert.AreEqual(EnumSituacaoJogo.SuspeitoIncorreto, jogo.ChecarTeoria(teoriaRequest));
        }

        [TestMethod]
        public void TestRespostaErradaLocalDoJogo()
        {
            var teoriaRequest = new TeoriaRequest(arma: 1, local: 2, suspeito: 1);

            var jogo = CreateJogo();

            Assert.AreEqual(EnumSituacaoJogo.LocalIncorreto, jogo.ChecarTeoria(teoriaRequest));
        }

        [TestMethod]
        public void TestRespostaErradaArmaDoJogo()
        {
            var teoriaRequest = new TeoriaRequest(arma: 2, local: 1, suspeito: 1);

            var jogo = CreateJogo();

            Assert.AreEqual(EnumSituacaoJogo.ArmaIncorreta, jogo.ChecarTeoria(teoriaRequest));
        }

        [TestMethod]
        public void TestRespostaErradaMaisDeUmDoJogo()
        {
            var teoriaRequest = new TeoriaRequest(arma: 2, local: 2, suspeito: 1);

            var jogo = CreateJogo();

            Assert.AreNotEqual(EnumSituacaoJogo.SuspeitoIncorreto, jogo.ChecarTeoria(teoriaRequest));
            Assert.AreNotEqual(EnumSituacaoJogo.TeoriaCorreta, jogo.ChecarTeoria(teoriaRequest));
        }

        private Crime CreateJogo()
        {
            var arma = new Arma(1, "Cajado Devastador");
            var local = new Local(1, "Etérnia");
            var suspeito = new Suspeito(1, "Esqueleto");

            var jogo = new Crime(suspeito, local, arma);

            return jogo;
        }
    }
}
