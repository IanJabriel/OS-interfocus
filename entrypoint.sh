#!/bin/sh
# Aguarda o banco de dados estar disponível
until pg_isready -h db -U "$DB_USER" -d "$DB_NAME"; do
  echo "Aguardando banco de dados..."
  sleep 5
done
echo "Banco de dados está disponível"