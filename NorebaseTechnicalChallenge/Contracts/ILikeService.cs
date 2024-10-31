namespace NorebaseTechnicalChallenge.Contracts
{
    public interface ILikeService
    {
        Task<int> GetLikes(int articleId);
        Task IncrementLike(int articleId);
    }
}
