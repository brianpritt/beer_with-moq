using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bar.Models;
using Xunit;
using Bar.Controllers;
using Microsoft.AspNetCore.Http;
using Moq;
using Bar.Models.Repositories;

namespace Testing.ControllerTests
{
    public class BeersControllerTest
    {

        Mock<IBeerRepository> mock = new Mock<IBeerRepository>();
        EFBeerRepository db = new EFBeerRepository(new BarDbContext());


        private void DbSetup()
        {
            mock.Setup(m => m.Beers).Returns(new Beer[]
            {
                new Beer {BeerId = 1, Name = "beer", Type = "good", Price = 12, Picture=null },
              
            }.AsQueryable());
        }
        [Fact]
        public void Mock_getViewResultIndex_Test()
        {
            DbSetup();
            BeersController controller = new BeersController(mock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Mock_IndexListOfBeer()
        {
            DbSetup();
            ViewResult indexView = new BeersController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<Beer>>(result);
        }
        [Fact]
        public void MockConfirmEntry_Test()
        {
            DbSetup();
            BeersController controller = new BeersController(mock.Object);
            Beer testBeer = new Beer();
            testBeer.Name = "Beer";
            testBeer.BeerId = 1;
            testBeer.Price = 1;
            testBeer.Picture = null;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Beer>;

            Assert.Contains<Beer>(testBeer, collection);
        }

        //[Fact]
        //public void DB_CreateNewEntry_Test()
        //{
        //    BeersController controller = new BeersController(db);
        //    Beer testBeer = new Beer();
        //    testBeer.Name = "testbeer";
        //    testBeer.Type = "good";
        //    testBeer.Price = 12;
        //    var fileMock = new IFormFile();
            

        //    controller.Create(testBeer.Name, testBeer.Type, testBeer.Price, fileMock);
        //}
    }
}
