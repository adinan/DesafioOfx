FROM mcr.microsoft.com/mssql/rhel/server:2019-CU1-rhel-8
RUN mkdir -p /usr/work
WORKDIR /usr/work
COPY . /usr/work/

EXPOSE 1433
RUN echo $(python -c 'print(" \033[31m Aguardando 60 segundos o provisionamento e start do banco \033[0m ")')
CMD /bin/bash ./entrypoint.sh