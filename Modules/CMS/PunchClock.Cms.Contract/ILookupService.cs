﻿using System.Collections.Generic;
using PunchClock.Cms.Model;
using Type = PunchClock.Cms.Model.Type;

namespace PunchClock.Cms.Contract
{
  public  interface ILookupService
  {
      Article GetOneArticle(int articleId);
      IEnumerable<Article> GetManyArticles();
      IEnumerable<Comment> GetCommentsByArticleId(int artcileId);
      IEnumerable<Tag> GeTags();
      IEnumerable<Type> GetTypes();
      List<Category> GetAllCategories();
  }
}
