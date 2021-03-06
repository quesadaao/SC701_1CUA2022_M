USE [AkiraToriyama]
GO
/****** Object:  Table [dbo].[Anime]    Script Date: 13/4/2022 11:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Creacion] [date] NULL,
	[Modificado] [date] NULL,
	[ModificadoPor] [nvarchar](50) NULL,
 CONSTRAINT [PK_Anime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Capitulo]    Script Date: 13/4/2022 11:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Creacion] [date] NULL,
	[Modificacion] [date] NULL,
	[ModificadoPor] [nvarchar](50) NULL,
	[IdTemporada] [int] NULL,
	[IdAnime] [int] NULL,
 CONSTRAINT [PK_Capitulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporada]    Script Date: 13/4/2022 11:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[CantidadCapitulos] [int] NULL,
	[Creacion] [date] NULL,
	[Modificacion] [date] NULL,
	[ModificadoPor] [nvarchar](50) NULL,
	[IdAnime] [int] NULL,
 CONSTRAINT [PK_Temporada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Capitulo_Anime] FOREIGN KEY([IdAnime])
REFERENCES [dbo].[Anime] ([Id])
GO
ALTER TABLE [dbo].[Capitulo] CHECK CONSTRAINT [FK_Capitulo_Anime]
GO
ALTER TABLE [dbo].[Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Capitulo_Temporada] FOREIGN KEY([IdTemporada])
REFERENCES [dbo].[Temporada] ([Id])
GO
ALTER TABLE [dbo].[Capitulo] CHECK CONSTRAINT [FK_Capitulo_Temporada]
GO
ALTER TABLE [dbo].[Temporada]  WITH CHECK ADD  CONSTRAINT [FK_Temporada_Anime] FOREIGN KEY([IdAnime])
REFERENCES [dbo].[Anime] ([Id])
GO
ALTER TABLE [dbo].[Temporada] CHECK CONSTRAINT [FK_Temporada_Anime]
GO
