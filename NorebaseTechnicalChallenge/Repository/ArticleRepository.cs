using NorebaseTechnicalChallenge.Contracts;

namespace NorebaseTechnicalChallenge.Repository
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly RepositoryContext _repositorycontext;
        public ArticleRepository(RepositoryContext repositorycontext)
        {
            _repositorycontext = repositorycontext;
        }

        public async Task<int> GetLikeCountAsync(int articleId)
        {
            var article = await _repositorycontext.Articles.FindAsync(articleId);
            return article?.LikeCount ?? 0;
        }

        public async Task IncrementLikeCountAsync(int articleId)
        {
            var article = await _repositorycontext.Articles.FindAsync(articleId);
            if (article != null)
            {
                article.LikeCount++;
                await _repositorycontext.SaveChangesAsync();
            }
        }
    }
}
