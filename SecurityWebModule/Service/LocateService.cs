using SecurityWebModule.Models;
using SecurityWebModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityWebModule.Service
{
    public class LocateService
    {
        private GenericRepository<tbl_Locates> LocateRepository;
        public LocateService()
        {
            this.LocateRepository = new GenericRepository<tbl_Locates>(new SecurityDBEntities());
        }

        public List<LocateModel> GetAll()
        {
            return LocateRepository.GetAll().Select(u => new LocateModel()
            {
                CreatedDate=u.CreatedDate,
                 Description=u.Description,
                  Id=u.Id,
                   IsPublic=u.IsPublic,
                    Name=u.Name,
                   

            }).ToList();
        }

        public LocateModel GetbyID(int ID)
        {
            tbl_Locates temp = LocateRepository.GetbyID(ID);
            LocateModel details = new LocateModel();
             details.Id=temp.Id;
            details.CreatedDate=temp.CreatedDate;
            details.Description=temp.Description;
            details.IsPublic=temp.IsPublic;
            details.Name=temp.Name;
            return details;
        }

        public void Insert(LocateModel model)
        {
            tbl_Locates details = new tbl_Locates();
            
            details.CreatedDate = DateTime.Now;
            details.Description = model.Description;
            details.IsPublic = model.IsPublic;
            details.Name = model.Name;
            LocateRepository.Create(details);
        }

        public void Update(LocateModel model)
        {

            tbl_Locates details = new tbl_Locates();
            details.Id=model.Id;
            details.CreatedDate = DateTime.Now;
            details.Description = model.Description;
            details.IsPublic = model.IsPublic;
            details.Name = model.Name;
            LocateRepository.Update(details);
        }
        public void Delete(LocateModel model)
        {
            tbl_Locates details = new tbl_Locates();
            details.Id = model.Id;
            
            details.Description = model.Description;
            details.IsPublic = model.IsPublic;
            details.Name = model.Name;
            LocateRepository.Delete(details);
        }


        }
}