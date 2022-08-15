using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Application.Common.Storage.Contracts
{
    public interface IBaseServiceStorageSettings
    {
        string ContainerName { get; }
    }
}