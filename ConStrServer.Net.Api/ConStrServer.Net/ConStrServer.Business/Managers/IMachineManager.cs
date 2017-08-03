using System.Collections.Generic;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public interface IMachineManager
    {
        Machine CreateMachine(MachineModel newMachine);
        Machine EditMachine(MachineModel editMachine);
        Machine DeleteMachine(int MachineId);
        Machine GetMachineById(int MachineId);
        List<Machine> GetAllMachines();
    }
}