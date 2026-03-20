create database PatrimonioSenai
go

use PatrimonioSenai
go

create table Cidade(
	CidadeID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeCidade nvarchar(50) not null,
	Estado nvarchar(50) not null
)
go

create table Area(
	AreaID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeArea Nvarchar(50) not null
)
go

create table TipoUsuario(
	TipoUsuarioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeTipo nvarchar(50) not null
)
go

create table Cargo(
	CargoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeCargo nvarchar(50) not null
)
go

create table TipoPatrimonio(
	TipoPatrimonioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeTipo nvarchar(100) not null
)
go

create table StatusPatrimonio(
	StatusPatrimonioId UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Status] nvarchar(50)
)
go

create table TipoAlteracao(
	AlteracaoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	Tipo nvarchar(50) not null
)
go

create table [Local](
	LocalID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	Nome nvarchar(100) not null,
	LocalSAP int not null unique,
	DescricaoSAP nvarchar(100) not null,
	AreaId UNIQUEIDENTIFIER not null,
	constraint FK_Local_Area foreign key (AreaId)
		references Area(AreaID)
		on delete cascade
)
go

create table Patrimonio(
	PatrimonioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	Denominacao nvarchar(100) not null,
	NumeroSerie nvarchar(30) not null,
	Valor Decimal(10, 2) not null,
	Imagem VARCHAR(MAX) not null,
	LocalID uniqueidentifier,
	TipoPatrimonioID uniqueidentifier not null,
	StatusPatrimonioID uniqueidentifier not null,

	constraint FK_Patrimonio_Local foreign key (LocalID)
		references [Local](LocalId),

	constraint FK_Patrimonio_Tipo foreign key (TipoPatrimonioID)
		references TipoPatrimonio(TipoPatrimonioId),

	constraint FK_Patrimonio_Status foreign key (StatusPatrimonioID)
		references StatusPatrimonio(StatusPatrimonioID)
)
go

create table Bairro(
	BairroID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NomeBairro nvarchar(50),
	CidadeId uniqueidentifier not null,

	constraint FK_Bairro_Cidade foreign key (CidadeId)
		references Cidade(CidadeID)
		on delete cascade
)
go

create table Endereco(
	EnderecoID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY, 
	Logradouro nvarchar(100),
	Numero int not null,
	Complemento nvarchar(50),
	CEP varchar(10) not null,
	BairroID uniqueidentifier,

	constraint FK_Endereco_Bairro foreign key (BairroID)
		references Bairro(BairroId)
		on delete cascade
)
go

create table Usuario(
	UsuarioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	NIF varchar(7) not null unique,
	Nome nvarchar(150),
	RG varchar(15) not null unique,
	CPF nvarchar(11) not null unique,
	CarteiraTrabalho varchar(14) not null unique,
	Senha VARBINARY(32) not null,
	EnderecoID uniqueidentifier not null,
	CargoId uniqueidentifier not null,
	TipoUsuarioId uniqueidentifier not null,

	constraint FK_Endereco foreign key (EnderecoID) references Endereco(EnderecoId),
	constraint FK_Cargo foreign key (CargoID) references Cargo(CargoID) on delete cascade,
	constraint FK_Tipo foreign key (TipoUsuarioID) references TipoUsuario(TipoUsuarioID)
)
go

create table SolicitacaoTransferencia(
	TransferenciaID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	DataCriacaoSolitacao DATETIME2 not null,
	DataReposta DATETIME2 not null,
	Justificativa NVARCHAR(max) not null,
	StatusTransferencia UNIQUEIDENTIFIER not null,
	UsuarioIdSolicitacao UNIQUEIDENTIFIER not null,
	UsuarioIdReposta UNIQUEIDENTIFIER not null,
	PatrimonioID UNIQUEIDENTIFIER not null,
	LocalID UNIQUEIDENTIFIER not null,

