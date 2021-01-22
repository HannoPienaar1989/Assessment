using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public ListRepository(DBContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ListDTO> GetListByName(string name)
        {
            switch (name.ToLower().Trim()) {
                case "type":
                    {
                        return _mapper.Map<List<ListDTO>>(_dbContext.IssueTypes);
                    }
                case "severity":
                    {
                        return _mapper.Map<List<ListDTO>>(_dbContext.IssueSeverity);
                    }
                case "status":
                    {
                        return _mapper.Map<List<ListDTO>>(_dbContext.ResolutionStatus);
                    }
                default: {
                        return new List<ListDTO>();
                    }
            }
        }
    }
}
