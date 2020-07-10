using System;
using System.IO;
using System.Threading.Tasks;
using TestYandexObjectStorage.YandexObjectStorageService;

namespace TestYandexObjectStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bucket = "cpk-bucket-storage";
            var accessKey = "JmT-qmYIKGT4KFJXUZtB";
            var secretKey = "Y9H16rM5lga4yG8-kqyByQDv2VkPpIH-0w8OE6Tp";

            var yandex = new YandexStorageOptions() { BucketName = bucket, AccessKey = accessKey, SecretKey = secretKey };
            var yandexService = yandex.CreateYandexObjectService();

            var isSuccess = await yandexService.TryGetAsync();
            Console.WriteLine(isSuccess);

            var filename = "test_file5.zzz";
            var filePath = Path.Combine(@"K:\FTP\Video", filename);
            //var downloadPath = @"https://storage.yandexcloud.net/cpk-bucket-storage/84b6e246-0a76-4d43-ab84-73d71cc6d204_2020_07_10_11_40_45";
            //var downloadPath3 = @"https://storage.yandexcloud.net/cpk-bucket-storage/4f18f8f3-9096-4384-85a8-1fd42f084588_2020_07_10_11_51_24";

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var fileGuid = $"{Guid.NewGuid()}_{filename}";
                var sss = await yandexService.PutObjectAsync(fs, fileGuid);
                Console.WriteLine(sss);
            }

            //var result = await yandexService.GetAsStreamAsync(downloadPath3);
            //using FileStream fsDownload = File.Create("test_file.mp4");
            //await result.CopyToAsync(fsDownload);
            Console.ReadKey();
        }
    }
}
