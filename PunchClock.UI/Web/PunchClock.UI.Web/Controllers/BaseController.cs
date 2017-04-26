﻿
using PunchClock.Implementation;
using PunchClock.Model.Mapper;
using PunchClock.Objects.Core;
using System.Web.Mvc;

namespace PunchClock.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserSession UserUserSession = new UserSession();
        public View.Model.UserView operatingUser = new View.Model.UserView();
        public BaseController()
        {
            SessionService session = new SessionService();
            UserUserSession = session.GetCurrentSession(HttpContext);  
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                UserService userService = new UserService();
                operatingUser = userService.Details(User.Identity.Name);
                var companyView = new View.Model.CompanyView();
                using (var unitOfWork = new DAL.UnitOfWork())
                {
                    var company = unitOfWork.CompanyRepository.GetById(operatingUser.CompanyId);
                    new Map().DomainToView(companyView, company);
                }
                operatingUser.Company = companyView;
            }
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
