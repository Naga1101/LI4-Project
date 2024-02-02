CREATE DATABASE JBLeiloes;
GO

USE [JBLeiloes]
GO
/*** Tabela [dbo].[Histórico de compras] ***/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historico de compras](
    [cliente] [varchar](50) NOT NULL,
    [id_leilao] [int] NOT NULL,
    [id_historico_compras] [int] IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_Histórico de compras] PRIMARY KEY CLUSTERED 
    (
        [id_historico_compras] ASC
    ) WITH (
        PAD_INDEX = OFF,
        STATISTICS_NORECOMPUTE = OFF,
        IGNORE_DUP_KEY = OFF,
        ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON,
        OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
    ) ON [PRIMARY]
) ON [PRIMARY]
GO
/*** Tabela [dbo].[Histórico de vendas]  ***/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historico de vendas](
	[cliente] [varchar](50) NOT NULL,
	[id_leilao] [int] NOT NULL,
	[id_historico_vendas] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Histórico de vendas] PRIMARY KEY CLUSTERED 
(
	[id_historico_vendas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*** Tabela [dbo].[Leilão] ***/

/** aprovado = 1 | nao-aprovado = 0**/
/** a_decorrer = 1 | acabados = 0**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leilao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[valor_inicial] [decimal](8, 2) NOT NULL,
	[vendedor] [varchar](50) NOT NULL,
	[valor_minimo] [decimal](8, 2) NOT NULL,
	[valor_atual] [decimal](18, 0) NOT NULL,
	[veiculo] [int] NOT NULL,
	[aprovado] [bit] NOT NULL,
	[a_decorrer] [bit] NOT NULL,
	[comprador] [varchar](50) NULL,
    [tempo_de_leilao] [datetime] NOT NULL,
	[imagem] [varchar](50) NULL,
	[Pago] [bit] NOT NULL,
 CONSTRAINT [PK_Leilao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*** Tabela [dbo].[Licitação]  ***/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licitacao](
	[id_licitacao] [int] IDENTITY(1,1) NOT NULL,
	[id_licitador] [varchar](50) NOT NULL,
	[valor_licitacao] [decimal](8, 2) NOT NULL,
	[id_leilao] [int] NOT NULL,
 CONSTRAINT [PK_licitacao] PRIMARY KEY CLUSTERED 
(
	[id_licitacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*** Tabela [dbo].[Utilizador] ***/

/** tipo utilizador - admin = 0 | normal = 1**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[CC] [int] NOT NULL,
	[NIF] [int] NOT NULL,
	[data_nascimento] [date] NOT NULL,
	[tipo_utilizador] [tinyint] NOT NULL,
 CONSTRAINT [PK_Utilizador] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*** Tabela [dbo].[Veículo] ***/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veiculo](
	[id] [int] IDENTITY(1,1) NOT NULL, 
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Ano] [int] NOT NULL,
	[Quilometragem] [decimal](8, 2) NOT NULL,
	[DUA] [varchar](50) NOT NULL,
	[Seguro] [varchar](50) NOT NULL,
	[dono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*** Tabela [dbo].[Watchlist] ***/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Watchlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [varchar](50) NOT NULL,
	[id_leilao] [int] NULL,
 CONSTRAINT [PK_Watchlist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Historico de compras]  WITH CHECK ADD  CONSTRAINT [FK_Historico de compras_Leilao] FOREIGN KEY([id_leilao])
REFERENCES [dbo].[Leilao] ([id])
GO
ALTER TABLE [dbo].[Historico de compras] CHECK CONSTRAINT [FK_Historico de compras_Leilao]
GO
ALTER TABLE [dbo].[Historico de compras]  WITH CHECK ADD  CONSTRAINT [FK_Historico de compras_Utilizador] FOREIGN KEY([cliente])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Historico de compras] CHECK CONSTRAINT [FK_Historico de compras_Utilizador]
GO
ALTER TABLE [dbo].[Historico de vendas]  WITH CHECK ADD  CONSTRAINT [FK_Historico de vendas_Leilao] FOREIGN KEY([id_leilao])
REFERENCES [dbo].[Leilao] ([id])
GO
ALTER TABLE [dbo].[Historico de vendas] CHECK CONSTRAINT [FK_Historico de vendas_Leilao]
GO
ALTER TABLE [dbo].[Historico de vendas]  WITH CHECK ADD  CONSTRAINT [FK_Historico de vendas_Utilizador] FOREIGN KEY([cliente])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Historico de vendas] CHECK CONSTRAINT [FK_Historico de vendas_Utilizador]
GO
ALTER TABLE [dbo].[Leilao]  WITH CHECK ADD  CONSTRAINT [FK_Leilao_Utilizador] FOREIGN KEY([vendedor])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Leilao] CHECK CONSTRAINT [FK_Leilao_Utilizador]
GO
ALTER TABLE [dbo].[Leilao]  WITH CHECK ADD  CONSTRAINT [FK_Leilao_Utilizador1] FOREIGN KEY([comprador])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Leilao] CHECK CONSTRAINT [FK_Leilao_Utilizador1]
GO
ALTER TABLE [dbo].[Leilao]  WITH CHECK ADD  CONSTRAINT [FK_Leilao_Veículo] FOREIGN KEY([veiculo])
REFERENCES [dbo].[Veiculo] ([id])
GO
ALTER TABLE [dbo].[Leilao] CHECK CONSTRAINT [FK_Leilao_Veículo]
GO
ALTER TABLE [dbo].[Licitacao]  WITH CHECK ADD  CONSTRAINT [FK_Licitacao_Leilao] FOREIGN KEY([id_leilao])
REFERENCES [dbo].[Leilao] ([id])
GO
ALTER TABLE [dbo].[Licitacao] CHECK CONSTRAINT [FK_Licitacao_Leilao]
GO
ALTER TABLE [dbo].[Licitacao]  WITH CHECK ADD  CONSTRAINT [FK_Licitacao_Utilizador] FOREIGN KEY([id_licitador])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Licitacao] CHECK CONSTRAINT [FK_Licitacao_Utilizador]
GO
ALTER TABLE [dbo].[Veiculo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_Utilizador] FOREIGN KEY([dono])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Veiculo] CHECK CONSTRAINT [FK_Veiculo_Utilizador]
GO
ALTER TABLE [dbo].[Watchlist]  WITH CHECK ADD  CONSTRAINT [FK_Watchlist_Leilao] FOREIGN KEY([id_leilao])
REFERENCES [dbo].[Leilao] ([id])
GO
ALTER TABLE [dbo].[Watchlist] CHECK CONSTRAINT [FK_Watchlist_Leilao]
GO
ALTER TABLE [dbo].[Watchlist]  WITH CHECK ADD  CONSTRAINT [FK_Watchlist_Utilizador] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Utilizador] ([username])
GO
ALTER TABLE [dbo].[Watchlist] CHECK CONSTRAINT [FK_Watchlist_Utilizador]
GO