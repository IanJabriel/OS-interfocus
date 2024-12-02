#!/bin/sh
set -e

# Aguarde até que o banco de dados esteja acessível
echo "Esperando o banco de dados em $DB_HOST:$DB_PORT..."
until nc -z $DB_HOST $DB_PORT; do
    sleep 1
done

echo "Banco de dados está acessível. Executando as migrações..."
dotnet ef database update

echo "Iniciando a aplicação..."
exec "$@"
