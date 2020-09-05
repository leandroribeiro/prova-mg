CREATE DATABASE ProvaMG;
GO

USE ProvaMG;
GO

CREATE TABLE tb_tipo_municipio
(
    tipo_municipio_cod           smallint identity         primary key,
    tipo_municipio_nome          varchar(255) not null,
    tipo_uf_cod                  smallint     not null,
    tipo_municipio_fazenda       varchar(5),
    tipo_municipio_ativo         bit          not null,
    tipo_municipio_cod_ext       varchar(5)   not null,
    tipo_municipio_id_rendimento int,
    tipo_municipio_uf            char(2)
)
GO

CREATE TABLE tb_usuario
(
    Id        smallint     not null         constraint PK_tb_usuario            primary key,
    mail      nvarchar(50) not null,
    password  varchar(50)  not null,
    is_active bit          not null
)
GO

CREATE INDEX IX_tb_usuario
    on tb_usuario (Id)
GO

