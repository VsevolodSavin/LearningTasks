
using Xunit;
using Assert = Xunit.Assert;

namespace _251125SelectUserProjectsTest
{
    public class ProjectSelectorTests
    {
        private readonly ProjectSelector _selector;

        public ProjectSelectorTests()
        {
            _selector = new ProjectSelector();
        }

        [Fact]
        public void SelectUserProjects_WhenUsersNull_ReturnsEmptyCollection()
        {
            // Arrange
            ICollection<User>? users = null;
            var age = 18;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
                [Fact]
        public void SelectUserProjects_WhenUsersEmpty_ReturnsEmptyCollection()
        {
            // Arrange
            var users = new List<User>();
            var age = 18;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void SelectUserProjects_WhenAllUsersBelowAge_ReturnsEmptyCollection()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 20, Projects = new List<Project> { new Project { Id = Guid.NewGuid(), Name = "Test" } } },
                new User { Id = Guid.NewGuid(), Age = 21, Projects = new List<Project> { new Project { Id = Guid.NewGuid(), Name = "Test2" } } }
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void SelectUserProjects_WhenUsersAboveAgeWithProjects_ReturnsCorrectProjects()
        {
            // Arrange
            var project1 = new Project { Id = Guid.NewGuid(), Name = "Project1" };
            var project2 = new Project { Id = Guid.NewGuid(), Name = "Project2" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 30, Projects = new List<Project> { project1 } },
                new User { Id = Guid.NewGuid(), Age = 35, Projects = new List<Project> { project2 } }
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(project1, result);
            Assert.Contains(project2, result);
        }

        [Fact]
        public void SelectUserProjects_WhenUserAboveAgeButNoProjects_ReturnsEmptyForThatUser()
        {
            // Arrange
            var project = new Project { Id = Guid.NewGuid(), Name = "Project" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 30, Projects = new List<Project> { project } },
                new User { Id = Guid.NewGuid(), Age = 35, Projects = null }
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Contains(project, result);
        }

        [Fact]
        public void SelectUserProjects_WhenMixedAgesAndProjects_ReturnsOnlyAboveAgeWithProjects()
        {
            // Arrange
            var project1 = new Project { Id = Guid.NewGuid(), Name = "Project1" };
            var project2 = new Project { Id = Guid.NewGuid(), Name = "Project2" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 30, Projects = new List<Project> { project1 } },
                new User { Id = Guid.NewGuid(), Age = 20, Projects = new List<Project> { project2 } }, 
                new User { Id = Guid.NewGuid(), Age = 35, Projects = null }, 
                new User { Id = Guid.NewGuid(), Age = 40, Projects = new List<Project>() } 
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Contains(project1, result);
            Assert.DoesNotContain(project2, result);
        }

        [Fact]
        public void SelectUserProjects_WhenUserHasMultipleProjects_ReturnsAllProjects()
        {
            // Arrange
            var project1 = new Project { Id = Guid.NewGuid(), Name = "Project1" };
            var project2 = new Project { Id = Guid.NewGuid(), Name = "Project2" };
            var project3 = new Project { Id = Guid.NewGuid(), Name = "Project3" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 30, Projects = new List<Project> { project1, project2, project3 } }
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains(project1, result);
            Assert.Contains(project2, result);
            Assert.Contains(project3, result);
        }

        [Fact]
        public void SelectUserProjects_WhenAgeBoundary_ReturnsCorrectResults()
        {
            // Arrange
            var project1 = new Project { Id = Guid.NewGuid(), Name = "Project1" };
            var project2 = new Project { Id = Guid.NewGuid(), Name = "Project2" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 25, Projects = new List<Project> { project1 } }, 
                new User { Id = Guid.NewGuid(), Age = 26, Projects = new List<Project> { project2 } }  
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Contains(project2, result);
            Assert.DoesNotContain(project1, result);
        }

        [Fact]
        public void SelectUserProjects_WhenDuplicateProjects_ReturnsAllDuplicates()
        {
            // Arrange
            var project = new Project { Id = Guid.NewGuid(), Name = "SharedProject" };
            
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Age = 30, Projects = new List<Project> { project } },
                new User { Id = Guid.NewGuid(), Age = 35, Projects = new List<Project> { project } }
            };
            var age = 25;

            // Act
            var result = _selector.SelectUserProjects(users, age);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, p => Assert.Equal(project, p));
        }
    }
}