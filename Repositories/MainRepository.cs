using EcommerceDB.Context;
using EcommerceDB.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    //product
    //
    public class MainRepository <TModel> where TModel : class
    {
        private EcommerceDBContext Context;
        private DbSet<TModel> Table;

        public MainRepository(EcommerceDBContext _context)
        {
            Context = _context;
            Table = Context.Set<TModel>();
        }

        public IQueryable<TModel> GelList()
        {
            return Table.AsQueryable().AsNoTracking();
        }
        //(i=>i.name=="tt" || && )
        public IQueryable<TModel> Get(
            Expression<Func<TModel, bool>> filter = null,
            int pageNumber =1, int pageSize=20,
            string orderBy =null, bool isAsending=false)
        {
            var Query = Table.AsQueryable();
            //filter
            if (filter != null) 
                Query = Query.Where(filter);
            //sort
            if (!string.IsNullOrEmpty(orderBy))
                Query = Query.OrderBy(orderBy, isAsending);

            #region Pagination
            //page 1
            //size 20

            //1-1 =0 *20 
            //0....20

            //page 2
            //size 20

            //2-1 =1 *20 
            //21....40 
            #endregion
            Query = Query.Skip((pageNumber-1)*pageSize).Take(pageSize).AsNoTracking();
            return Query;

        }

        public TModel GetOne(Expression<Func<TModel, bool>> filter)
        {
            return Table.FirstOrDefault(filter);
        }

        public bool Add(TModel model) {
            try
            {                
                Table.Add(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }
        public bool Update(TModel model)
        {
            try
            {
                Table.Update(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(TModel model)
        {
            try
            {
                Table.Remove(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //result pattern
        //int . bool
        //massage

    }
}
