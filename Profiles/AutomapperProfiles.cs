using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.DTOs;

namespace LibraryAPI.Profiles {
    public class AutomapperProfiles : Profile {
        public AutomapperProfiles() {
            CreateMap<CreateUserAccount, UserAccount>();
            CreateMap<UserAccount, UserAccountDTO>().ForMember(dto => dto.Groups, o => o.MapFrom(UserDTOMap));
            //CreateMap<UserAccountDTO, UserAccount>();
            CreateMap<CreateGroup, Group>();
            CreateMap<Group, GroupDTO>().ReverseMap();
        }

        private List<GroupDTO> UserDTOMap(UserAccount user, UserAccountDTO dto) {
            List<GroupDTO> groups = new List<GroupDTO>();

            if(user.Groups == null)
                return groups;

            foreach (var g in user.Groups) {
                groups.Add(new GroupDTO {
                    Id = g.GroupId,
                    Name = g.Group.Name
                });
            }

            return groups;
        }
    }
}