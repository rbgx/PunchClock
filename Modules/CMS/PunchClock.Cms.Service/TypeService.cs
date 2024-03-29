﻿using System.Collections.Generic;
using System.Linq;
using PunchClock.Cms.Contract;
using PunchClock.Cms.Model;
using PunchClock.Core.DataAccess;
using PunchClock.Domain.Model;
using PunchClock.Language.Model;
using ArticleType = PunchClock.Cms.Model.ArticleType;

namespace PunchClock.Cms.Service
{
    public class TypeService:ITypeService
    {
        public ArticleType Add(ArticleType articleType)
        {
         using (var context = new PunchClockDbContext())
                {
                    articleType.IsDeleted = false;
                    context.ArticleTypes.Add(articleType);
                    context.ArticleTypeResources.AddRange(articleType.Resources);
                    context.SaveChanges();
                }

           return articleType;
        }

        public ArticleType Update(ArticleType articleType)
        {
            using (var context = new PunchClockDbContext())
            {
                var existingType = context.ArticleTypes.FirstOrDefault(x => x.Id == articleType.Id);
                if (existingType == null) return articleType;
                existingType.Name = articleType.Name;
                existingType.Description = articleType.Description;
                existingType.IsDeleted = false;
                existingType.ModifiedById = articleType.ModifiedById;
                context.SaveChanges();
            }
            return articleType;
        }

        public AjaxResponse Delete(int id)
        {
            var response = new AjaxResponse
            {
                ResponseId = id,
                ResponseText = "Record is not deleted",
                Success = false
            };
            using (var context = new PunchClockDbContext())
            {
                var articleType = context.ArticleTypes.FirstOrDefault(x => x.Id == id);
                if (articleType == null) return response;
                articleType.IsDeleted = true;
                response.ResponseText = "Article Type is Deleted.";
                response.Success = true;
                return response;
            }
          
        }

        public ArticleType GetOneArticleType(int id)
        {
            using (var context = new PunchClockDbContext())
            {
                return context.ArticleTypes.FirstOrDefault(x => x.Id==id);
            }
        }

        public List<ArticleType> GetAllArticleTypes()
        {
            using (var context = new PunchClockDbContext())
            {
                return context.ArticleTypes.Where(x => x.IsDeleted == false).ToList();
            }
        }

        public List<ArticleType> GetArticleTypesBbyCompanyId(int companyId)
        {
            using (var context = new PunchClockDbContext())
            {
                return context.ArticleTypes.Where(x => x.IsDeleted == false && x.CompanyId == companyId).ToList();
            }
        }
    }
}
