﻿using PunchClock.Model.Mapper;
using System.Web.Mvc;
using PunchClock.Core.DataAccess;
using PunchClock.Core.Implementation;
using PunchClock.Core.Models.Common;
using PunchClock.View.Model;

namespace PunchClock.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserSession UserSession;
        protected UserView OperatingUser = new UserView();
        public BaseController()
        {
            UserSession = new SessionService().GetCurrentSession(HttpContext);  
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                UserService userService = new UserService();
                OperatingUser = userService.Details(User.Identity.Name);
                var companyView = new CompanyView();
                using (var unitOfWork = new UnitOfWork())
                {
                    var company = unitOfWork.CompanyRepository.GetById(OperatingUser.CompanyId);
                    new Map().DomainToView(companyView, company);
                }
                OperatingUser.Company = companyView;
            }
            base.OnActionExecuting(filterContext);
        }
        // ReSharper disable once RedundantOverriddenMember
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
