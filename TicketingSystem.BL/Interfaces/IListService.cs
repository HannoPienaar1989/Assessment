using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Shared.Models;

namespace Assessment.BL.Interfaces
{
    public interface IListService
    {
        List<ListDTO> GetListByName(string name);
    }
}
