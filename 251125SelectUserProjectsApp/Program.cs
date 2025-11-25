// Написать метод, который возвращает все проекты всех пользователей из списка users,
// где возраст пользователей больше age. Каждый пользователь может иметь несколько проектов

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
    public ICollection<Project>? Projects { get; init; }
}

public sealed record Project
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}

public class ProjectSelector
{
    public ICollection<Project> SelectUserProjects(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }

        return users
            .Where(u => u.Age > age)
            .SelectMany(u => u.Projects ?? Enumerable.Empty<Project>())
            .ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var users = new List<User>
        {
            new User { 
                Id = Guid.NewGuid(), 
                Age = 25, 
                Name = "Alice",
                Projects = new List<Project> { 
                    new Project { Id = Guid.NewGuid(), Name = "Web API" },
                    new Project { Id = Guid.NewGuid(), Name = "Mobile App" }
                }
            },
            new User { 
                Id = Guid.NewGuid(), 
                Age = 20, 
                Name = "Bob",
                Projects = new List<Project> { 
                    new Project { Id = Guid.NewGuid(), Name = "Console App" }
                }
            },
            new User { 
                Id = Guid.NewGuid(), 
                Age = 30, 
                Name = "Charlie",
                Projects = new List<Project> { 
                    new Project { Id = Guid.NewGuid(), Name = "Database" },
                    new Project { Id = Guid.NewGuid(), Name = "Cloud" }
                }
            },
            new User { 
                Id = Guid.NewGuid(), 
                Age = 18, 
                Name = "David",
                Projects = null 
            }
        };

        var selector = new ProjectSelector();
        var projects = selector.SelectUserProjects(users, 22);

        Console.WriteLine("Проекты пользователей старше 22 лет:");
        
        foreach (var project in projects)
        {
            Console.WriteLine($"{project.Name} (ID: {project.Id})");
        }

        Console.WriteLine($"\n-- Всего найдено проектов: {projects.Count} --");
    }
}