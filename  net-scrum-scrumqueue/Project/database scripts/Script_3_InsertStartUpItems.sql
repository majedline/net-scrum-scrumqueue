USE [ScrumQueue]

-- TO ADMIN: YOU NEED MAKE A CHANGE HERE. CHANGE USERNAME, PASSOWRD, FIRST NAME AND LAST NAME
-- TO WHAT YOU WOULD LIKE BEFORE RUNNING THIS SCRIPT. OTHERWISE YOUR USERNAME AND PASSWORD WILL BE
--"UserName", "Password"

  INSERT INTO [ScrumQueue].[dbo].[Users]
           ([Username]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[DateCreated]
           ,[isAdmin])
     VALUES
           ('Username'
           ,'Password'
           ,'First Name'
           ,'Last Name'
           ,GETDATE()
           ,1)
GO
-- TO ADMIN: YOU ARE DONE. YOU CAN CONTINUE ON BELOW AND MAKE TEXT MODIFICATION BELOW 
-- I.E. ANYTHING BETWEEN ''


-- Add the default project
INSERT INTO [ScrumQueue].[dbo].[Projects]
           ([ProjectName]
           ,[ProjectDescription]
           ,[CreatedDate]
           ,[isDefault])
     VALUES
           ('Default', 
			'This is a default project that always existing within the database. This record must not be deleted',
			GETDATE(),
			1)
GO

-- Add Status Types
INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('Not Ready for work' ,'Task/Item in the backlog list with no User Story and not estimated. Need to make this ready!!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('Ready for work' ,'Task/Item in the backlog list with a User Story and is estimated! Nice, we are ready for work!!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('In Development' ,'Task/Item being developed. Lets make the change!!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('Functional Testing' ,'Task/Item being tested. Lets make sure the change is working!!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('Regression Testing' ,'Task/Item being tested (Regression). The change is working!! lets make sure nothing is broken!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('Ready For Live' ,'Task/Item is tested and ready for live. Almost There!!')
GO

INSERT INTO [ScrumQueue].[dbo].[StatusTypes]([Name],[Description])
VALUES('In Live' ,'Task/Item complete. Nice!!!!')
GO

-- TO ADMIN: I WOULDNT CHANGE THE ITEMS BELOW. 
-- GET USED TO THE SYSTEM AND YOU CAN CHANGE THEM LATER ON
-- Add the action types
INSERT INTO [ScrumQueue].[dbo].[HistoryTypes]([HistoryType],[HistoryDescription])
VALUES('Create', 'Created (i.e. Insert) Item')
GO

INSERT INTO [ScrumQueue].[dbo].[HistoryTypes]([HistoryType],[HistoryDescription])
VALUES('Edit', 'Edited (i.e. Update) Item')
GO

INSERT INTO [ScrumQueue].[dbo].[HistoryTypes]([HistoryType],[HistoryDescription])
VALUES('Delete', 'Deleted Item')
GO

INSERT INTO [ScrumQueue].[dbo].[HistoryTypes]([HistoryType],[HistoryDescription])
VALUES('Add Attachment', 'Added a new attachment to this Item')
GO

INSERT INTO [ScrumQueue].[dbo].[HistoryTypes]([HistoryType],[HistoryDescription])
VALUES('Delete Attachment', 'Deleted an attachment from this item')
GO
