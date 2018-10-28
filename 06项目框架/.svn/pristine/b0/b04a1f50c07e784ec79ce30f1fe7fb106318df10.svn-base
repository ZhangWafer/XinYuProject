IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'Membership')
EXEC sys.sp_executesql N'CREATE SCHEMA [Membership] AUTHORIZATION [dbo]'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Membership].[Module]') AND type in (N'U'))
BEGIN
CREATE TABLE [Membership].[Module](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RootID] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](100) NOT NULL,
	[URL] [nvarchar](100) NOT NULL,
	[IsMenu] [bit] NOT NULL,
	[IsFloder] [bit] NOT NULL,
	[IsPopedom] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedByID] [int] NOT NULL,
	[CreatedByName] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdByID] [int] NOT NULL,
	[LastUpdByName] [nvarchar](50) NOT NULL,
	[LastUpdDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MODULES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Membership].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [Membership].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[PasswordQuestion] [nvarchar](50) NOT NULL,
	[PasswordAnswer] [nvarchar](50) NOT NULL,
	[SessionIdentify] [nvarchar](50) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[RoleIDs] [ntext] NOT NULL,
	[PopedomIDs] [ntext] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
	[LastPwdChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPwdAttemptCount] [int] NOT NULL,
	[FailedPwdAttemptDate] [datetime] NOT NULL,
	[FailedPwdAnswerAttemptCount] [int] NOT NULL,
	[FailedPwdAnswerAttemptDate] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedByID] [int] NOT NULL,
	[CreatedByName] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdByID] [int] NOT NULL,
	[LastUpdByName] [nvarchar](50) NOT NULL,
	[LastUpdDate] [datetime] NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Membership].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [Membership].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[HeadImage] [nvarchar](50) NOT NULL,
	[PopedomIDs] [ntext] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[CreatedByID] [int] NOT NULL,
	[CreatedByName] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdByID] [int] NOT NULL,
	[LastUpdByName] [nvarchar](50) NOT NULL,
	[LastUpdDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
