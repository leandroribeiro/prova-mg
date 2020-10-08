#!/bin/bash

CONTAINER_NAME="provamg-db"
SA_PASSWORD="Dev123456789"

echo ""
echo "Seu nome de usuário é:"
whoami

echo ""
echo "Info de hora atual e tempo que o computador está ligado:"
uptime

echo ""
echo "O script está executando do diretório:"
pwd

echo ""

CONTAINER_ID=$(docker container ls --all --quiet --filter "name=$CONTAINER_NAME")

if [ -z $CONTAINER_ID ] 
then
   echo ""

else

   echo "Parando container"
   docker container stop $CONTAINER_ID

   sleep 5s

   # echo "Removendo container"
   # docker container rm --force $CONTAINER_ID

fi


echo ""
echo "Subindo novo container..."
docker run -e "ACCEPT_EULA=Y" \
   -e "MSSQL_SA_PASSWORD=$SA_PASSWORD" \
   -e "SA_PASSWORD=$SA_PASSWORD" \
   -e "MSSQL_PID=Developer" \
   --name $CONTAINER_NAME \
   --rm \
   -p 1401:1433 \
   -d microsoft/mssql-server-linux:latest


echo ""
echo "Copiando arquivos para o container..."
docker cp setup.sql provamg-db:/home
docker cp usuarios.csv provamg-db:/home
docker cp municipios.csv provamg-db:/home


echo ""
echo "Dê um tempo para o BD subir okay?"
sleep 30s


echo ""
echo "Testando Conexão..."
docker exec -it $CONTAINER_NAME /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases"


echo ""
echo "Criando estrutura..."
docker exec -it $CONTAINER_NAME /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P $SA_PASSWORD -d master -i /home/setup.sql


echo ""
echo "Importando dados..."
docker exec -it $CONTAINER_NAME /opt/mssql-tools/bin/bcp ProvaMG.dbo.tb_usuario in "/home/usuarios.csv" -c -t ',' -S localhost,1433 -U sa -P $SA_PASSWORD
docker exec -it $CONTAINER_NAME /opt/mssql-tools/bin/bcp ProvaMG.dbo.tb_tipo_municipio in "/home/municipios.csv" -c -t ',' -S localhost,1433 -U sa -P $SA_PASSWORD

echo ""
echo "Testando Conexão..."
docker exec -it $CONTAINER_NAME /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P $SA_PASSWORD -Q "SELECT Name FROM sys.Databases"

echo ""
echo "Tudo pronto =)"
echo ""