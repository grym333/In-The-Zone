public class GameVisualizationServiceTests
{
    [Fact]
    public async Task GetGameDataAsync_ValidGameId_ReturnsGameData()
    {
        // Arrange
        var mockRepo = new Mock<IGameRepository>();
        var mockSecurity = new Mock<ISecurityManager>();
        mockRepo.Setup(repo => repo.GetGameByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new GameData()); // Assuming GameData is a model

        var service = new GameVisualizationService(mockRepo.Object, mockSecurity.Object);

        // Act
        var result = await service.GetGameDataAsync(1);

        // Assert
        Assert.NotNull(result);
        // Add more assertions based on expected behavior
    }
}