using Application.Common.Interfaces.Services;

namespace Application.Services;

public class ChatAiResponseService : IChatAiResponseService
{
    private string[] words =
       [
            "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit",
            "sed", "do", "eiusmod", "tempor", "incididunt", "ut", "labore", "et", "dolore",
            "magna", "aliqua", "Ut", "enim", "ad", "minim", "veniam", "quis", "nostrud",
            "exercitation", "ullamco", "laboris", "nisi", "ut", "aliquip", "ex", "ea",
            "commodo", "consequat"
       ];

    public string GenerateRandomLoremIpsum(int minWords = 10, int maxWords = 200)
    {
        Random random = new Random();
        int numWords = random.Next(minWords, maxWords + 1);
        string result = "";

        for (int i = 0; i < numWords; i++)
        {
            result += words[random.Next(words.Length)] + " ";
        }

        return result.Trim();
    }
}
