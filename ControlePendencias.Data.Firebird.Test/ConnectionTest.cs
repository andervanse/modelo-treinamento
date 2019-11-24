using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlePendencias.Data.Firebird.Test
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void Conexao_test()
        {
            using (FirebirdContext ctx = new FirebirdContext())
            {
                ctx.Database.Log = (str) =>
                {
                    Console.WriteLine(str);
                };
            }
        }
    }
}
