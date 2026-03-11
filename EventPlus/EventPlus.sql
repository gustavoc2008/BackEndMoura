CREATE DATABASE EventPlus;

USE EventPlus;

CREATE TABLE TipoUsuario(
	IDTipoUsuario		UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),
	Titulo				NVARCHAR(50)										NOT NULL
);

CREATE TABLE TipoEvento(
	IDTipoEvento		UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	Titulo				NVARCHAR(100)										NOT NULL			
);

CREATE TABLE Instituicao(
	IDInstituicao		UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	NomeFantasia		NVARCHAR(100),													
	Endereco			NVARCHAR(100),													
	CNPJ				NVARCHAR(14)										NOT NULL	UNIQUE															
);

CREATE TABLE Usuario(
	IDUsuario			UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	Nome				NVARCHAR(100)										NOT NULL,													
	Email				NVARCHAR(256)										NOT NULL UNIQUE,													
	Senha				NVARCHAR(60)										NOT NULL,
	
	IDTipoUsuario		UNIQUEIDENTIFIER	FOREIGN KEY	REFERENCES TipoUsuario(IDTipoUsuario)
);

CREATE TABLE Evento(
	IDEvento			UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	Nome				NVARCHAR(100)										NOT NULL,			
	DataEvento			DATETIME											NOT NULL,				
	Descricao			TEXT												NOT NULL,
	
	IDTipoEvento		UNIQUEIDENTIFIER	FOREIGN KEY REFERENCES TipoEvento(IDTipoEvento),
	IDInstituicao		UNIQUEIDENTIFIER	FOREIGN KEY REFERENCES Instituicao(IDInstituicao)
);

CREATE TABLE Presenca(
	IDPresenca			UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	Situacao			BIT													NOT NULL,	
	
	IDEvento			UNIQUEIDENTIFIER	FOREIGN KEY	REFERENCES Evento(IDEvento),
	IDUsuario			UNIQUEIDENTIFIER	FOREIGN KEY REFERENCES Usuario(IDUsuario)
);

CREATE TABLE ComentarioEvento(
	IDComentarioEvento	UNIQUEIDENTIFIER				PRIMARY KEY			DEFAULT ((NEWID())),			
	Descricao			NVARCHAR(200)										NOT NULL,													
	DataComentario		DATETIME											NOT NULL,															
	Exibe				BIT													NOT NULL,
	
	IDEvento			UNIQUEIDENTIFIER	FOREIGN KEY REFERENCES Evento(IDEvento),
	IDUsuario			UNIQUEIDENTIFIER	FOREIGN KEY	REFERENCES Usuario(IDUsuario)
);


