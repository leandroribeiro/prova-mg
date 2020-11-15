#!/bin/bash
DBNAME=ProvaMG

echo "Dando um tempo para o banco subir =\ MSSQL tem essas coisas ..."
sleep 60s

echo "1/4 ) Criando estrutura do banco de dados" 
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -i /home/setup.sql

echo "2/4 ) Consultando os bancos de dados"
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases" 

# DBEXISTS=$(/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases WHERE [Name] LIKE '%$DBNAME%'" | grep "$DBNAME" > "1"; echo "0")

# if [ $DBEXISTS -eq 1 ];then

  # DATAEMPTY=$(/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -Q "SELECT COUNT(*) FROM $DBNAME.dbo.tb_usuario" | grep "0" > echo "1" ; echo "0")

  # if [ $DATAEMPTY -eq 1 ];then  
    
    echo "3/4 Carregando massa de dados"
    /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -Q "TRUNCATE table tb_usuario"
    /opt/mssql-tools/bin/bcp $DBNAME.dbo.tb_usuario in "/home/usuarios.csv" -c -t ',' -S localhost,1433 -U sa -P $SA_PASSWORD
  
    echo "4/4 Carregando massa de dados"
    /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P $SA_PASSWORD -Q "TRUNCATE table tipo_municipio_cod"
    /opt/mssql-tools/bin/bcp $DBNAME.dbo.tb_tipo_municipio in "/home/municipios.csv" -c -t ',' -S localhost,1433 -U sa -P $SA_PASSWORD
    
  # else
    # echo "4/4 Dados já estão carregados!!"
    
  # fi
   
# fi