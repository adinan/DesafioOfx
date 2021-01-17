#aguardando 60 segundos para aguardar o provisionamento e start do banco
sleep 60s
#rodar o comando para criar o banco
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "Qwe@123senhoraforte" -i criacao-banco-docker.sql