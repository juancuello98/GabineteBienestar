#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:13.3.0 as node

ARG ENV-prod
ARG APP-bienestar

ENV ENV ${ENV}
ENV APP ${APP}

WORKDIR /gabineteBienestar
COPY ./ /gabineteBienestar/

RUN echo 'downloading dependecies'
RUN npm cl
RUN echo 'npm run build'
RUN npm run build --prod -- --base-href='/'
