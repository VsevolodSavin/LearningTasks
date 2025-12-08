
/*
Есть очень большой список пользователей, который нужно обработать порциями (чанками) для отправки в API,
которое принимает не более batchSize пользователей за один запрос.
Необходимо разбить коллекцию на чанки указанного размера и для каждого чанка выполнить определенную мок операцию.
*/

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string Name { get; init; }
}


public interface IUserApiClient
{
    Task<bool> SendUsersBatchAsync(IEnumerable<User> users);
}


public class UserBatchProcessor
{
    private readonly IUserApiClient _apiClient;
    private readonly int _batchSize;
    
    public UserBatchProcessor(IUserApiClient apiClient)
    {
        _apiClient = apiClient;
        _batchSize = 100;
    }
    
    /// <summary>
    /// Обрабатывает всех пользователей, разбивая их на чанки размером batchSize
    /// </summary>
    public async Task<BatchProcessingResult> ProcessUsersInBatches(
        ICollection<User> allUsers)
    {
        // Реализовать логику:
        // 1. Разбить allUsers на чанки размером _batchSize с помощью метода Chunk
        // 2. Для каждого чанка вызвать _apiClient.SendUsersBatchAsync()
        // 3. Вернуть статистику обработки

        var TotalUsers = allUsers.Count();

        var allBatches = allUsers.Chunk(_batchSize);
        var TotalBatches = allBatches.Count();

        var SuccessfulBatches = 0;
        var FailedBatches = 0;

        foreach (var chunk in allBatches)
        {
            try
            {
                var sender = await _apiClient.SendUsersBatchAsync(chunk);
                if (sender)
                    SuccessfulBatches++;
                else
                    FailedBatches++;
            }
            catch
            {
                FailedBatches++;
            }
        }

        return new BatchProcessingResult
        {
            TotalUsers = TotalUsers,
            TotalBatches = TotalBatches,
            SuccessfulBatches = SuccessfulBatches,
            FailedBatches = FailedBatches
        };
    }
}


public record BatchProcessingResult
{
    public int TotalUsers { get; init; }
    public int TotalBatches { get; init; }
    public int SuccessfulBatches { get; init; }
    public int FailedBatches { get; init; }
}