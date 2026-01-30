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

EXPOSE 3000
CMD ["npm", "start"]