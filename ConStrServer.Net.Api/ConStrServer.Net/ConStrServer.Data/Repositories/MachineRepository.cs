using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public class MachineRepository
    {
        public Machine Create(Machine Machine)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(Machine).State = EntityState.Added;
                context.SaveChanges();
                return Machine;
            }
        }
        public Machine Edit(Machine Machine)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(Machine).State = EntityState.Modified;
                context.SaveChanges();
                return Machine;
            }
        }
        public Machine Delete(int machineId)
        {
            using (var context = new ConStrContext())
            {
                var machine = context.Machines.Find(machineId);
                context.Entry(machine).State = EntityState.Deleted;
                context.SaveChanges();
                return machine;
            }
        }

        public List<Machine> GetAll()
        {
            using (var context = new ConStrContext())
            {
                return context.Machines.Include("Projects")
                    .Include("Projects.ConnectionStrings").ToList();
            }
        }

        public Machine GetByMachineId(int MachineId)
        {
            using (var context = new ConStrContext())
            {
                return context.Machines
                    .Include("Projects")
                    .Include("Projects.ConnectionStrings")
                    .FirstOrDefault(_ => _.MachineId == MachineId);
            }
        }

        public List<Machine> GetAllMachinesByEnvironmentId(int machineid)
        {
            using (var context = new ConStrContext())
            {
                return context.Machines.Include("Projects")
                    .Include("Projects.ConnectionStrings").Where(_ => _.MachineId == machineid).ToList();
            }
        }
    }
}
