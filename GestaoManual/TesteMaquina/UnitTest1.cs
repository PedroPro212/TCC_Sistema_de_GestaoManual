using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteMaquina
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 0; i < 10; i++)
            {
                GestaoManual.Classes.Maquina maquina = new GestaoManual.Classes.Maquina();
                Random rNome = new Random();
                maquina.Nome = rNome.Next(999999).ToString();
                maquina.idSetor = rNome.Next(6)+1;

                var teste = new GestaoManual.Negocio.Maquina().Create(maquina);
                Assert.AreEqual(true, teste);
            }
        }
    }
}
