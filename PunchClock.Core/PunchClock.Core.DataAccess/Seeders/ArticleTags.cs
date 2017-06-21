﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PunchClock.Cms.Model;
using PunchClock.Language.Model;

namespace PunchClock.Core.DataAccess.Seeders
{
    public partial class PunchDbInitializer
    {
        private void SeedArticleTags(PunchClockDbContext context)
        {
            var articleTags = new List<ArticleTag>
            {
                new ArticleTag
                {
                   Name = "Home",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = null,
                    ModifiedDate = DateTime.Now,
                    CompanyId = 1
                },
                new ArticleTag
                {
                    Name = "Social",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = null,
                    ModifiedDate = DateTime.Now,
                       CompanyId = 1
                }
                ,
                new ArticleTag
                {
                    Name = "Fashion",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = null,
                    ModifiedDate = DateTime.Now,
                       CompanyId = 1
                }
                 ,
                new ArticleTag
                {
                    Name = "Technology",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = null,
                    ModifiedDate = DateTime.Now,
                       CompanyId = 1
                }
            };
            foreach (var tag in articleTags)
            {
                context.ArticleTags.AddOrUpdate(tag);
             
            }
        }


    }
}