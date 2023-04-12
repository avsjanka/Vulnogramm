FROM node:18-alpine

WORKDIR /frontend
COPY . ./

EXPOSE 3000

RUN ls -la . && pwd
RUN npm install -g npm@9.6.4 && npm install

ENTRYPOINT npm run build