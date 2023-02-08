using Entities;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Repository;
using Repository.BussinesRules;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Services.Controllers;

namespace NUnitTestTravelServices
{
    public class Tests
    {
        IAuthorsRepositories _authorsRepositories;
        AuthorsController controller;
        readonly TravelContext db;
        [SetUp]
        public void Setup()
        {
            _authorsRepositories = new AuthorsLogic(db);
            controller = new AuthorsController(_authorsRepositories);
        }

        [Test]
        public async Task Test1()
        {
            // Act
            var result = await controller.GetAuthors();

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }

        [Test]
        public async Task TestNewAuthor()
        {
            Authors authors = new Authors();
            authors.name = "Miguel";
            authors.surnames = "De Cervantes";

            // Act
            var result = await controller.PostAuthorsAsync(authors);

            // Assert
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}