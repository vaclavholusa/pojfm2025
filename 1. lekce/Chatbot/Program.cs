using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

Console.WriteLine("Můj perfektní chatbot");

var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

var chatClient = new OpenAIClient(configuration["apiKey"])
                        .AsChatClient(configuration["model"]);

List<ChatMessage> chatHistory = new()
{
    new ChatMessage(ChatRole.System, """
        Sem přijde briefing bota.
        Může obsahovat mnoho řádků pokynů
    """)
};

while (true)
{
    Console.WriteLine("Tvůj prompt:");
    var userPrompt = Console.ReadLine();
    chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

    Console.WriteLine("AI Odpověď:");
    var response = "";
    await foreach (var item in
        chatClient.GetStreamingResponseAsync(chatHistory))
    {
        Console.Write(item.Text);
        response += item.Text;
    }
    chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));
    Console.WriteLine();
}