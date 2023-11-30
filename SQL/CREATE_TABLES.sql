USE [local]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 11/30/2023 12:02:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Name] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[FinancialInstrument](
	[Id] [uniqueidentifier] NOT NULL,
	[MarketValue] [numeric](18, 2) NOT NULL,
	[Type] [varchar](max) NULL,
	[CategoryId] [uniqueidentifier] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[FinancialInstrument]  WITH CHECK ADD  CONSTRAINT [FK_FinancialInstrument_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[FinancialInstrument] CHECK CONSTRAINT [FK_FinancialInstrument_Category]
GO



