namespace Flashcards
{
    public class FlashcardsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FlashcardsCollectionName { get; set; } = null!;
    }
}
