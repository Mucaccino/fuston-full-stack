# Use the official Node.js image as a build stage
FROM node:14 AS build

WORKDIR /app
COPY . .

# Build the application
# RUN npm install
# RUN npm run build

# Use a smaller NGINX image for the final stage
# FROM nginx:1.21

# COPY --from=build /app/dist /usr/share/nginx/html
