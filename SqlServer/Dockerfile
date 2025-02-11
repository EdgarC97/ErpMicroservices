# Dockerfile personalizado para SQL Server 2019 en Render

# Usa la imagen oficial de SQL Server 2019
FROM mcr.microsoft.com/mssql/server:2019-latest

# Cambia a usuario root para ajustar permisos
USER root

# Ajusta los permisos del binario sqlservr y cambia el propietario a mssql sin especificar grupo
RUN chmod 755 /opt/mssql/bin/sqlservr && chown mssql /opt/mssql/bin/sqlservr

# (Opcional) Verifica los permisos; en producción podrías quitar esta línea
RUN ls -l /opt/mssql/bin/sqlservr

# Cambia de nuevo al usuario mssql para cumplir con las políticas de seguridad de Render
USER mssql

# Establece el comando por defecto para iniciar SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
