using Entities.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace MyProject.Tests
{
    public class FavoriteTests
    {
        [Fact]
        public void Favorite_WithValidData_ShouldBeValid()
        {
            // Arrange
            var favorite = new Favorite
            {
                Owner = "john_doe",
                RepoName = "sample-repo",
                LastUpdate = "2024-03-15",
                Language = "C#",
                Status = true
            };

            // Act

            // Assert
            Assert.Empty(ValidateModel(favorite));
        }

        [Fact]
        public void Favorite_WithMissingOwner_ShouldBeInvalid()
        {
            // Arrange
            var favorite = new Favorite
            {
                RepoName = "sample-repo",
                LastUpdate = "2024-03-15",
                Language = "C#",
                Status = true
            };

            // Act

            // Assert
            Assert.NotEmpty(ValidateModel(favorite));
        }

        [Fact]
        public void Favorite_WithMissingRepoName_ShouldBeInvalid()
        {
            // Arrange
            var favorite = new Favorite
            {
                Owner = "john_doe",
                LastUpdate = "2024-03-15",
                Language = "C#",
                Status = true
            };

            // Act

            // Assert
            Assert.NotEmpty(ValidateModel(favorite));
        }

       
        private static IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }
    }
}
