using Alquileres.Common;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Alquileres.Logic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Alquileres.Tests
{
    public class OwnersTests
    {
        private IMapper mapper;
        private AlquileresDBContext _alquileresDBContext;
        private OwnerRepository _ownerRepository;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AlquileresDBContext>();
            optionsBuilder.UseInMemoryDatabase("alquileres");
            _alquileresDBContext = new AlquileresDBContext(optionsBuilder.Options);
            var myProfile = new Profiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);
            _ownerRepository = new OwnerRepository(_alquileresDBContext, mapper);
        }

        [Test]
        public void AddOwner_ReturnOk()
        {

            //Arrange
            OwnerViewModel owner = new OwnerViewModel();
            owner.Address = "Test address";
            owner.Photo = "Test photo";
            owner.IdOwner = Guid.NewGuid().ToString();
            owner.BirthDay = DateTime.Now;
            owner.Name = "Test Name";

            //Act
            var result = _ownerRepository.AddOwner(owner);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Split(';')[1], "1");
        }

        [Test]
        public void GetOwnerNotReturnNull()
        {

            //Act
            var result = _ownerRepository.GetOwners();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}