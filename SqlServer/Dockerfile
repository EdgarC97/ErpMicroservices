# Usa la imagen oficial de SQL Server 2019
FROM mcr.microsoft.com/mssql/server:2019-latest

# Cambia a usuario root para ajustar permisos
USER root

# Cambia los permisos del binario sqlservr para asegurarte de que se pueda ejecutar
RUN chmod +x /opt/mssql/bin/sqlservr

# Opcional: Verifica los permisos (puedes eliminar esta línea en producción)
RUN ls -l /opt/mssql/bin/sqlservr

# Cambia de nuevo al usuario mssql (no-root) por seguridad
USER mssql

# Establece el comando por defecto
CMD ["/opt/mssql/bin/sqlservr"]
