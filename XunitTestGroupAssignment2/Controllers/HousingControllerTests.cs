
using GroupAssignment2.Controllers;
using GroupAssignment2.DAL;
using GroupAssignment2.Models;
using GroupAssignment2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

using static System.Net.WebRequestMethods;

namespace XunitTestGroupAssignment2.Controllers
{
    public class HousingControllerTests
    {
        [Fact]
        public async Task TestTable()
        {
            // Arrange
            // Creates an environment that mimics Housing Table to be tested
            var housingList = new List<Housing>()
            {
                new Housing
                {
                    HousingId = 1,
                    Description = "Test1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(15),
                    ImageUrl = "https://media.istockphoto.com/id/1440781882/photo/interior-design-and-decoration-of-a-modern-living-room-with-a-dining-table.jpg?s=2048x2048&w=is&k=20&c=rzRilH2fzAbyjMeqaDgtqozgYg0p7VXuAZ-cOyztWA0=",
                    Including = "3 guests, 3 bedrooms, ",
                    Location = "Selma Ellefsens vei 9B, 0581 Oslo",
                    Rent = 700,
                    Name = "Name"
                },
                new Housing
                {
                    HousingId = 2,
                    Description = "Test2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    ImageUrl = "https://media.istockphoto.com/id/979578630/photo/modern-interior-of-living-room-with-small-design-table-stylish-sofa-and-lamp-white-walls-with.jpg?s=1024x1024&w=is&k=20&c=T6B9bwiJB0_9AM35Fds-vJfakl_QHelNg3TnhKnnitI=",
                    Including = "1-2 guests - 1 bedroom - living room - kitchen - bathroom",
                    Location = "Sandakerveien 68A, 0480 Oslo",
                    Rent = 650,
                    Name = "Name2"
                }
            };

            var mockHousingRepository = new Mock<IHousingRepository>();
            mockHousingRepository.Setup(repo => repo.GetAll()).ReturnsAsync(housingList);
            var mockLogger = new Mock<ILogger<HousingController>>();
            var housingController = new HousingController(mockHousingRepository.Object, mockLogger.Object);

            // Act
            // Execute the Table function
            var result = await housingController.Table();

            // Assert
            // Check whether result is equal to expected outcome
            var viewResult = Assert.IsType<ViewResult>(result);
            var housingListViewModel = Assert.IsAssignableFrom<HousingListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, housingListViewModel.Housings.Count());
            Assert.Equal(housingList, housingListViewModel.Housings);
        }


        [Fact]
        public async Task TestCreate()
        {
            // Arrange
            var housing = new Housing
            {
                HousingId = 1,
                Description = "Test1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(15),
                ImageUrl = "https://media.istockphoto.com/id/1440781882/photo/interior-design-and-decoration-of-a-modern-living-room-with-a-dining-table.jpg?s=2048x2048&w=is&k=20&c=rzRilH2fzAbyjMeqaDgtqozgYg0p7VXuAZ-cOyztWA0=",
                Including = "3 guests, 3 bedrooms, ",
                Location = "Selma Ellefsens vei 9B, 0581 Oslo",
                Rent = 700,
                Name = "Name"
            };

            var mockHousingRepository = new Mock<IHousingRepository>();
            mockHousingRepository.Setup(repo => repo.Create(housing));
            var mockLogger = new Mock<ILogger<HousingController>>();
            var housingController = new HousingController(mockHousingRepository.Object, mockLogger.Object);

            // Act
            var result = await housingController.Create(housing);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewHousing = Assert.IsAssignableFrom<Housing>(viewResult.ViewData.Model);
            Assert.Equal(housing, viewHousing);
        }

        [Fact]
        public async Task TestDelete()
        {
            // Arrange
            var housingIdToDelete = 1;

            var mockHousingRepository = new Mock<IHousingRepository>();
            mockHousingRepository.Setup(repo => repo.GetHousingById(housingIdToDelete))
                .ReturnsAsync(new Housing { HousingId = housingIdToDelete }); // Assuming a housing record exists for this test
            mockHousingRepository.Setup(repo => repo.Delete(housingIdToDelete))
                .ReturnsAsync(true); // Assuming successful deletion for this test

            var mockLogger = new Mock<ILogger<HousingController>>();
            var housingController = new HousingController(mockHousingRepository.Object, mockLogger.Object);

            // Act
            var result = await housingController.Delete(housingIdToDelete);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewHousing = Assert.IsAssignableFrom<Housing>(viewResult.ViewData.Model);
            Assert.Equal(housingIdToDelete, viewHousing.HousingId);
        }

        [Fact]
        public async Task TestUpdate()
        {
            // Arrange
            var housingIdToUpdate = 1;
            var updatedHousing = new Housing
            {
                HousingId = housingIdToUpdate,
                Description = "Test1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(15),
                ImageUrl = "https://media.istockphoto.com/id/1440781882/photo/interior-design-and-decoration-of-a-modern-living-room-with-a-dining-table.jpg?s=2048x2048&w=is&k=20&c=rzRilH2fzAbyjMeqaDgtqozgYg0p7VXuAZ-cOyztWA0=",
                Including = "3 guests, 3 bedrooms, ",
                Location = "Selma Ellefsens vei 9B, 0581 Oslo",
                Rent = 700,
                Name = "Name"
            };

            var mockHousingRepository = new Mock<IHousingRepository>();
           
            mockHousingRepository.Setup(repo => repo.GetHousingById(housingIdToUpdate))
                .ReturnsAsync(new Housing { HousingId = housingIdToUpdate });
            mockHousingRepository.Setup(repo => repo.Update(updatedHousing))
                .ReturnsAsync(true);

            var mockLogger = new Mock<ILogger<HousingController>>();
            var housingController = new HousingController(mockHousingRepository.Object, mockLogger.Object);

            // Act
            var result = await housingController.Update(updatedHousing);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Table", redirectToActionResult.ActionName);
        }

    }
}
