﻿using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using PunchClock.Core.DataAccess;

namespace PunchClock.Core.Implementation
{
    public class SiteService
    {
        public List<SelectListItem> GetEmploymentTypes(int companyId)
        {
            List<SelectListItem> employeeTypes;
            using (var unitOfWOrk = new UnitOfWork())
            {
                employeeTypes = unitOfWOrk.EmployeeTypeRepository.Get().Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            }
            return employeeTypes;
        }
    }
}