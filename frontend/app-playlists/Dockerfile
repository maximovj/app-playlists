# -----------------------------
# ETAPA 1 — BUILD (Node)
# -----------------------------
FROM node:20-alpine AS builder

WORKDIR /app

# Copiamos dependencias primero (cache eficiente)
COPY package*.json ./
RUN npm install

# Copiamos el resto del proyecto
COPY . .

# Build de producción (Vite)
RUN npm run build


# -----------------------------
# ETAPA 2 — SERVE (NGINX)
# -----------------------------
FROM nginx:alpine

# Eliminamos la config default
RUN rm /etc/nginx/conf.d/default.conf

# Copiamos nuestra config personalizada
COPY nginx.conf /etc/nginx/conf.d/

# Copiamos el build generado por Vite
COPY --from=builder /app/dist/app-playlists/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]