using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace TestesUnitarios
{
    public class UnitTest1
    {
        public class RepositoryGenericsTests
        {
            private readonly DbContextOptions<ContextBase> _options;

            public RepositoryGenericsTests()
            {
                _options = new DbContextOptionsBuilder<ContextBase>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
            }

            [Fact]
            public async Task Add_Entity_AddsToDatabase()
            {
                // Arrange
                var entity = new ExampleEntity(); // Substitua ExampleEntity pelo seu tipo T
                using (var context = new ContextBase(_options))
                {
                    var repository = new RepositoryGenerics<ExampleEntity>(context);

                    // Act
                    await repository.Add(entity);
                }

                // Assert
                using (var context = new ContextBase(_options))
                {
                    var result = await context.ExampleEntities.FirstOrDefaultAsync();
                    Assert.NotNull(result);
                    Assert.Equal(entity, result);
                }
            }

            // Escreva testes semelhantes para os outros métodos (Delete, GetEntityById, List, Update)
        }
    }