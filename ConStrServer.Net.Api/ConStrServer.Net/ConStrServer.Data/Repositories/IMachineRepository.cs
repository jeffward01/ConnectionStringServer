using System.Collections.Generic;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public interface IMachineRepository
    {
        Machine Create(Machine Machine);
        Machine Edit(Machine Machine);
        Machine Delete(int machineId);
        List<Machine> GetAll();
        Machine GetByMachineId(int MachineId);
        List<Machine> GetAllMachinesByEnvironmentId(int machineid);
    }
}