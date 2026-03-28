# App PlayLists

## Comandos para ejecutar la aplicación

```shell
# Acceder a la carpeta
$ cd ./app-playlists

# Ejecutar la aplicación
$ npm run start

# Construir la aplicación
$ npm run build
```

## Comandos para producción en docker

```shell
# Acceder a la carpeta
$ cd ./app-playlists

# Construir imagen para producción
$ docker build -t app-playlists-frontend .

# Ejecutar en modo producción
$ docker run -p 4200:80 app-playlists-frontend
```