using ProcessesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessesAPI.Model
{
    public class StartupBD
    {
        public StartupBD(MachineContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.Machine.Any())
            {
                return;
            }
            var processes = new MachineModel[]
            {
              new MachineModel{ machineName = "sdfgfgd"},
              new MachineModel{ machineName = "dfgs"},
            };
            foreach (MachineModel p in processes)
            {
                context.Machine.Add(p);
            }
            context.SaveChanges();
        }
    }
}
