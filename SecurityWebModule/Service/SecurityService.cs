using NLog;
using SecurityWebModule.Models;
using SecurityWebModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityWebModule.Service
{
    public class SecurityService
    {
        private GenericRepository<tbl_Security> SecurityRepository;
        Logger logger = LogManager.GetCurrentClassLogger();
        public SecurityService()
        {
            this.SecurityRepository = new GenericRepository<tbl_Security>(new SecurityDBEntities());
        }


        public List<SecurityModel> GetAll()
        {
            try
            {
                return SecurityRepository.GetAll().Select(u => new SecurityModel()
                {
                    CreatedDate = DateTime.Now,
                    Description = u.Description,
                    Id = u.Id,
                    Cusip = u.Cusip,
                    ISIN = u.ISIN,
                    RIC = u.RIC,
                    SecurityCode = u.SecurityCode,
                    Sedol = u.Sedol


                }).ToList();
            }
            catch (Exception ex)
            {

                logger.Error(ex);
                return null;

            }

        }

        public SecurityModel GetbyID(int ID)
        {
            try
            {
                tbl_Security temp = SecurityRepository.GetbyID(ID);
                SecurityModel details = new SecurityModel();
                details.Id = temp.Id;
                details.CreatedDate = temp.CreatedDate;
                details.Description = temp.Description;
                details.Cusip = temp.Cusip;
                details.ISIN = temp.ISIN;
                details.RIC = temp.RIC;
                details.SecurityCode = temp.SecurityCode;
                details.Sedol = temp.Sedol;
                return details;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
            
        }

        public void Insert(SecurityModel model)
        {
            try
            {
                tbl_Security details = new tbl_Security();

                details.CreatedDate = model.CreatedDate;
                details.Description = model.Description;
                details.Cusip = model.Cusip;
                details.ISIN = model.ISIN;
                details.RIC = model.RIC;
                details.SecurityCode = model.SecurityCode;
                details.Sedol = model.Sedol;

                SecurityRepository.Create(details);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
           
        }

        public void Update(SecurityModel model)
        {
            try
            {
                tbl_Security details = new tbl_Security();
                details.Id = model.Id;
                details.CreatedDate = DateTime.Now;
                details.Description = model.Description;
                details.Cusip = model.Cusip;
                details.ISIN = model.ISIN;
                details.RIC = model.RIC;
                details.SecurityCode = model.SecurityCode;
                details.Sedol = model.Sedol;

                SecurityRepository.Update(details);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
           
        }
        public void Delete(SecurityModel model)
        {
            try
            {
                tbl_Security details = new tbl_Security();
                details.Id = model.Id;

                details.Description = model.Description;
                details.Cusip = model.Cusip;
                details.ISIN = model.ISIN;
                details.RIC = model.RIC;
                details.SecurityCode = model.SecurityCode;
                details.Sedol = model.Sedol;

                SecurityRepository.Delete(details);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
          
        }
    }
}