USE [APIs]
GO
ALTER TABLE [dbo].[AcessosUsuarios] DROP CONSTRAINT [FK_AcessosUsuarios_Usuarios1]
GO
ALTER TABLE [dbo].[AcessosUsuarios] DROP CONSTRAINT [FK_AcessosUsuarios_Usuarios]
GO
ALTER TABLE [dbo].[AcessosUsuarios] DROP CONSTRAINT [FK_AcessosUsuarios_Acessos]
GO
/****** Object:  Table [dbo].[AcessosUsuarios]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AcessosUsuarios]') AND type in (N'U'))
DROP TABLE [dbo].[AcessosUsuarios]
GO
/****** Object:  Table [dbo].[AcessosUsuarios]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcessosUsuarios](
	[acessosId] [numeric](18, 0) NOT NULL,
	[usuariosId] [numeric](18, 0) NOT NULL,
	[dataLancamento] [datetime] NULL,
	[usuarioResponsavel] [numeric](18, 0) NULL,
 CONSTRAINT [PK_AcessosUsuarios] PRIMARY KEY CLUSTERED 
(
	[acessosId] ASC,
	[usuariosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcessosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_AcessosUsuarios_Acessos] FOREIGN KEY([acessosId])
REFERENCES [dbo].[Acessos] ([id])
GO
ALTER TABLE [dbo].[AcessosUsuarios] CHECK CONSTRAINT [FK_AcessosUsuarios_Acessos]
GO
ALTER TABLE [dbo].[AcessosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_AcessosUsuarios_Usuarios] FOREIGN KEY([usuariosId])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[AcessosUsuarios] CHECK CONSTRAINT [FK_AcessosUsuarios_Usuarios]
GO
ALTER TABLE [dbo].[AcessosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_AcessosUsuarios_Usuarios1] FOREIGN KEY([usuarioResponsavel])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[AcessosUsuarios] CHECK CONSTRAINT [FK_AcessosUsuarios_Usuarios1]
GO
