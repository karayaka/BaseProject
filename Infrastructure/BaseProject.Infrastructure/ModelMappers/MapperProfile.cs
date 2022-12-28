using System;
using AutoMapper;
using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;

namespace BaseProject.Infrastructure.ModelMappers
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<SessionModel, UserModel>().ReverseMap();
		}
	}
}

