USE [ScrumQueue]
GO
/****** Object:  Table [dbo].[HistoryTypes]    Script Date: 01/28/2012 23:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HistoryTypes](
	[HistoryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[HistoryType] [varchar](50) NULL,
	[HistoryDescription] [varchar](200) NULL,
 CONSTRAINT [PK_HistoryTypes] PRIMARY KEY CLUSTERED 
(
	[HistoryTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01/28/2012 23:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[ProjectDescription] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[isDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 01/28/2012 23:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusTypes](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_StatusTypes] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/28/2012 23:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DateCreated] [datetime] NOT NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SaveProject]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		majed Atwi
-- Create date: oct 11
-- Description:	create or update project
-- =============================================
CREATE PROCEDURE [dbo].[SaveProject]
	@ProjectID		int,
	@ProjectName	varchar(50),
	@ProjectDescription varchar(100)
	
AS
BEGIN
	SET NOCOUNT ON;

	-- CREATE NEW PROJECT
	IF (@ProjectID = -1)
	BEGIN
		INSERT INTO [dbo].[Projects]
				([ProjectName],[ProjectDescription], [CreatedDate]) 
		VALUES	(@ProjectName, @ProjectDescription, getDate())
	END

	IF (@ProjectID <> -1)
	BEGIN
		
		-- UPDATE NAME AND DESC
		IF (LEN(LTRIM(RTRIM(@ProjectName))) > 0 AND LEN(LTRIM(RTRIM(@ProjectDescription)))> 0)
		BEGIN
			UPDATE	[dbo].[Projects] 
			SET		[ProjectName] = @ProjectName,[ProjectDescription] = @ProjectDescription
			WHERE	ProjectID = @ProjectID
			-- RETURN THE NEW ID
			SELECT max(projectID) 'projectID' FROM [dbo].[Projects] 
		END

		-- UPDATE NAME BUT NOT NAME DESC
		IF (LEN(LTRIM(RTRIM(@ProjectName))) > 0 AND LEN(LTRIM(RTRIM(@ProjectDescription))) <= 0)
		BEGIN
			UPDATE	[dbo].[Projects] 
			SET		[ProjectName] = @ProjectName
			WHERE	ProjectID = @ProjectID
			-- RETURN THE ORIGINAL ID
			SELECT @ProjectID 'projectID'
		END

		-- UPDATE DES BUT NOT NAME
		IF (LEN(LTRIM(RTRIM(@ProjectName))) <= 0 AND LEN(LTRIM(RTRIM(@ProjectDescription)))> 0)
		BEGIN
			UPDATE	[dbo].[Projects] 
			SET		[ProjectDescription] = @ProjectDescription
			WHERE	ProjectID = @ProjectID
			-- RETURN THE ORIGINAL ID
			SELECT @ProjectID 'projectID'
		END

	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	User Update User
-- =============================================


CREATE PROCEDURE [dbo].[UpdateUser]
	@Username varchar(50),
	@Password varchar(50),
	@FirstName varchar(50), 
	@LastName varchar(50),
	@IsAdmin varchar(50)
	
	
AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update	[dbo].Users 
	SET		[Password] = @Password,
			[FirstName] = @FirstName, 
			[LastName] = @LastName,
			[IsAdmin] = @IsAdmin
	Where	[Username] = @Username

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStatusType]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Majed Atwi
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStatusType] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name varchar(50),
	@Description varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE	[ScrumQueue].[dbo].[StatusTypes]
	SET		[Name] = @Name,
			[Description] = @Description
	WHERE	StatusID = @ID



END
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	User Log in to the system
-- =============================================
CREATE PROCEDURE [dbo].[LoginUser]
	@Username varchar(50),
	@Password varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	UserID, Username, FirstName, LastName, DateCreated, isAdmin
	FROM	dbo.[Users]
	WHERE	Username = @Username
	AND		[Password] = @Password
END
GO
/****** Object:  Table [dbo].[Items]    Script Date: 01/28/2012 23:56:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Note] [varchar](200) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[EditDate] [datetime] NOT NULL,
	[EditedBy] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	User Log in to the system
-- =============================================


CREATE PROCEDURE [dbo].[InsertUser]
	@Username varchar(50),
	@Password varchar(50),
	@FirstName varchar(50), 
	@LastName varchar(50),
	@isAdmin varchar(50)
	
AS
BEGIN
	DECLARE @DateCreated datetime

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Set @DateCreated = getDate()

    -- Insert statements for procedure here
	Insert Into	[dbo].Users ([Username], [Password], [FirstName], [LastName], [DateCreated], [isAdmin])
	Values (@Username, @Password, @FirstName, @LastName, @DateCreated, @isAdmin)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertStatusType]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Majed Atwi
-- =============================================
CREATE PROCEDURE [dbo].[InsertStatusType] 
	-- Add the parameters for the stored procedure here
	@Name varchar(50),
	@Description varchar(200)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ScrumQueue].[dbo].[StatusTypes]
           ([Name],[Description])
     VALUES(@Name,@Description)
	
	Select StatusID = SCOPE_IDENTITY()   
     
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		 Majed
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [UserID]
		  ,[Username]
		  ,[Password]
		  ,[FirstName]
		  ,[LastName]
		  ,[DateCreated]
		  ,[isAdmin]
	FROM [ScrumQueue].[dbo].[Users]

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStatusTypes]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		majed
-- Create date: Oct 08 2011
-- Description:	Get all items to load
-- =============================================
CREATE PROCEDURE [dbo].[GetAllStatusTypes]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [StatusID]
      ,[Name]
      ,[Description]
	FROM [ScrumQueue].[dbo].[StatusTypes]
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProjects]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Oct 12, 08
-- Description:	Get All projects
-- =============================================
CREATE PROCEDURE [dbo].[GetAllProjects]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	[ProjectID],[ProjectName],[ProjectDescription]
	FROM	[dbo].[Projects]
END
GO
/****** Object:  StoredProcedure [dbo].[CheckUserNameExist]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Se[t 21 2011
-- Description:	Check if the username already exist
-- =============================================
CREATE PROCEDURE [dbo].[CheckUserNameExist]
	@Username varchar(50)

AS
BEGIN	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	If (Select Count(1)from Users where UserName = @Username) > 0
	Begin
		Select u.UserID from Users u where UserName = @Username
	end
	else
	begin
		Select -1
	end

END
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 01/28/2012 23:56:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attachments](
	[AttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Name] [varchar](200) NULL,
	[CreateDate] [datetime] NULL,
	[FileName] [varchar](200) NOT NULL,
	[FileType] [varchar](50) NOT NULL,
	[FileSize] [int] NOT NULL,
	[FileOriginalLocation] [varchar](200) NOT NULL,
	[FileData] [varbinary](max) NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetAllItemsBasedOnStatusType]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Get all Items. iF INPUT = -1, then get all items, otherwise get it based on the input
-- =============================================
CREATE PROCEDURE [dbo].[GetAllItemsBasedOnStatusType]
	@StatusID int,
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @StatusID = -1 
	BEGIN
		SELECT  ItemID, Title, Note, CreateDate, I.CreatedBy, U1.FirstName+' '+U1.LastName 'CreatedByName', EditDate, I.EditedBy, U2.FirstName+' '+U2.LastName 'EditedByName', I.StatusID, S.Name
		FROM    Items I inner join StatusTypes S on I.StatusID = S.StatusID
						inner join dbo.Users U1 on I.createdBy = U1.userID
						inner join dbo.users U2 on I.EditedBy = U2.userID
		WHERE I.projectID = @ProjectID
		order by ItemID desc

	END
	
	IF @StatusID <> -1
	BEGIN
--		SELECT  ItemID, Title, Note, CreateDate, CreatedBy, EditDate, EditedBy, I.StatusID, S.Name
--		FROM    Items I inner join StatusTypes S on I.StatusID = S.StatusID
--		where	I.StatusID = @StatusID
		SELECT  ItemID, Title, Note, CreateDate, I.CreatedBy, U1.FirstName+' '+U1.LastName 'CreatedByName', EditDate, I.EditedBy, U2.FirstName+' '+U2.LastName 'EditedByName', I.StatusID, S.Name
		FROM    Items I inner join StatusTypes S on I.StatusID = S.StatusID
						inner join dbo.Users U1 on I.createdBy = U1.userID
						inner join dbo.users U2 on I.EditedBy = U2.userID
		WHERE	I.StatusID = @StatusID
		AND		I.projectID = @ProjectID
		order by ItemID desc

	END

END
GO
/****** Object:  Table [dbo].[History]    Script Date: 01/28/2012 23:56:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[History](
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Title] [varchar](200) NULL,
	[Note] [varchar](200) NULL,
	[EditDate] [datetime] NULL,
	[EditedBy] [int] NULL,
	[StatusID] [int] NULL,
	[HistoryTypeID] [int] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetProjectStats]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed A
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectStats] 
	@ProjectID int
	
AS
BEGIN
	SET NOCOUNT ON;

	select  (s.Name+' Status') 'Title', COUNT(1) 'Count'
	from	ScrumQueue.dbo.Projects P inner join 
			ScrumQueue.dbo.Items i on P.ProjectID = i.ProjectID inner join
			ScrumQueue.dbo.StatusTypes s on s.StatusID = i.StatusID
	where P.ProjectID = @ProjectID
	group by s.Name

	UNION

	select  'Total number of items' 'Title', COUNT(1) 'Count'
	from	ScrumQueue.dbo.Projects P inner join 
			ScrumQueue.dbo.Items i on P.ProjectID = i.ProjectID
	where P.ProjectID = @ProjectID
	group by P.ProjectName

END
GO
/****** Object:  StoredProcedure [dbo].[GetItemBasedOnItemID]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Get all Items Based on ItemID
-- =============================================
CREATE PROCEDURE [dbo].[GetItemBasedOnItemID]
	@ItemID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  ItemID, Title, Note, CreateDate, I.CreatedBy, U1.FirstName+' '+U1.LastName 'CreatedByName', EditDate, I.EditedBy, U2.FirstName+' '+U2.LastName 'EditedByName', I.StatusID, S.Name
		FROM    Items I inner join StatusTypes S on I.StatusID = S.StatusID
						inner join dbo.Users U1 on I.createdBy = U1.userID
						inner join dbo.users U2 on I.EditedBy = U2.userID
		where	I.ItemID = @ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertItem]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Insert New Item to Item table
-- =============================================
CREATE PROCEDURE [dbo].[InsertItem]
           @Title varchar(200),
           @Note  varchar(200),
           @CreatedBy  int,
           @EditedBy int,
           @StatusID int,
		   @ProjectID int
AS
BEGIN

	-- For now we will not insert the create history since we can keep track of the create date. 
	-- If an update happens, then the 1st occurance of the history will be the original 
	--EXEC	[dbo].[InsertHistory] @ItemID = @ID, @HistoryTypeID = 1

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert Statment

	 INSERT INTO [dbo].[Items] ([Title],[Note],[CreateDate],[CreatedBy],[EditDate],[EditedBy],[StatusID],[ProjectID])
     VALUES(@Title,@Note,getDate(),@CreatedBy ,getDate(), @EditedBy,@StatusID, @ProjectID)
	 Select ItemID = SCOPE_IDENTITY()   

END
GO
/****** Object:  StoredProcedure [dbo].[SearchItems]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Get all Items Based on Title
-- =============================================
CREATE PROCEDURE [dbo].[SearchItems]
	@ItemID int,
	@Title varchar(200),
	@Notes varchar(200),
	@CreateDate varchar(200), 
	@CreatedByUserName varchar(200), 
	@EditDate varchar(200), 
	@EditedByUserName varchar(200), 
	@StatusName varchar(200)

AS
BEGIN
	Declare @Title_fixed varchar(200)
	Declare @Notes_fixed varchar(200)
	Declare @CreateDate_fixed varchar(200)
	Declare @CreatedByUserName_fixed varchar(200)
	Declare @EditDate_fixed varchar(200)
	Declare @EditedByUserName_fixed varchar(200)
	Declare @StatusName_fixed varchar(200)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- CHECK IF WE HAVE TITLE
	IF LEN(RTRIM(LTRIM(@Title))) = 0 BEGIN
		SET @Title_fixed ='%'
	END
	ELSE BEGIN
		SET @Title_fixed = @Title
	END

	-- CHECK IF WE HAVE NOTES
	IF LEN(RTRIM(LTRIM(@Notes))) = 0 BEGIN
		SET @Notes_fixed ='%'
	END
	ELSE BEGIN
		SET @Notes_fixed = @Notes
	END

-- TO BE COMPLETED --


    -- Insert statements for procedure here
	SELECT     ItemID, Title, Note, CreateDate, CreatedBy, EditDate, EditedBy, StatusID
	FROM       Items
	where	   ItemID = @ItemID
	or (Title like '@Title')
	order by ItemID desc
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Update existing Item to Item table
-- =============================================
CREATE PROCEDURE [dbo].[UpdateItem]
           @ItemID int,
		   @Title varchar(200),
           @Note  varchar(200),
           @EditedBy int,
           @StatusID int,
			@ProjectID int

AS
BEGIN

	-- Exute thie history so we can keep track of what changed
--	EXEC	[dbo].[InsertHistory] @ItemID = @ItemID, @HistoryTypeID = 2

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Update Statment
UPDATE [ScrumQueue].[dbo].[Items]
   SET [Title] = @Title
      ,[Note] = @Note
      ,[EditDate] = getDate()
      ,[EditedBy] = @EditedBy
      ,[StatusID] = @StatusID
      ,[ProjectID] = @ProjectID
	WHERE ItemID = @ItemID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAttachment]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Feb 2011
-- Description:	Delete Attachment
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAttachment]
		@AttachmentID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From Attachments
	where AttachmentID = @AttachmentID
	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAttachment]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Feb 2011
-- Description:	update Attachment
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAttachment]
	-- Add the parameters for the stored procedure here
	@AttachmentID int,
	@ItemID int,
	@Name varchar(200),
	@FileName varchar(200),
	@FileType varchar(50),
	@FileSize int,
	@FileOriginalLocation varchar(200),
	@data varbinary(max)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [ScrumQueue].[dbo].[Attachments]
	 SET 
	   [ItemID] = @ItemID
      ,[Name] = @Name
      ,[FileName] = @FileName
      ,[FileType] = @FileType
      ,[FileSize] = @FileSize
      ,[FileOriginalLocation] = @FileOriginalLocation
      ,[FileData] = @data
	WHERE AttachmentID = @AttachmentID
           
END
GO
/****** Object:  StoredProcedure [dbo].[InsertHistory]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Insert New History Item
-- =============================================
CREATE PROCEDURE [dbo].[InsertHistory]
		   @ItemID int,
		   @HistoryTypeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert Statment
	INSERT INTO [dbo].[History]
		(ItemID, Title, Note, EditDate, EditedBy, StatusID, HistoryTypeID)
	Select	I.ItemID, I.Title, I.Note, I.EditDate,I.EditedBy,I.StatusID, @HistoryTypeID
	From	[dbo].[Items] I
	Where	[ItemID] = @ItemID
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAttachment]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Feb 2011
-- Description:	Insert Attachment
-- =============================================
CREATE PROCEDURE [dbo].[InsertAttachment]
	-- Add the parameters for the stored procedure here
	@ItemID int,
	@Name varchar(200),
	@CreateDate datetime,
	@FileName varchar(200),
	@FileType varchar(50),
	@fileSize int,
	@FileOriginalLocation varchar(200),
	@data varbinary(max)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ScrumQueue].[dbo].[Attachments]
           (ItemID
           ,[Name]
           ,[CreateDate]
           ,[FileName]
           ,[FileType]
           ,[FileSize]
           ,[FileOriginalLocation]
           ,[FileData])
     VALUES
           (@ItemID,
            @Name,
			@CreateDate,
			@FileName,
			@FileType,
			@fileSize,
			@FileOriginalLocation,
			@data)        
END
GO
/****** Object:  StoredProcedure [dbo].[GetHistoryBasedOnItemID]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Get All History Based on ItemID
-- =============================================
CREATE PROCEDURE [dbo].[GetHistoryBasedOnItemID]
	@ItemID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT  HistoryID, ItemID, Title, Note, EditDate, U2.username 'EditedBy', ST.Name 'Status', HistoryType
	FROM    ((([dbo].[History] H	
			inner join dbo.HistoryTypes HT ON H.historyTypeID = HT.historyTypeID)
			inner join dbo.Users U2 on U2.userID = H.EditedBy)
			inner join dbo.StatusTypes ST on ST.StatusID = H.StatusID)
	WHERE     (ItemID = @ItemID)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttachmentFileDataBasedOnAttachmentID]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Feb 2011
-- Description:	get list of Attachment based on item id
-- =============================================
Create PROCEDURE [dbo].[GetAttachmentFileDataBasedOnAttachmentID]
	-- Add the parameters for the stored procedure here
	@AttachmentID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select  [Name]
           ,[CreateDate]
           ,[FileName]
           ,[FileType]
           ,[FileSize]
           ,[FileOriginalLocation]
           ,[FileData]
	from [ScrumQueue].[dbo].[Attachments]
	Where AttachmentID = @AttachmentID
           
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAttachmentsBasedOnItemID]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed
-- Create date: Feb 2011
-- Description:	get list of Attachment based on item id
-- =============================================
CREATE PROCEDURE [dbo].[GetAllAttachmentsBasedOnItemID]
	-- Add the parameters for the stored procedure here
	@ItemID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select [AttachmentID],
			[ItemID]
           ,[Name]
           ,[CreateDate]
           ,[FileName]
           ,[FileType]
           ,[FileSize]
           ,[FileOriginalLocation]
           ,[FileData]
	
	
	from [ScrumQueue].[dbo].[Attachments]
	Where ItemID = @ItemID
           
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem]    Script Date: 01/28/2012 23:56:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Majed Atwi
-- Create date: Sept 21 2011
-- Description:	Delete Item
-- =============================================
CREATE PROCEDURE [dbo].[DeleteItem]
           @ID int

AS
BEGIN
	-- @HistoryTypeID = 3 is Delete action
	EXEC	[dbo].[InsertHistory] @ItemID = @ID, @HistoryTypeID = 3
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Delete Statment
	DELETE FROM [dbo].[Items]
	WHERE ItemID = @ID
END
GO
/****** Object:  Default [DF_Projects_isDefault]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_isDefault]  DEFAULT ((0)) FOR [isDefault]
GO
/****** Object:  Default [DF_Users_admin]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_admin]  DEFAULT ((0)) FOR [isAdmin]
GO
/****** Object:  ForeignKey [FK_Attachment_Item]    Script Date: 01/28/2012 23:56:04 ******/
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachment_Item]
GO
/****** Object:  ForeignKey [FK_History_HistoryTypes]    Script Date: 01/28/2012 23:56:04 ******/
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_HistoryTypes] FOREIGN KEY([HistoryTypeID])
REFERENCES [dbo].[HistoryTypes] ([HistoryTypeID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_HistoryTypes]
GO
/****** Object:  ForeignKey [FK_History_Items]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Items]
GO
/****** Object:  ForeignKey [FK_Items_Projects]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Projects]
GO
/****** Object:  ForeignKey [FK_Items_StatusTypes]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_StatusTypes] FOREIGN KEY([StatusID])
REFERENCES [dbo].[StatusTypes] ([StatusID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_StatusTypes]
GO
/****** Object:  ForeignKey [FK_ItemsCreatedBy_User]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_ItemsCreatedBy_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_ItemsCreatedBy_User]
GO
/****** Object:  ForeignKey [FK_ItemsEditedBy_User]    Script Date: 01/28/2012 23:56:05 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_ItemsEditedBy_User] FOREIGN KEY([EditedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_ItemsEditedBy_User]
GO
