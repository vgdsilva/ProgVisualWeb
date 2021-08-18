﻿CREATE DATABASE ProgVisual;
USE ProgVisual;

-- Produto 
CREATE TABLE PRODUTO (
   IDPRODUTO NUMERIC(18,0),
   CODIGO NUMERIC(8),
   CODIGOBARRAS VARCHAR(30),
   DESCRICAO VARCHAR(250),
   PRECO NUMERIC(7,2),
   IDCATEGORIA NUMERIC(18,0),
   FORNECEDOR VARCHAR(150),
   MARCA VARCHAR(150),
   
   PRIMARY KEY (IDPRODUTO),
   FOREIGN KEY (IDCATEGORIA) REFERENCES CATEGORIA(IDCATEGORIA)   
);
CREATE SEQUENCE IDPRODUTO START 1
SELECT NEXTVAL('IDPRODUTO');
ALTER SEQUENCE IDPRODUTO RESTART 1;

SELECT * FROM PRODUTO

-- Categoria 
CREATE TABLE CATEGORIA(
   IDCATEGORIA NUMERIC(18,0),
   CODIGO NUMERIC(10),
   DESCRICAO VARCHAR(150),

   PRIMARY KEY (IDCATEGORIA)
);
CREATE SEQUENCE IDCATEGORIA START 1
SELECT NEXTVAL('IDCATEGORIA');
ALTER SEQUENCE IDPRODUTO RESTART 1;

SELECT * FROM CATEGORIA