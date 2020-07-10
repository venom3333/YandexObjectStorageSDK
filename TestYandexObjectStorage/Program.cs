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

            // UPLOAD TEST
            //var filename = "test_file2.mp4";
            //var filePath = Path.Combine(@"K:\FTP\Video", filename);
            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    var fileGuid = $"{Guid.NewGuid()}_{filename}";
            //    var sss = await yandexService.PutObjectAsync(fs, fileGuid);
            //    Console.WriteLine(sss);
            //}


            // DOWNLOAD TEST
            //var downloadFileName = "00035f95-d708-4aae-ba4c-7939c5c19873_test_file2.mp4";
            //var downloadUri = new UriBuilder(YandexStorageDefaults.Protocol, YandexStorageDefaults.EndPoint)
            //{
            //    Path = Path.Combine(bucket, downloadFileName)
            //};


            //using (FileStream fsDownload = File.Create("test_file.mp4"))
            //{
            //    var result = await yandexService.GetAsStreamAsync(downloadUri.ToString());
            //    await result.CopyToAsync(fsDownload);
            //}

            // DELETE TEST
        //    var deleteResult = await yandexService.DeleteObjectAsync(downloadFileName);
        //    Console.WriteLine(deleteResult);
        //    Console.ReadKey();
        }
    }
}
