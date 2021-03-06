﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public class MachineManager : IMachineManager
    {
        private readonly IMachineRepository _MachineRepository;
        private readonly IConnectionStringRepository _connectionStringRepository;

        public MachineManager(IMachineRepository MachineRepository, IConnectionStringRepository connectionStringRepository)
        {
            _connectionStringRepository = connectionStringRepository;
            _MachineRepository = MachineRepository;
        }

        public Machine CreateMachine(MachineModel newMachine)
        {
            var Machine = MachineUtil.CastToDbo(newMachine);

            var connectionStrings = Machine.ConnectionStrings;
            Machine.ConnectionStrings = null;
            var savedMachine = _MachineRepository.Create(Machine);

            if (connectionStrings != null)
            {
                foreach (var conStr in connectionStrings)
                {
                    conStr.MachineId = savedMachine.MachineId;
                    _connectionStringRepository.Create(conStr);
                }
            }
            return _MachineRepository.GetByMachineId(savedMachine.MachineId);
        }

        public Machine EditMachine(MachineModel editMachine)
        {
            var Machine = MachineUtil.CastToDbo(editMachine);

            var connectionStrings = Machine.ConnectionStrings;
            Machine.ConnectionStrings = null;
            var updatedMachine = _MachineRepository.Edit(Machine);


            if (connectionStrings != null)
            {
                foreach (var conString in connectionStrings)
                {
                    if (conString.ConnectionStringId != 0)
                    {
                        _connectionStringRepository.Edit(conString);
                    }
                    else
                    {
                        conString.MachineId = updatedMachine.MachineId;
                        _connectionStringRepository.Create(conString);
                    }

                }
            }
            //delete all deleted connectionStrings
            var envsToSave = connectionStrings.Select(_ => _.ConnectionStringId);
            var allEnvIds = _connectionStringRepository.GetAllConStrIdsForMachine(updatedMachine.MachineId);
            var idsToDelete = allEnvIds.Except(envsToSave).ToList();
            foreach (var id in idsToDelete)
            {
                _connectionStringRepository.Delete(id);
            }
            return _MachineRepository.GetByMachineId(updatedMachine.MachineId);
        }

        public Machine DeleteMachine(int MachineId)
        {
            return _MachineRepository.Delete(MachineId);
        }

        public Machine GetMachineById(int MachineId)
        {
            return _MachineRepository.GetByMachineId(MachineId);
        }

        public List<Machine> GetAllMachines()
        {
            return _MachineRepository.GetAll();
        }
    }
}
