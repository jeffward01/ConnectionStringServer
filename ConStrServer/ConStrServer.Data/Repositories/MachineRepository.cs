using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        public Machine AddMachine(Machine machine)
        {
            using (var db = new DataContext())
            {
                db.Machines.Add(machine);
                db.SaveChanges();
                return machine;
            }
        }

        public Machine EditMachine(Machine machine)
        {
            using (var db = new DataContext())
            {
                db.Entry(machine).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return machine;
            }
        }

        public List<Machine> GetAllMachinesForEnvironmentId(int envionmentId)

        {
            using (var db = new DataContext())
            {
                return db.Machines.Where(_ => _.EnvironmentId == envionmentId && _.DeleteDateTime == null).ToList();
            }
        }



        public Machine GetMachineById(int machineId)
        {
            using (var db = new DataContext())
            {
                return db.Machines.FirstOrDefault(_ => _.MachineId == machineId && _.DeleteDateTime == null);
            }
        }
    }
}