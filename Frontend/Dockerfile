# 1. 使用 Node.js 构建前端
FROM node:23 AS build
WORKDIR /app

# 2. 复制 package.json 并安装依赖
COPY package*.json ./
RUN npm install

# 3. 复制前端代码
COPY . .

# 复制 .env 文件到 Docker
COPY .env .env

# 4. 构建前端
RUN npm run build

# 5. 使用 Nginx 作为 Web 服务器
FROM nginx:alpine

# 6. 确保 `dist/` 目录被正确复制
COPY --from=build /app/dist/ /usr/share/nginx/html/

# 7. 复制 Nginx 配置（可选）
COPY nginx.conf /etc/nginx/nginx.conf

# 8. 公开端口
EXPOSE 80

# 9. 启动 Nginx
CMD ["nginx", "-g", "daemon off;"]