//using Microsoft.EntityFrameworkCore;
//using ProjectXCore.Data;
//using ProjectXCore.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProjectXCore.Repository
//{
//    public class WorkerRepository<T> : IRepository<T> where T : BaseEntity
//    {
//        private readonly ProjectContext context;
//        private DbSet<T> entities;

//        public WorkerRepository (ProjectContext context)
//        {
//            this.context = context;
//            entities = context.Set<T>();
//        }

//        //delete
//        public void Delete(T entity)
//        {
//            entities.Remove(entity);
//            context.SaveChanges();

//        }

//        //get
//        public T Get(int id)
//        {
//            return entities.FirstOrDefault(x => x.Id == id);
//        }

//        //get all
//        public ICollection<T> GetAll()
//        {
//            return entities.ToList();     
//        }

//        //post
//        public void Insert(T entity)
//        { 
//            entities.Add(entity);
//            context.SaveChanges();
//        }

//        //put
//        public void Update(T entity)
//        {
//            entities.Update(entity);
//            context.SaveChanges();
//        }

//        public bool CheckMailLogin(T entity)
//        {
//            return true;
//        }
//    }
//}
