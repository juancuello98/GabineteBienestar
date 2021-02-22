#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:12.18.3 as node

ARG ENV=prod
ARG APP=gabinete-bienestar

ENV ENV ${ENV}
ENV APP ${APP}

WORKDIR /app
COPY ./ /app/

#Instala y construye el Angular app
RUN echo 'downloading dependecies'
RUN npm ci
RUN echo 'npm run build'
RUN npm run build --prod -- --base-href='/'

#Angular app construida, la vamos a hostear un server production.

FROM nginx:1

COPY --from=node /app/dist/gabineteBienestar /usr/share/nginx/html/
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

#When the container starts, replace the env.js with values from environment variables
CMD ["/bin/sh", "-c", "envsubst < /usr/share/nginx/html/assets/env.template.js > /usr/share/nginx/html/assets/env.js && exec nginx -g 'daemon off;'"]
