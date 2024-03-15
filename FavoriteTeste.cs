using System;
using System.Collections.Generic;

public class Class1
{
{
    [TestFixture]
    public class FavoriteTests
    {
        [Test]
        public void Owner_IsRequired()
        {
            // Arrange
            var favorite = new Favorite();

            // Act
            var validationContext = new ValidationContext(favorite);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(favorite, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains(nameof(Favorite.Owner))));
        }

        [Test]
        public void RepoName_IsRequired()
        {
            // Arrange
            var favorite = new Favorite();

            // Act
            var validationContext = new ValidationContext(favorite);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(favorite, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains(nameof(Favorite.RepoName))));
        }

        [Test]
        public void Status_IsRequired()
        {
            // Arrange
            var favorite = new Favorite();

            // Act
            var validationContext = new ValidationContext(favorite);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(favorite, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains(nameof(Favorite.Status))));
        }
    }
}
