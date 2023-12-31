USE [APIs]
GO
ALTER TABLE [dbo].[Materias] DROP CONSTRAINT [FK_Materias_Usuarios]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materias]') AND type in (N'U'))
DROP TABLE [dbo].[Materias]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[id] [numeric](18, 0) NOT NULL,
	[titulo] [varchar](150) NULL,
	[dataCadastro] [datetime] NULL,
	[usuariosId] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD  CONSTRAINT [FK_Materias_Usuarios] FOREIGN KEY([usuariosId])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Materias] CHECK CONSTRAINT [FK_Materias_Usuarios]
GO
