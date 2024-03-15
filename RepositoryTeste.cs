using NUnit.Framework;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models; // Substitua pelo namespace do seu modelo

namespace Testes
{
    [TestFixture]
    public class RepositoryGenericsTests
    {
        private DbContextOptions<ContextBase> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ContextBase>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Test]
        public async Task Add_Entity_AddsToDatabase()
        {
            // Arrange
            var entity = new T(); // Substitua T pelo seu tipo T
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<T>(context);

                // Act
                await repository.Add(entity);
            }

            // Assert
            using (var context = new ContextBase(_options))
            {
                var result = await context.ExampleEntities.FirstOrDefaultAsync();
                Assert.NotNull(result);
                Assert.AreEqual(entity, result);
            }
        }

        [Test]
        public async Task Update_Entity_UpdatesInDatabase()
        {
            // Arrange
            var entity = new T(); // Substitua T pelo seu tipo T
            using (var context = new ContextBase(_options))
            {
                await context.ExampleEntities.AddAsync(entity);
                await context.SaveChangesAsync();
            }

            // Act
            entity.Propriedade = "Nova Propriedade"; // Modifique uma propriedade
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<T>(context);
                await repository.Update(entity);
            }

            // Assert
            using (var context = new ContextBase(_options))
            {
                var result = await context.ExampleEntities.FindAsync(entity.Id);
                Assert.AreEqual("Nova Propriedade", result.Propriedade);
            }
        }

        [Test]
        public async Task Delete_Entity_RemovesFromDatabase()
        {
            // Arrange
            var entity = new T(); // Substitua T pelo seu tipo T
            using (var context = new ContextBase(_options))
            {
                await context.ExampleEntities.AddAsync(entity);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<T>(context);
                await repository.Delete(entity);
            }

            // Assert
            using (var context = new ContextBase(_options))
            {
                var result = await context.ExampleEntities.FindAsync(entity.Id);
                Assert.Null(result);
            }
        }

        [Test]
        public async Task GetEntityById_EntityExists_ReturnsEntity()
        {
            // Arrange
            var entity = new T(); // Substitua T pelo seu tipo T
            using (var context = new ContextBase(_options))
            {
                await context.ExampleEntities.AddAsync(entity);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<T>(context);
                var result = await repository.GetEntityById(entity.Id);

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(entity, result);
            }
        }

        [Test]
        public async Task List_ReturnsAllEntities()
        {
            // Arrange
            var entities = new List<T>
            {
                new T { Propriedade = "Entidade 1" },
                new T { Propriedade = "Entidade 2" },
                new T { Propriedade = "Entidade 3" }
            };

            using (var context = new ContextBase(_options))
            {
                await context.ExampleEntities.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new ContextBase(_options))
            {
                var repository = new RepositoryGenerics<T>(context);
                var result = await repository.List();

                // Assert
                Assert.AreEqual(entities.Count, result.Count);
                Assert.AreEqual(entities, result);
            }
        }
    }
}
