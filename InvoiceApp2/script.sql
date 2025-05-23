USE [InvoiceApp2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[InvoiceNumber] [nvarchar](50) NULL,
	[Amount] [decimal](10, 2) NULL,
	[Date] [date] NULL,
	[Vendor] [nvarchar](100) NULL,
	[Status] [nvarchar](20) NULL,
	[FilePath] [nvarchar](500) NULL,
	[Email] [varchar](255) NULL,
	[ExtractedText] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
