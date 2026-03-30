# ── Stage 1: Build ────────────────────────────────────────────────────────────
FROM node:22-alpine AS build
WORKDIR /app

COPY src/client/package*.json ./
RUN npm ci

COPY src/client/ .
RUN npm run build

# ── Stage 2: Serve with Nginx ─────────────────────────────────────────────────
FROM nginx:1.27-alpine AS runtime

COPY src/client/nginx.conf /etc/nginx/conf.d/default.conf
# Angular 21 with @angular/build:application outputs to dist/{project}/browser
COPY --from=build /app/dist/client/browser /usr/share/nginx/html

EXPOSE 80