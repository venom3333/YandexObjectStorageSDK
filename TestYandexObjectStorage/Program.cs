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
            var filename = "test_file6.mp4";
            var filePath = Path.Combine(@"K:\FTP\Video", filename);

            // for download
            var downloadFileName = "download_file.mp4";
            var uploadedFileUrl = "";

            // UPLOAD STREAMED TEST
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var fileGuid = $"{Guid.NewGuid()}_{filename}";
                uploadedFileUrl = await yandexService.PutObjectAsync(fs, fileGuid);
                Console.WriteLine(uploadedFileUrl);
            }

            // UPLOAD BYTES TEST
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var fileGuid = $"{Guid.NewGuid()}_{filename}";
                using (MemoryStream ms = new MemoryStream())
                {
                    await fs.CopyToAsync(ms);
                    uploadedFileUrl = await yandexService.PutObjectAsync(ms.ToArray(), fileGuid);
                }
                Console.WriteLine(uploadedFileUrl);
            }


            // DOWNLOAD STREAMED TEST
            using (FileStream fsDownload = File.Create(downloadFileName))
            {
                var result = await yandexService.GetAsStreamAsync(uploadedFileUrl.ToString());
                await result.CopyToAsync(fsDownload);
            }

            // DOWNLOAD BYTES TEST
            using (FileStream fsDownload = File.Create(downloadFileName))
            {
                var result = await yandexService.GetAsByteArrayAsync(uploadedFileUrl.ToString());
                await fsDownload.WriteAsync(result);
            }

            // PRESIGNED URL TEST
            var presignedUrl = yandexService.GetPresignedUrlAsync(uploadedFileUrl.ToString(), TimeSpan.FromHours(3));
            Console.WriteLine(presignedUrl);

            // DELETE TEST
            var deleteResult = await yandexService.DeleteObjectAsync(uploadedFileUrl);
            Console.WriteLine(deleteResult);

            Console.ReadKey();
        }
    }
}
