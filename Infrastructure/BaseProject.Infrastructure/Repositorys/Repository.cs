using System;
using BaseProject.Domain.EntityModels.BaseModels;
using BaseProject.Domain.Enums;
using BaseProject.Persistence.BaseContextes;
using System.Linq.Expressions;
using BaseProject.Application.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Repositorys
{
	public class Repository: IRepository
    {
        private readonly BaseDataContext context;
        private readonly Guid? userId;        

        public Repository(BaseDataContext _context, Guid? _userId)
        {
            context = _context;
            userId = _userId;
        }

        public async Task<T> Add<T>(T model) where T : BaseEntityModel
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.LastModifiedDate = DateTime.Now;
                if (userId != null)
                {
                    model.CreatedBy = userId;
                    model.LastModifiedBy = userId;
                }
                await context.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseEntityModel
        {
            try
            {
                foreach (var item in models)
                {
                    item.CreatedDate = DateTime.Now;
                    item.LastModifiedDate = DateTime.Now;
                    if (userId != null)
                    {
                        item.CreatedBy = userId;
                        item.LastModifiedBy = userId;
                    }
                }
                await context.AddRangeAsync(models);
                return models;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<T>> AddRange<T>(IQueryable<T> models) where T : BaseEntityModel
        {
            try
            {
                foreach (var item in models)
                {
                    item.CreatedDate = DateTime.Now;
                    item.LastModifiedDate = DateTime.Now;
                    if (userId != null)
                    {
                        item.CreatedBy = userId;
                        item.LastModifiedBy = userId;
                    }
                }
                await context.AddRangeAsync(models);
                return models;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Any<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return context.Set<T>().Any(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool AnyNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeleted<T>(expression).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AnyNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeletedAndActive<T>(expression).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CheckAppKey(string Key)
        {
            throw new NotImplementedException();
        }

        public int Count<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeleted<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeleted<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeletedAndActive<T>(expression).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete<T>(Guid ID) where T : BaseEntityModel
        {
            try
            {
                var model = await GetByID<T>(ID);
                await Delete<T>(model);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete<T>(T model) where T : BaseEntityModel
        {
            try
            {
                model.ObjectStatus = ObjectStatus.Deleted;
                model.Status = Status.Pasive;
                await Update<T>(model);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> DeleteRange<T>(IEnumerable<T> models) where T : BaseEntityModel
        {
            try
            {
                foreach (var item in models)
                {
                    await Delete(item);
                }
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return await GetNonDeleted<T>(t => true).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindNonDeletedActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return await GetNonDeletedAndActive<T>(t => true).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return context.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByID<T>(Guid ID) where T : BaseEntityModel
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(t => t.ID == ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return Get<T>(t => t.ObjectStatus == ObjectStatus.NonDeleted).Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel
        {
            try
            {
                return GetNonDeleted<T>(t => t.Status == Status.Active).Where(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetPageCount<T>(Expression<Func<T, bool>> expression, int pageSize) where T : BaseEntityModel
        {
            try
            {
                var count = context.Set<T>().Count(expression);
                return (count / pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetPageCount<T>(int pageSize) where T : BaseEntityModel
        {
            try
            {
                return GetPageCount<T>(t => t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == Status.Active, pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetPageCount<T>(IQueryable<T> models, int pageSize) where T : BaseEntityModel
        {
            try
            {
                var count = models.Count();
                return (count / pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetPaginate<T>(IQueryable<T> models, int pageCount, int pageSize) where T : BaseEntityModel
        {
            try
            {
                return models.Skip<T>(pageCount * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Guid> Remove<T>(Guid ID) where T : BaseEntityModel
        {
            try
            {
                var model = await GetByID<T>(ID);
                context.Remove(model);
                return ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveRange<T>(IEnumerable<T> models) where T : BaseEntityModel
        {
            try
            {
                context.RemoveRange(models);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TResult SelectByID<T, TResult>(int ID, Expression<Func<T, TResult>> selection) where T : BaseEntityModel
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(T Entitiy) where T : BaseEntityModel
        {
            try
            {
                Entitiy.LastModifiedDate = DateTime.Now;
                if (userId != null)
                    Entitiy.LastModifiedBy = userId;
                context.Update(Entitiy);
                return Entitiy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> UpdateRange<T>(IEnumerable<T> models) where T : BaseEntityModel
        {
            try
            {
                foreach (var item in models)
                {
                    item.LastModifiedDate = DateTime.Now;
                    if (userId != null)
                        item.LastModifiedBy = userId;
                    item.Status = Status.Active;
                }
                context.UpdateRange(models);
                return models;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

