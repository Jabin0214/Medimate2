# 使用 Node.js 镜像来构建 React 前端
FROM node:21 AS build

# 设置工作目录
WORKDIR /app

# 拷贝 package.json 和 package-lock.json 并安装依赖
COPY package*.json ./
RUN npm install

# 拷贝所有前端代码并构建
COPY . .
RUN npm run build

# 使用 Nginx 部署前端代码
FROM nginx:alpine

# 拷贝构建的代码到 Nginx 的默认静态文件目录
COPY --from=build /app/build /usr/share/nginx/html

# 暴露 Nginx 的默认端口
EXPOSE 80

# 启动 Nginx
CMD ["nginx", "-g", "daemon off;"]