namespace Application.Common.Interfaces.Services
{
    public interface IChatAiResponseService
    {
        string GenerateRandomLoremIpsum(int minWords = 10, int maxWords = 800);
    }
}