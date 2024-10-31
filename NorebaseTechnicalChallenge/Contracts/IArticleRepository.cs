namespace NorebaseTechnicalChallenge.Contracts
{
    public interface IArticleRepository
    {
        Task<int> GetLikeCountAsync(int articleId);
        Task IncrementLikeCountAsync(int articleId);
    }
}
