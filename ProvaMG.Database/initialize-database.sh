#!/bin/bash

DBHOST=localhost;
DBPORT=1433;
DBNAME=ProvaMG;

echo "Dando um tempo para o banco subir =\ MSSQL tem essas coisas ...";
sleep 30s;

echo "1/4 ) Criando estrutura do banco de dados";
/opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -i /home/setup.sql;

echo "2/4 ) Consultando os bancos de dados";
/opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases";

DBEXISTS=$(/opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases WHERE [Name] LIKE '%$DBNAME%'" | grep "$DBNAME")


while [ -z "$DBEXISTS" ]
do
    sleep 10s;
    echo "";
    echo "Tentativa de Conexao...";
    
    DBEXISTS=$(/opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases WHERE [Name] LIKE '%$DBNAME%'" | grep "$DBNAME")
     
done


if [ -n "$DBEXISTS" ]
then
  echo "";
  echo "3/4 Carregando Usuarios";
  /opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -Q "TRUNCATE table $DBNAME.dbo.tb_usuario";
  /opt/mssql-tools/bin/bcp $DBNAME.dbo.tb_usuario in "/home/usuarios.csv" -c -t ',' -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD;

  echo "";
  echo "4/4 Carregando Municipios";
  /opt/mssql-tools/bin/sqlcmd -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD -Q "TRUNCATE table $DBNAME.dbo.tb_tipo_municipio";
  /opt/mssql-tools/bin/bcp $DBNAME.dbo.tb_tipo_municipio in "/home/municipios.csv" -c -t ',' -S $DBHOST,$DBPORT -U sa -P $SA_PASSWORD;
  
fi