# Dockerfile personalizado para SQL Server 2019 en Render

# Usa la imagen oficial de SQL Server 2019
FROM mcr.microsoft.com/mssql/server:2019-latest

# Cambiar a usuario root para ajustar permisos
USER root

# Asegurarse de que el binario sqlservr tenga permisos de ejecución y que su propietario sea mssql
RUN chmod 755 /opt/mssql/bin/sqlservr && \
    chown mssql:mssql /opt/mssql/bin/sqlservr

# (Opcional) Puedes listar los permisos para verificar; en producción, podrías quitar esta línea
RUN ls -l /opt/mssql/bin/sqlservr

# Cambia de nuevo al usuario mssql para cumplir con las políticas de seguridad de Render
USER mssql

# Establece el comando por defecto para iniciar SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
