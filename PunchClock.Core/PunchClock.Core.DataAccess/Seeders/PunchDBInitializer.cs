﻿using System.Data.Entity.Migrations;

namespace PunchClock.Core.DataAccess.Seeders
{
    public partial class PunchDbInitializer : DbMigrationsConfiguration<PunchClockDbContext>
    {

        public PunchDbInitializer()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(PunchClockDbContext context)
        {
            #region Employment
            SeedEmploymentType(context);
            #endregion

            #region User
            SeedUserType(context);
            #endregion

            #region Holidays
            SeedHolidayType(context);
            SeedHoliday(context);
            SeedHolidayTypeHoliday(context);
            #endregion

            #region Geo
            SeedCountry(context);
            SeedState(context);
            #endregion

            #region Company
            SeedCompany(context);
            #endregion

            #region CMS



            #endregion

            #region Ticketing

            SeedStatus(context);

            #endregion

            #region Modules
            SeedModules(context);
            #endregion

            #region App Settings
            SeedAppSettings(context);
            #endregion

            base.Seed(context);
        }
    }
}