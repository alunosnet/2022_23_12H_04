create table utilizadores(
	ID int identity primary key,
	ID_Idoso int references Idosos(ID_Idoso),
	Email varchar(100) not null unique check (email like '%@%.%'),
	Nome varchar(100) not null check(len(nome) >3),
	Morada varchar(100) not null,
	Nif varchar(9) not null,
	password varchar(64) not null,
	sal int,
	perfil int not null check (perfil in ('0','1','2')),
	lnkRecuperar varchar(36),
	data_lnk date,
	RelacaoFamiliar varchar(100) check (len(RelacaoFamiliar)>2),
)

create table Idosos(
	ID_Idoso int identity primary key,
	NIF_Idoso varchar(9) NOT NULL unique,
	Nome_Idoso Varchar(100) NOT NULL check (len(Nome_Idoso)>=3),
	Data_Nasc date,
	Doencas varchar(100),
	NUtenteSaude Varchar(9) NOT NULL unique,
    Idade int,
	estado int not null,
)

create table Visitas(
	ID_Visita INT IDENTITY Primary Key,
	ID int references utilizadores(ID),
	ID_Idoso int references Idosos(ID_Idoso),
	DataVisita date,
	estado int, --2=>Reservado 1=>Em curso 0=>Terminado
)