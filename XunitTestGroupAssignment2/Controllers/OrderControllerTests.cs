using GroupAssignment2.Areas.Identity.Data;
using GroupAssignment2.Controllers;
using GroupAssignment2.DAL;
using GroupAssignment2.Models;
using GroupAssignment2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;
using static System.Formats.Asn1.AsnWriter;


namespace XunitTestGroupAssignment2.Controllers
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task TestTable()
        {
            // Arrange
            var orderList = new List<Order>()
            {
                new Order
                {
                    OrderId = 1,
                    CustomerId = "6fc8b6e2-deba-4028-a6ba-f24abaa29a7d",
                    HousingId = 1,
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(3),
                    TotalPrice = 2100
                },
                new Order
                {
                    OrderId = 2,
                    CustomerId = "6fc8b6e2-deba-4028-a6ba-f24abaa29a7d",
                    HousingId = 2,
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(4),
                    TotalPrice = 2650
                }
            };

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.GetAll()).ReturnsAsync(orderList);
            var mockLogger = new Mock<ILogger<OrderController>>();
            // Creating a mock UserManager was not working as we could not recreate it with proper parameters, therefor NULL
            var orderController = new OrderController(null ,mockOrderRepository.Object, mockLogger.Object);

            // Act
            var result = await orderController.Table();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var orderListViewModel = Assert.IsAssignableFrom<OrderListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, orderListViewModel.Orders.Count());
            Assert.Equal(orderList, orderListViewModel.Orders);
        }

        // Testing failed, see "Documentation Project 2 - Unit Testing of Controller & Crud Methods - Order" for details to making TestCreate successful
        [Fact]
        public async Task TestCreate()
        {
            // Arrange
            var order = new Order
            {
                OrderId = 1,
                CustomerId = "6fc8b6e2-deba-4028-a6ba-f24abaa29a7d",
                HousingId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(3),
                TotalPrice = 2100
            };

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.CreateOrder(order));

            var mockLogger = new Mock<ILogger<OrderController>>();
            var orderController = new OrderController(null, mockOrderRepository.Object, mockLogger.Object);

            // Act
            var result = await orderController.CreateOrder(order);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewOrder = Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
            Assert.Equal(order, viewOrder);
        }
    }
}
