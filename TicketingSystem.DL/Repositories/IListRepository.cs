using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL.Repositories
{
    public interface IListRepository
    {
        List<ListDTO> GetListByName(string name);
    }
}
