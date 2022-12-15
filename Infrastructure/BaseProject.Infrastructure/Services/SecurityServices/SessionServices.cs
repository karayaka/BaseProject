using BaseProject.Application.Services.SecurityServices;
using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseProject.Infrastructure.Services.SecurityServices
{
    public class SessionServices : ISessionServices
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public SessionServices(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public T GetSession<T>(string key)
        {
            try
            {

                var session = httpContextAccessor.HttpContext.Session;
                Byte[] ss;
                var ctry = session.TryGetValue(key, out ss);
                if (!ctry)
                    return default(T);
                if (ss == null)
                    return default(T);
                return FromByteArray<T>(ss);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SessionModel GetUser()
        {
            try
            {
                return GetSession<SessionModel>("login");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetSession<T>(string key, T model)
        {
            try
            {
                var ss = ToByteArray<T>(model);
                httpContextAccessor.HttpContext.Session.Set(key, ss);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SetUser(UserModel user)
        {
            try
            {
                var sesionmodel = new SessionModel()
                {
                    //CustomerID = user.CustomerID,
                    ID = user.ID,
                    ProfileImage = user.ProfileImage,
                    Name = user.Name,
                    Surname = user.Surname,
                    //UserType = user.UserType,
                };
                SetSession("login", sesionmodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SessionModel GetInjection()
        {
            try
            {
                var user = new SessionModel();
                user.ID = Guid.Empty;

                if (httpContextAccessor.HttpContext == null)
                {
                    user.ID = Guid.Empty;
                    return user;
                }
                var val = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

                if (val != null)
                {
                    //customer tarafına bakılacak
                    //var val2 = httpContextAccessor.HttpContext.User.FindFirst("CustomerID");

                    //if (val2 != null)
                    //    user.CustomerID = Convert.ToInt32(val2.Value);
                    //datacontext ile çekilebilir!!

                    if (val != null)
                        user.ID = Guid.Parse(val.Value);
                }
                else
                {

                    var usr = GetUser();
                    if (usr != null)
                        user = usr;
                }
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public byte[] ToByteArray<T>(T obj)
        {
            var objToString = JsonSerializer.Serialize(obj);
            return Encoding.ASCII.GetBytes(objToString);
        }

        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            var stringObj = Encoding.ASCII.GetString(data);
            return JsonSerializer.Deserialize<T>(stringObj);
        }

        public void CleanSession()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
