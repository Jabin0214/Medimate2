# 使用 .NET SDK 作为构建环境
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 设置工作目录
WORKDIR /app

# 复制项目文件
COPY *.csproj ./

# 还原依赖项
RUN dotnet restore

# 复制所有文件
COPY . ./

# 编译和发布应用
RUN dotnet publish -c Release -o /publish

# 运行环境
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# 设置工作目录
WORKDIR /app

# 复制发布后的文件
COPY --from=build /publish .

# 暴露端口
EXPOSE 5000
EXPOSE 5001

# 运行应用
CMD ["dotnet", "Drugsearch.dll"]