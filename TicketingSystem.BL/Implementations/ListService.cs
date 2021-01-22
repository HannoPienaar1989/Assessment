using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Assessment.BL.Interfaces;
using Assessment.DL.Entities;
using Assessment.DL.Repositories;
using Assessment.Shared.Models;

namespace Assessment.BL.Implementations
{
    public class ListService : IListService
    {
        private IListRepository _listRepository;
        private readonly IMapper _mapper;

        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public List<ListDTO> GetListByName(string name)
        {
            return _listRepository.GetListByName(name);
        }

    }
}
