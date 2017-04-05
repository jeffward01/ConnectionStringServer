using System.Collections.Generic;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public interface IEnvironmetRepository
    {
        Environment AddEnvironment(Environment environment);
        Environment EditEnvironment(Environment environment);
        List<Environment> GetAllEnvironmentsForProjectId(int projectId);
        Environment GetEnvironmentById(int EnvironmentId);
    }
}