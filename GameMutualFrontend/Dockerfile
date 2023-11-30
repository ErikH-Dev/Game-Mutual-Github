FROM node:lts-alpine

# set the working directory
WORKDIR /app

# install app dependencies
COPY package*.json ./

RUN npm install

# Bundle app source
COPY . .

# start app
CMD ["npm", "run", "serve"]
