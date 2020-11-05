﻿$SA_PASSWORD='Dev123456789'

Write-Host "1/7) Parando containers em execução..."
docker stop $(docker ps -q)

Write-Host ""
Write-Host "2/7) Subindo novo container..."
docker run -e "ACCEPT_EULA=Y" `
   -e "MSSQL_SA_PASSWORD=$SA_PASSWORD" `
   -e "SA_PASSWORD=$SA_PASSWORD" `
   -e "MSSQL_PID=Developer" `
   --name "provamg-db" `
   --rm `
   -p 1401:1433 `
   -d microsoft/mssql-server-linux:latest

Write-Host ""
Write-Host "3/7) Copiando arquivos para o container..."
docker cp setup.sql provamg-db:/home
docker cp usuarios.csv provamg-db:/home
docker cp municipios.csv provamg-db:/home

Write-Host ""
Write-Host "4/7) Dê um tempo para o BD subir okay?"
Start-Sleep -s 5

Write-Host ""
Write-Host "5/7) Testando Conexão..."
docker exec -it provamg-db /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "$SA_PASSWORD" -Q "SELECT Name FROM sys.Databases"

Write-Host ""
Write-Host "6/7) Criando estrutura..."
docker exec -it provamg-db /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "$SA_PASSWORD" -d master -i /home/setup.sql

Write-Host ""
Write-Host "7/7) Importando dados..."
docker exec -it provamg-db /opt/mssql-tools/bin/bcp ProvaMG.dbo.tb_usuario in "/home/usuarios.csv" -c -t ',' -S localhost,1433 -U sa -P "$SA_PASSWORD"
docker exec -it provamg-db /opt/mssql-tools/bin/bcp ProvaMG.dbo.tb_tipo_municipio in "/home/municipios.csv" -c -t ',' -S localhost,1433 -U sa -P "$SA_PASSWORD"

Write-Host ""
Write-Host "*** Tudo pronto =) ***"
Write-Host ""