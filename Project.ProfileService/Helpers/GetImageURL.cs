using Project.Core.AWS;
using Project.ProfileService.Data.Configurations;

namespace Project.ProfileService.Helpers
{
    public static class GetImageURL
    {
        public static async Task<string> GetUrl(this IAmazonS3Bucket s3Bucket, string Key)
        {
            var url = "";
            if (string.IsNullOrEmpty(Key))
            {
                url = await s3Bucket.GetFileAsync(ConstantsData.DefaultAvatarKey);
            }
            else
            {
                url = await s3Bucket.GetFileAsync(Key);
            }
            return url;
        }
    }
}
