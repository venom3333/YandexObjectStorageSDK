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

            // for upload
            var filename = "test_file2.mp4";
            var filePath = Path.Combine(@"K:\FTP\Video", filename);

            // for download
            var downloadFileName = "b8229776-4314-4e30-a1fb-9fe6c9b2282c_2020_07_10_05_32_30";
            var downloadUri = new UriBuilder(YandexStorageDefaults.Protocol, YandexStorageDefaults.EndPoint)
            {
                Path = Path.Combine(bucket, downloadFileName)
            };


            // UPLOAD TEST
            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    var fileGuid = $"{Guid.NewGuid()}_{filename}";
            //    var sss = await yandexService.PutObjectAsync(fs, fileGuid);
            //    Console.WriteLine(sss);
            //}


            // DOWNLOAD TEST
            //using (FileStream fsDownload = File.Create("test_file.mp4"))
            //{
            //    var result = await yandexService.GetAsStreamAsync(downloadUri.ToString());
            //    await result.CopyToAsync(fsDownload);
            //}

            // DELETE TEST
            //    var deleteResult = await yandexService.DeleteObjectAsync(downloadFileName);
            //  Console.WriteLine(deleteResult);

            // PRESIGNED URL TEST
            var presignedUrl = yandexService.GetPresignedUrlAsync(downloadUri.ToString(), TimeSpan.FromHours(1));
            Console.WriteLine(presignedUrl);

            Console.ReadKey();
        }
    }
}
