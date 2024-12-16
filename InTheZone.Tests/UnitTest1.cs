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
}    [Fact]
    public async Task GetHomeRunsForDateAsync_ValidDate_ReturnsHomeRuns()
    {
        // Arrange
        var mockProxy = new Mock<IMlbStatsApiProxy>();
        var homeRuns = new List<HomeRun> { new HomeRun() }; // Replace with your HomeRun model
        mockProxy.Setup(proxy => proxy.GetHomeRunsByDateAsync(It.IsAny<DateTime>()))
                 .ReturnsAsync(homeRuns);

        var service = new GameVisualizationService(mockProxy.Object);

        // Act
        var result = await service.GetHomeRunsForDateAsync(DateTime.Now);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(homeRuns.Count, result.Count);
    }

    [Fact]
    public async Task GetHomeRunsForDateAsync_ApiError_ThrowsException()
    {
        // Arrange
        var mockProxy = new Mock<IMlbStatsApiProxy>();
        mockProxy.Setup(proxy => proxy.GetHomeRunsByDateAsync(It.IsAny<DateTime>()))
                 .ThrowsAsync(new HttpRequestException("API error"));

        var service = new GameVisualizationService(mockProxy.Object);

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => service.GetHomeRunsForDateAsync(DateTime.Now));
    }
}
