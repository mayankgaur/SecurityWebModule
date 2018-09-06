USE [master]
GO

/****** Object:  Database [SecurityDB]    Script Date: 06-09-2018 20:53:12 ******/
CREATE DATABASE [SecurityDB1]
GO

/****** Object:  Table [dbo].[tbl_Locates]    Script Date: 06-09-2018 20:54:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Locates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsPublic] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Locates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GO


CREATE TABLE [dbo].[tbl_Security](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocatesId] [int] NOT NULL,
	[SecurityCode] [nvarchar](20) NULL,
	[ISIN] [nvarchar](20) NULL,
	[Sedol] [nvarchar](20) NULL,
	[Cusip] [nvarchar](20) NULL,
	[RIC] [nvarchar](20) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_Security] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_Security]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Security_tbl_Locates] FOREIGN KEY([LocatesId])
REFERENCES [dbo].[tbl_Locates] ([Id])
GO

ALTER TABLE [dbo].[tbl_Security] CHECK CONSTRAINT [FK_tbl_Security_tbl_Locates]
GO
 