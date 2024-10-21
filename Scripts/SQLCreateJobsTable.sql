SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jobs](
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[title] [nvarchar](100) NULL,
	[company] [nvarchar](50) NULL,
	[location] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


