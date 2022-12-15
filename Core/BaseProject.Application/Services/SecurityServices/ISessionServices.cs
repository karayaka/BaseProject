using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Services.SecurityServices
{
    public interface ISessionServices
    {
        void SetSession<T>(string key, T model);

        T GetSession<T>(string key);

        SessionModel GetUser();

        void SetUser(UserModel user);

        SessionModel GetInjection();

        void CleanSession();
    }
}
