CREATE TABLE [dbo].[Login](
	[Id] [varchar](250) NOT NULL,
	[Usuario] [varchar](250) NULL,
	[Senha] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Perfil] [varchar](50) NULL,
	[Informacoes] [varchar](MAX) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Vacinacao](
	[Id] [varchar](250) NOT NULL,
	[Nome] [varchar](250) NULL,
	[Data] Datetime NULL,
	[Informacoes] [varchar](MAX) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Contato](
	[Id] [varchar](250) NOT NULL,
	[Telefone] [varchar](250) NULL,
	[Celular] [varchar](250) NULL,
	[Email] [varchar](250) NULL,
	[Informacoes] [varchar](MAX) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Endereco](
	[Id] [varchar](250) NOT NULL,
	[Logradouro] [varchar](250) NULL,
	[Numero] [varchar](250) NULL,
	[Bairro] [varchar](250) NULL,
	[Complemento] [varchar](250) NULL,
	[Cep] [varchar](8) NULL,
	[Municipio] [varchar](250) NULL,
	[Uf] [varchar](2) NULL,
	[Informacoes] [varchar](MAX) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Animal](
	[Id] [varchar](250) NOT NULL,
	[Especie] [varchar](150) NULL,
	[Nome] [varchar](150) NULL,
	[Peso] [varchar](150) NULL,
	[Cor] [varchar](150) NULL,
	[Idade] [varchar](150) NULL,
	[DataInclusao] Datetime NULL,
	[DataAdocao] Datetime NULL,
	[DescricaoLocalEncontrado] [varchar](MAX) NULL,
	[Status] int NULL,
	[Informacoes] [varchar](MAX) NULL,
	[Vacinas] [varchar](250) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Animal]
ADD FOREIGN KEY ([Vacinas]) REFERENCES Vacinacao(Id);

//----------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[Pessoa](
	[Id] [varchar](250) NOT NULL,
	[Nome] [varchar](150) NULL,
	[DataInclusao] Datetime NULL,
	[Informacoes] [varchar](MAX) NULL,
	[Endereco] [varchar](250) NULL,
	[Contato] [varchar](250) NULL,
	[Login] [varchar](250) NULL,
	[AnimaisAdotados] [varchar](250) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Pessoa]
ADD FOREIGN KEY ([AnimaisAdotados]) REFERENCES Animal(Id);

ALTER TABLE [dbo].[Pessoa]
ADD FOREIGN KEY ([Login]) REFERENCES Login(Id);

ALTER TABLE [dbo].[Pessoa]
ADD FOREIGN KEY ([Contato]) REFERENCES Contato(Id);

ALTER TABLE [dbo].[Pessoa]
ADD FOREIGN KEY ([Endereco]) REFERENCES Endereco(Id);