# Use an official Node.js runtime as a parent image
FROM node:16-alpine as build

# Set the working directory to /app
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the app's code to the container
COPY . .

# Build the app using Vite
RUN npm run build

#COPY . ./
# CMD ["npm", "run", "prod"]

# Use Nginx as the base image for serving the app
FROM nginx:stable-alpine

# Copy the build files from the previous stage to the nginx directory
COPY --from=build /app/dist /usr/share/nginx/html

# Copy the nginx configuration file to the container
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80 to the Docker host
EXPOSE 80

# Start Nginx in the foreground
CMD ["nginx", "-g", "daemon off;"]