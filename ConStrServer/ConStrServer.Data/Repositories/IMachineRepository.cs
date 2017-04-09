using System.Collections.Generic;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public interface IMachineRepository
    {
        Machine AddMachine(Machine machine);
        Machine EditMachine(Machine machine);
        List<Machine> GetAllMachinesForEnvironmentId(int envionmentId);
        Machine GetMachineById(int machineId);
    }
}