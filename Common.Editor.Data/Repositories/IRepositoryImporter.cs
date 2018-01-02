using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public interface IRepositoryImporter
    {
        IEnumerable<IEntity> Import(int repositoryCapacity);
    }
}