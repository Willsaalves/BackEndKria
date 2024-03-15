using Domain.Interfaces.IFavorite;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using Xunit;

namespace MyProject.Tests
{
    public class FavoriteControllerTests
    {
        [Fact]
        public async Task CreateFavorite_ValidData_ShouldReturnOk()
        {
            // Arrange
            var mockInterfaceFavorite = new Mock<InterfaceFavorite>();
            mockInterfaceFavorite.Setup(repo => repo.Add(It.IsAny<Favorite>())).Returns(Task.CompletedTask);

            var controller = new FavoriteController(mockInterfaceFavorite.Object);
            var favorite = new Favorite { Owner = "john_doe", RepoName = "sample-repo" };

            // Act
            var result = await controller.CreateFavorite(favorite);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Criado", okResult.Value);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllFavorites()
        {
            // Arrange
            var mockInterfaceFavorite = new Mock<InterfaceFavorite>();
            var favorites = new List<Favorite>
            {
                new Favorite { Id = 1, Owner = "john_doe", RepoName = "sample-repo-1" },
                new Favorite { Id = 2, Owner = "jane_doe", RepoName = "sample-repo-2" }
            };
            mockInterfaceFavorite.Setup(repo => repo.List()).ReturnsAsync(favorites);

            var controller = new FavoriteController(mockInterfaceFavorite.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedFavorites = Assert.IsAssignableFrom<IEnumerable<Favorite>>(okResult.Value);
            Assert.Equal(2, returnedFavorites.Count());
        }

        [Fact]
        public async Task GetByRepoName_ExistingRepoName_ShouldReturnFavorite()
        {
            // Arrange
            var mockInterfaceFavorite = new Mock<InterfaceFavorite>();
            var favorites = new List<Favorite>
            {
                new Favorite { Id = 1, Owner = "john_doe", RepoName = "sample-repo-1" },
                new Favorite { Id = 2, Owner = "jane_doe", RepoName = "sample-repo-2" }
            };
            mockInterfaceFavorite.Setup(repo => repo.List()).ReturnsAsync(favorites);

            var controller = new FavoriteController(mockInterfaceFavorite.Object);

            // Act
            var result = await controller.GetByRepoName("sample-repo-1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedFavorite = Assert.IsType<Favorite>(okResult.Value);
            Assert.Equal("sample-repo-1", returnedFavorite.RepoName);
        }

        [Fact]
        public async Task GetByRepoName_NonExistingRepoName_ShouldReturnNotFound()
        {
            // Arrange
            var mockInterfaceFavorite = new Mock<InterfaceFavorite>();
            var favorites = new List<Favorite>
            {
                new Favorite { Id = 1, Owner = "john_doe", RepoName = "sample-repo-1" },
                new Favorite { Id = 2, Owner = "jane_doe", RepoName = "sample-repo-2" }
            };
            mockInterfaceFavorite.Setup(repo => repo.List()).ReturnsAsync(favorites);

            var controller = new FavoriteController(mockInterfaceFavorite.Object);

            // Act
            var result = await controller.GetByRepoName("non-existing-repo");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

       
    }
}
