using ProcessesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessesAPI.Model
{
    public class StartupBD
    {
        public StartupBD(FaixaContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.FaixaObject.Any())
            {
                return;
            }
            
            var faixa1 = new Faixa();
            faixa1.id = 1234567;
            faixa1.cor = "branca";

            context.FaixaObject.Add(faixa1);
            
            context.SaveChanges();
        }
    }
}
