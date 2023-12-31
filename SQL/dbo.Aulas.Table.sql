USE [APIs]
GO
ALTER TABLE [dbo].[Aulas] DROP CONSTRAINT [FK_Aulas_Usuarios]
GO
ALTER TABLE [dbo].[Aulas] DROP CONSTRAINT [FK_Aulas_Materias]
GO
/****** Object:  Table [dbo].[Aulas]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Aulas]') AND type in (N'U'))
DROP TABLE [dbo].[Aulas]
GO
/****** Object:  Table [dbo].[Aulas]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aulas](
	[materiasId] [numeric](18, 0) NOT NULL,
	[id] [numeric](18, 0) NOT NULL,
	[conteudo] [text] NULL,
	[dataCadastro] [datetime] NULL,
	[usuariosId] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Aulas] PRIMARY KEY CLUSTERED 
(
	[materiasId] ASC,
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aulas]  WITH CHECK ADD  CONSTRAINT [FK_Aulas_Materias] FOREIGN KEY([materiasId])
REFERENCES [dbo].[Materias] ([id])
GO
ALTER TABLE [dbo].[Aulas] CHECK CONSTRAINT [FK_Aulas_Materias]
GO
ALTER TABLE [dbo].[Aulas]  WITH CHECK ADD  CONSTRAINT [FK_Aulas_Usuarios] FOREIGN KEY([id])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Aulas] CHECK CONSTRAINT [FK_Aulas_Usuarios]
GO
