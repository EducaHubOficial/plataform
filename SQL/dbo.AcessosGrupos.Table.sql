USE [APIs]
GO
ALTER TABLE [dbo].[AcessosGrupos] DROP CONSTRAINT [FK_AcessosGrupos_Usuarios]
GO
ALTER TABLE [dbo].[AcessosGrupos] DROP CONSTRAINT [FK_AcessosGrupos_Acessos]
GO
/****** Object:  Table [dbo].[AcessosGrupos]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcessosGrupos]') AND type in (N'U'))
DROP TABLE [dbo].[AcessosGrupos]
GO
/****** Object:  Table [dbo].[AcessosGrupos]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcessosGrupos](
	[acessosId] [numeric](18, 0) NOT NULL,
	[gruposId] [numeric](18, 0) NOT NULL,
	[dataLancamento] [datetime] NULL,
	[usuarioResponsavel] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AcessosGrupos] PRIMARY KEY CLUSTERED 
(
	[acessosId] ASC,
	[gruposId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcessosGrupos]  WITH CHECK ADD  CONSTRAINT [FK_AcessosGrupos_Acessos] FOREIGN KEY([acessosId])
REFERENCES [dbo].[Acessos] ([id])
GO
ALTER TABLE [dbo].[AcessosGrupos] CHECK CONSTRAINT [FK_AcessosGrupos_Acessos]
GO
ALTER TABLE [dbo].[AcessosGrupos]  WITH CHECK ADD  CONSTRAINT [FK_AcessosGrupos_Usuarios] FOREIGN KEY([usuarioResponsavel])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[AcessosGrupos] CHECK CONSTRAINT [FK_AcessosGrupos_Usuarios]
GO
