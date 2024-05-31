FROM mirror.gcr.io/library/postgres:16-alpine

RUN mkdir -p /var/log/postgresql/ && chmod -R 0777 /var/log/postgresql/

COPY sql_table.sql /docker-entrypoint-initdb.d/