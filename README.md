# Kurento.NET
kurento 客户端 C#实现
# 关于 Kurento
Kurento is an open source software project providing a platform suitable for creating modular applications with advanced real-time communication capabilities. For knowing more about Kurento, please visit the Kurento project website: https://www.kurento.org.
# 项目结构

+ KMSCreator
   + 根据kurento 提供的 kms-core，kms-elements，kms-filters 生成C# 的Kurento客户端
+ Kurento.NET
   + kurento的C# 客户端库
+ KurentoDemo
   + 几个简单的使用kurento 的列子

# 如何使用

1. NuGet 引用
   > ```Install-Package Kurento.NET```
2. 使用
 ```
    var client = new KurentoClient("ws://your kurento ip:8888/kurento", logger);
    var pipeline = client.Create(new MediaPipeline());
    var webRtcEndPoint = client.Create(new WebRtcEndpoint(pipeline));
```

# 实例
1. HelloWorld 在Demo 项目中Hubs 文件夹下可看到 HelloWorldHub,写了信令的处理，简单的本地循环实现
2. Room 在Demo 项目中Hubs 文件夹下可看到 RoomHub,写了信令的处理，简单的room 实现，也包含使用 RtpEndPoint 转发到另一个服务器


