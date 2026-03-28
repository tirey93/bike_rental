FROM node:18-alpine

WORKDIR /app

# Kopiuj package.json
COPY ../frontend/car-rental/package*.json ./

# Instaluj
RUN npm install

# Kopiuj RESZTĘ, ale wyklucz node_modules
COPY ../frontend/car-rental/src ./src
COPY ../frontend/car-rental/public ./public
COPY ../frontend/car-rental/tsconfig.json ./

# Podmień consts.ts na wersję dockerową
COPY ../frontend/car-rental/src/consts.docker.ts ./src/consts.ts

EXPOSE 3000
CMD ["npm", "start"]