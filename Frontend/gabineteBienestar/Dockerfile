#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:13.3.0 as node

ARG ENV-prod
ARG APP-gabineteBienestar

ENV ENV ${ENV}
ENV APP ${APP}

WORKDIR /app
COPY ./ /app/

RUN echo 'downloading dependecies'
RUN npm ci
RUN echo 'npm run build'
#RUN npm run build --prod -- --base-href='/'

FROM nginx:1

COPY --from=node /app/dist/ /user/share/nginx/html/
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

CMD ["/bin/sh", "-c", "envsubst < /user/share/nginx/html/assets/env.template.js > /user/share/nginx/html/assets/env.js && exec nginx -g 'deamon off;'"]
