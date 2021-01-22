using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL.Profiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //Destination ,Source

            this.CreateMap<IssueType, IssueTypeDTO>();
            this.CreateMap<GetInTouch, GetInTouchDTO>();
            this.CreateMap<GetInTouchDTO, GetInTouch>();
            this.CreateMap<IssueTypeDTO, IssueType>();
            this.CreateMap<IssueSeverity, IssueSeverityDTO>();
            this.CreateMap<IssueSeverityDTO, IssueSeverity>();
            this.CreateMap<ResolutionSteps, ResolutionStepsDTO>();
            this.CreateMap<ResolutionStepsDTO, ResolutionSteps>();
            this.CreateMap<ResolutionStatus, ResolutionStatusDTO>();
            this.CreateMap<ResolutionStatusDTO, ResolutionStatus>();

            this.CreateMap<Ticket, TicketDTO>()
                 .ForMember(to => to.IssueSeverity, from => from.MapFrom(f => f.IssueSeverity))
                 .ForMember(to => to.IssueType, from => from.MapFrom(f => f.IssueType))
                 .ForMember(to => to.ResolutionStatus, from => from.MapFrom(f => f.ResolutionStatus))
                 .ForMember(to => to.ResolutionSteps, from => from.MapFrom(f => f.ResolutionSteps));
            
            this.CreateMap<TicketDTO, Ticket>()
                 .ForMember(to => to.IssueSeverity, from => from.MapFrom(f => f.IssueSeverity))
                 .ForMember(to => to.IssueType, from => from.MapFrom(f => f.IssueType))
                 .ForMember(to => to.ResolutionStatus, from => from.MapFrom(f => f.ResolutionStatus))
                 .ForMember(to => to.ResolutionSteps, from => from.MapFrom(f => f.ResolutionSteps));

            this.CreateMap<IssueType, ListDTO>()
                .ForMember(to => to.text, from => from.MapFrom(f => f.Type))
                .ForMember(to => to.value, from => from.MapFrom(f => f.IssueTypeId));

            this.CreateMap<IssueSeverity, ListDTO>()
                .ForMember(to => to.text, from => from.MapFrom(f => f.Severity))
                .ForMember(to => to.value, from => from.MapFrom(f => f.IssueSeverityId));

            this.CreateMap<ResolutionStatus, ListDTO>()
               .ForMember(to => to.text, from => from.MapFrom(f => f.Status))
               .ForMember(to => to.value, from => from.MapFrom(f => f.ResolutionStatusId));

            this.CreateMap<List<IssueType>, List<ListDTO>>();
            this.CreateMap<List<IssueSeverity>, List<ListDTO>>();
            this.CreateMap<List<ResolutionStatus>, List<ListDTO>>();
        }
       
    }
}
