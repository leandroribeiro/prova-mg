FROM mcr.microsoft.com/mssql/server

USER root

ENV CHECK_POLICY=OFF
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Dev123456789
ENV MSSQL_PID=Developer

COPY "ProvaMG.Database/" /home

RUN chmod +x /home/entrypoint.sh
RUN chmod +x /home/initialize-database.sh

CMD [ "/bin/bash", "/home/entrypoint.sh" ]