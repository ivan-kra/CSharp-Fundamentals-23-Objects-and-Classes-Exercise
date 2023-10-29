using System;

class AdvertisementMessage
{
    private static readonly string[] Phrases = {"Excellent product.", "Such a great product.", "I always use that product.",
                                                "Best product of its category.", "Exceptional product.", "I can't live without this product."};
    private static readonly string[] Events = {"Now I feel good.", "I have succeeded with this product.",
                                               "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                                               "Try it yourself, I am very satisfied.", "I feel great!"};
    private static readonly string[] Authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
    private static readonly string[] Cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

    public static string GenerateRandomMessage()
    {
        Random random = new Random();
        string phrase = Phrases[random.Next(Phrases.Length)];
        string eventText = Events[random.Next(Events.Length)];
        string author = Authors[random.Next(Authors.Length)];
        string city = Cities[random.Next(Cities.Length)];

        return $"{phrase} {eventText} {author} - {city}.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (int.TryParse(Console.ReadLine(), out int numberOfMessages) && numberOfMessages > 0)
        {
            for (int i = 0; i < numberOfMessages; i++)
            {
                string randomMessage = AdvertisementMessage.GenerateRandomMessage();
                Console.WriteLine(randomMessage);
            }
        }
        }
}
