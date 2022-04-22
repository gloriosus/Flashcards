using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Flashcards.Models
{
    public record Flashcard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("_userId")]
        public int UserId { get; set; }
        
        public string Group { get; set; }
        public string Language { get; set; } = "en-us";
        public string Title { get; set; }
        public string Transcription { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Forms { get; set; }
        public IEnumerable<string> Synonyms { get; set; }
        public IEnumerable<string> Antonyms { get; set; }
        public IEnumerable<string> Examples { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Audio { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Optional { get; set; } = string.Empty;
    }
}
