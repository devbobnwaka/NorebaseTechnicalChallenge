using Microsoft.Extensions.Caching.Memory;
using NorebaseTechnicalChallenge.Contracts;

namespace NorebaseTechnicalChallenge.Service
{
    public class LikeService: ILikeService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMemoryCache _cache;
        private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(5);

        public LikeService(IArticleRepository articleRepository, IMemoryCache cache)
        {
            _articleRepository = articleRepository;
            _cache = cache;
        }

        public async Task<int> GetLikes(int articleId)
        {
            // Check if the like count is cached
            if (!_cache.TryGetValue(articleId, out int likeCount))
            {
                // If not in cache, fetch from the repository
                likeCount = await _articleRepository.GetLikeCountAsync(articleId);

                // Store the result in cache
                _cache.Set(articleId, likeCount, CacheExpiration);
            }

            return likeCount;
        }

       public async Task IncrementLike(int articleId)
       {
            // Increment like count in the repository
            await _articleRepository.IncrementLikeCountAsync(articleId);

            // Update the cache to keep it in sync
            if (_cache.TryGetValue(articleId, out int cachedLikeCount))
            {
                _cache.Set(articleId, cachedLikeCount + 1, CacheExpiration);
            }
            else
            {
                // If it's not in cache, get the updated count and cache it
                int likeCount = await _articleRepository.GetLikeCountAsync(articleId);
                _cache.Set(articleId, likeCount, CacheExpiration);
            }
       }
    }
}
