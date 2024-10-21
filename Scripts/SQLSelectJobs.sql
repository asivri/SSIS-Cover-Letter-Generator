SELECT 
	   [title]
      ,[company]
      ,[description]
  FROM [Jobs].[dbo].[Jobs]
  WHERE description IS NOT NULL
