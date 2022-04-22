using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Flashcards.Models;

namespace Flashcards.Data
{
    public class FlashcardsDbContext
    {
        private readonly IMongoCollection<Flashcard> _flashcardsCollection;

        public FlashcardsDbContext(IOptions<FlashcardsDatabaseSettings> flashcardsDatabaseSettings)
        { 
            var mongoClient = new MongoClient(flashcardsDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(flashcardsDatabaseSettings.Value.DatabaseName);
            _flashcardsCollection = mongoDatabase.GetCollection<Flashcard>(flashcardsDatabaseSettings.Value.FlashcardsCollectionName);
        }

        public async Task<List<Flashcard>> GetAsync() => await _flashcardsCollection.Find(_ => true).ToListAsync();
        public async Task<Flashcard?> GetAsync(string id) => await _flashcardsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Flashcard flashcard) => await _flashcardsCollection.InsertOneAsync(flashcard);
        public async Task UpdateAsync(string id, Flashcard flashcard) => await _flashcardsCollection.ReplaceOneAsync(x => x.Id == id, flashcard);
        public async Task RemoveAsync(string id) => await _flashcardsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
