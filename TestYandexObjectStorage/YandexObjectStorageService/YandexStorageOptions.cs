using Microsoft.Extensions.Configuration;

namespace TestYandexObjectStorage.YandexObjectStorageService
{
    public class YandexStorageOptions
    {

        public YandexStorageOptions()
        {
            
        }

        public YandexStorageOptions(IConfigurationSection section)
        {
            BucketName = section.GetSection("Bucket").Value;
            AccessKey = section.GetSection("AccessKey").Value;
            SecretKey = section.GetSection("SecretKey").Value;

            Protocol = section.GetSection("Protocol")?.Value ?? YandexStorageDefaults.Protocol;
            Region = section.GetSection("Region")?.Value ?? YandexStorageDefaults.Region;
            Endpoint = section.GetSection("Endpoint")?.Value ?? YandexStorageDefaults.Endpoint;
            Service = section.GetSection("Service")?.Value ?? YandexStorageDefaults.Service;
        }
        
        /// <summary>
        /// "http" or "https"
        /// </summary>
        public string Protocol { get; set; } = YandexStorageDefaults.Protocol;
        
        /// <summary>
        /// https://cloud.yandex.ru/docs/storage/concepts/bucket
        /// </summary>
        public string BucketName { get; set; }
        
        public string Region { get; set; } = YandexStorageDefaults.Region;
        public string Endpoint { get; set; } = YandexStorageDefaults.Endpoint;
        public string Service { get; set; } = YandexStorageDefaults.Service;
        
        /// <summary>
        /// https://cloud.yandex.ru/docs/storage/s3/
        /// </summary>
        public string AccessKey { get; set;}
        
        /// <summary>
        /// https://cloud.yandex.ru/docs/storage/s3/
        /// </summary>
        public string SecretKey { get; set; }
        public string HostName => $"{Protocol}://{Endpoint}/{BucketName}";
    }
}