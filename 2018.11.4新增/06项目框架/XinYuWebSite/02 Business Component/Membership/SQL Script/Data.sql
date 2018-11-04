

DECLARE @SupperUserID    int
DECLARE @SupperUserName  nvarchar(50)
DECLARE @SupperUserAlias nvarchar(50)

SET @SupperUserName  = 'Supper'
SET @SupperUserAlias =  '超级管理员'

Truncate Table [Membership].[User]
Truncate Table [Membership].[Role]
Truncate Table [Membership].[Module]



-- -----------------------------------------------------------------------------------------------
-- 增加基本用户
-- -----------------------------------------------------------------------------------------------
INSERT INTO [Membership].[User]
    ([UserName], [Password], [Alias], [Email], [Description],
    [PasswordQuestion], [PasswordAnswer], [SessionIdentify], 
    [IsSystem], [IsAdmin], [IsApproved], [IsLockedOut], [RoleIDs], [PopedomIDs],
    [LastLoginDate], [LastActivityDate], [LastPwdChangedDate], [LastLockoutDate], 
    [FailedPwdAttemptCount], [FailedPwdAttemptDate], [FailedPwdAnswerAttemptCount], [FailedPwdAnswerAttemptDate],
    [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
VALUES
    (@SupperUserName, '1B2M2Y8AsgTpgAmY7PhCfg==', @SupperUserAlias, '', '',
    '', '', '',
    1, 1, 1, 0, '', '',
    GETDATE(), GETDATE(), GETDATE(), GETDATE(),
    0, GETDATE(), 0, GETDATE(),
    0, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())

SELECT @SupperUserID = @@IDENTITY


-- -----------------------------------------------------------------------------------------------
-- 增加菜单
-- -----------------------------------------------------------------------------------------------
DECLARE @MenuTopID                int
DECLARE @MenuAccountManagementID  int
DECLARE @MenuDataManagementID     int
DECLARE @MenuSystemManagementID   int

DECLARE @MenuDzwlSBManagementID   int
DECLARE @MenuDzwlZDManagementID   int
DECLARE @MenuDzwlCNManagementID   int

SET @MenuTopID = 0

-- 一级菜单
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, '账户管理',     '', '', 1, 1, 1, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuAccountManagementID = @@IDENTITY
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, '基础数据管理', '', '', 1, 1, 0, 200, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuDataManagementID = @@IDENTITY
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuTopID, '系统管理',     '', '', 1, 1, 0, 300, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE()) SELECT @MenuSystemManagementID = @@IDENTITY

-- 账户管理菜单
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '查看日历', '', 'Calendar.htm',               1, 0, 1, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '修改密码', '', 'SysManager/UserUpdPwd.aspx', 1, 0, 1, 200, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuAccountManagementID, '账户设置', '', 'SysManager/UserUpd.aspx',    1, 0, 1, 300, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())


-- 基础数据管理菜单

-- 系统管理菜单
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '修改菜单',     '', 'SysManager/ModuleAdd.aspx?id=',      0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '菜单管理',     '', 'SysManager/ModuleManager.aspx',      1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '增加角色',     '', 'SysManager/RoleAdd.aspx',            1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '修改角色',     '', 'SysManager/RoleAdd.aspx?id=',        0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '角色管理',     '', 'SysManager/RoleManager.aspx',        1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '角色权限分配', '', 'SysManager/RolePopedomManager.aspx', 1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '增加用户',     '', 'SysManager/UserAdd.aspx',            1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '修改用户',     '', 'SysManager/UserAdd.aspx?id=',        0, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '用户管理',     '', 'SysManager/UserManager.aspx',        1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '用户权限分配', '', 'SysManager/UserPopedomManager.aspx', 1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())
INSERT INTO [Membership].[Module] ([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], [DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]) VALUES (@MenuTopID, @MenuSystemManagementID, '预览用户权限', '', 'SysManager/UserPopedomView.aspx',    1, 0, 0, 100, 0, @SupperUserName, GETDATE(), 0, @SupperUserName, GETDATE())