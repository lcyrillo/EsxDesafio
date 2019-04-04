create database DesafioESX
GO

create table marca
(
    MarcaId integer identity not null,
    Nome varchar(2000) not NULL
    constraint pk_marca primary key(MarcaId),
)
GO

create table patrimonio
(
    PatrimonioId integer identity not null,
    MarcaId integer not null,
    Nome varchar(2000) not null,
    Descricao varchar(2000) ,
    NumTombo varchar(255) not null,
    constraint pk_patrimonio primary key(PatrimonioId),
    constraint uq_patrimonio unique (NumTombo),
    constraint fk_patrimonio_marcaid foreign key (MarcaId) references marca(MarcaId)
)
GO