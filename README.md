### Использование

Через DI в ServiceCollection:

```
services.AddYandexObjectStorage(options =>
{
  options.BucketName = "bucketName";
  options.AccessKey = "access-key";
  options.SecretKey = "secret-key";
});
```

Через файл конфигурации `appsettings.json`:
по умолчанию читает секцию `YandexObjectStorage`, например:


```
"YandexObjectStorage" : {
    "Bucket" : "your-bucket",
    "AccessKey" : "your-access-key",
    "SecretKey" : "your-secret-key",
    "Protocol" : "https"
  }
```

Все доступные опции см. непосредственно в файле YandexStorageOptions.cs
Умолчания опций см. в файле YandexStorageDefaults.cs
