USE [APIs]
GO
ALTER TABLE [dbo].[Grupos] DROP CONSTRAINT [FK_Grupos_Usuarios]
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 09/11/2023 20:39:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Grupos]') AND type in (N'U'))
DROP TABLE [dbo].[Grupos]
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 09/11/2023 20:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupos](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nome] [varchar](255) NULL,
	[dataCadastro] [datetime] NULL,
	[usuarioResponsavel] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grupos]  WITH CHECK ADD  CONSTRAINT [FK_Grupos_Usuarios] FOREIGN KEY([usuarioResponsavel])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Grupos] CHECK CONSTRAINT [FK_Grupos_Usuarios]
GO
