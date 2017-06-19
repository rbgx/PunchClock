﻿using NUnit.Framework;
using PunchClock.Cms.Contract;
using PunchClock.Cms.Model;
using PunchClock.Cms.Service;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PunchClock.Cms.Testing
{
   public class TypeServiceTest
   {
       private ITypeService _tagService;
       [SetUp]
        public void Initialize()
        {
            _tagService = new TypeService();
        }

        [Test]
        public void Add()
        {
            var type = new Type()
            {
                Description = "Test data",
                Name = "Test",
                LastModifiedBy = 1
            };
            var result = _tagService.Add(type);
            Assert.IsNotNull(result);
        }
        [Test]
        public void Update()
        {
            var type = new Type()
            {
                Id=1,
                Description = "Test11 data",
                Name = "Tests",
                LastModifiedBy = 1
            };
            var result = _tagService.Update(type);
            Assert.IsNotNull(result);
        }

        [TestCase(2)]
        public void Delete(int id)
        {
           var result = _tagService.Delete(id);
            Assert.IsTrue(result.Success);
        }
    }
}