USE [APIs]
GO
ALTER TABLE [dbo].[GruposUsuarios] DROP CONSTRAINT [FK_GruposUsuarios_Usuarios1]
GO
ALTER TABLE [dbo].[GruposUsuarios] DROP CONSTRAINT [FK_GruposUsuarios_Usuarios]
GO
ALTER TABLE [dbo].[GruposUsuarios] DROP CONSTRAINT [FK_GruposUsuarios_Grupos]
GO
/****** Object:  Table [dbo].[GruposUsuarios]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GruposUsuarios]') AND type in (N'U'))
DROP TABLE [dbo].[GruposUsuarios]
GO
/****** Object:  Table [dbo].[GruposUsuarios]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GruposUsuarios](
	[gruposId] [numeric](18, 0) NOT NULL,
	[usuariosId] [numeric](18, 0) NOT NULL,
	[dataCadastro] [datetime] NULL,
	[usuarioResponsavel] [numeric](18, 0) NULL,
 CONSTRAINT [PK_GruposUsuarios] PRIMARY KEY CLUSTERED 
(
	[gruposId] ASC,
	[usuariosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GruposUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_GruposUsuarios_Grupos] FOREIGN KEY([gruposId])
REFERENCES [dbo].[Grupos] ([id])
GO
ALTER TABLE [dbo].[GruposUsuarios] CHECK CONSTRAINT [FK_GruposUsuarios_Grupos]
GO
ALTER TABLE [dbo].[GruposUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_GruposUsuarios_Usuarios] FOREIGN KEY([usuariosId])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[GruposUsuarios] CHECK CONSTRAINT [FK_GruposUsuarios_Usuarios]
GO
ALTER TABLE [dbo].[GruposUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_GruposUsuarios_Usuarios1] FOREIGN KEY([usuarioResponsavel])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[GruposUsuarios] CHECK CONSTRAINT [FK_GruposUsuarios_Usuarios1]
GO
